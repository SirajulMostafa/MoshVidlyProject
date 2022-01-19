using Newtonsoft.Json.Serialization;
using System.Web.Http;

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

        var setting = config.Formatters.JsonFormatter;
        setting.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
        config.Formatters.Remove(config.Formatters.XmlFormatter);
        setting.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        // configure additional webapi settings here..
    }
}