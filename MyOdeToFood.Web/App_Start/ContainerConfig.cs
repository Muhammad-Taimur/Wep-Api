using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using AutoMapper;
using MyOdeToFood.Data.Services;
using MyOdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;


namespace MyOdeToFood.Web.App_Start
{
    public class ContainerConfig
    {
        internal static void RegisterContainer(HttpConfiguration httpConfiguration)
        {
            var builder = new ContainerBuilder();

          
            builder.RegisterApiControllers(typeof(MvcApplication).Assembly);
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            //Register Class
            builder.RegisterType<SqlRestaurantData>()
                .As<IRestaurantData, IDhabaData, IEmployee>()
                .InstancePerRequest();

            //new Classes added as new Builder.
            builder.RegisterType<SqlRestaurantData>()
                .As<IMovie, IActor>()
                .InstancePerRequest();



            //Register DB Context Class
            builder.RegisterType<MyOdeToFoodDbContext>().InstancePerRequest();

            //Mapper Configuration
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            
            config.AssertConfigurationIsValid();
            
            //Register Mapping Classes
            builder.RegisterInstance(config.CreateMapper())
                .As<IMapper>()
                .SingleInstance();




            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(container);


            

            
        }
}
    }
