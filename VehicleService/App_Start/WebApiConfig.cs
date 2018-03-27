using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;


namespace VehicleService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.EnableCors();
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "VehicleApi",
                routeTemplate: "api/v1/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional, Controller="Vehicles" }
            );


            config.Routes.MapHttpRoute(
              name: "VehicleFilterApi",
              routeTemplate: "api/v2/{controller}/{id}",
              defaults: new { id = RouteParameter.Optional, Controller = "VehiclesFilter" }
          );
        }
    }
}
