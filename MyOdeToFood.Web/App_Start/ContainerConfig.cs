using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using MyOdeToFood.Data.Services;
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

            builder.RegisterType<SqlRestaurantData>()
                .As<IRestaurantData, IDhabaData, IEmployee>()
                .InstancePerRequest();

            //new Classes added as new Builder.
            builder.RegisterType<SqlRestaurantData>()
                .As<IMovie, IActor>()
                .InstancePerRequest();

            builder.RegisterType<MyOdeToFoodDbContext>().InstancePerRequest();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
}
    }
