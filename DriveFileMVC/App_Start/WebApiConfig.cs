using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace DriveFileMVC
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
           
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
               name: "DefaultApi",
               routeTemplate: "webapi/{controller}/{id}",
               defaults: new { id = RouteParameter.Optional }
           );
        }
    }
}
