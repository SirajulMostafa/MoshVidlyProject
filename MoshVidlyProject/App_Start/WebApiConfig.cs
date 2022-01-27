using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MoshVidlyProject
{
    public static class WebApiConfig
    {/*
    public static void Register(HttpConfiguration config)
    {

        config.MapHttpAttributeRoutes();

        config.Routes.MapHttpRoute(
            name: "DefaultApi",
            routeTemplate: "api/{controller}/{id}",
            defaults: new { id = RouteParameter.Optional }
        );

        var setting = config.Formatters.JsonFormatter;
        setting.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
        config.Formatters.Remove(config.Formatters.XmlFormatter);
        setting.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        setting.SerializerSettings.Formatting = Formatting.Indented;
        // configure additional webapi settings here..
    }*/
    
        public static void Register(HttpConfiguration config)
        {
            var settings = config.Formatters.JsonFormatter.SerializerSettings;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            settings.Formatting = Formatting.Indented;

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    
    }
}