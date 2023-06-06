using ServiceDotNet.Api.Infrastructure.MessageHandlers;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ServiceDotNet.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "Swagger",
                routeTemplate: "",
                defaults: new { controller = "Swagger", action = "RedirectToSwagger" }
            );

            GlobalConfiguration.Configuration.MessageHandlers.Add(new AuthHandler());

            var cors = new EnableCorsAttribute("http://localhost:4200", "*", "*", "*");
            config.EnableCors(cors);
        }
    }
}
