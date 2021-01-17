using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace PhoneApp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            var jsonSerializerSetting = config.Formatters.JsonFormatter.SerializerSettings;
            jsonSerializerSetting.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            jsonSerializerSetting.ContractResolver = new CamelCasePropertyNamesContractResolver();

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
