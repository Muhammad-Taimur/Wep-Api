using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

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
            config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new StringEnumConverter());

        }
    }
}
