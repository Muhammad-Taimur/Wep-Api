using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MyOdeToFood.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //Remove the xml Formatter.
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            // Web API configuration and services
            //This will show the ENUM value as String in Json Format.
            config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new StringEnumConverter());

          /*This will allow Cross Origin API Sharing. Below Start are Parameter
            1st Parameter is for Oriigin we can add selected origin by using, or we can do * for all origins
            2nd We can select * for all headers or we can select only Json Request.
            3rd We can assign Any Request Menhod like post of Get. or * for all Method */
            
            EnableCorsAttribute cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);


            //This is use to show the Array inside Object Ignoring Referece Loop
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling
            = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            //creating all the Key value in Camel Case
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver =
                new CamelCasePropertyNamesContractResolver();
        }   
    }       
}           
