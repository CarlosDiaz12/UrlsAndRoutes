using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Routing.Constraints;
using System.Web.Routing;
using UrlsAndRoutes.Infrastructure;

namespace UrlsAndRoutes
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();
            //routes.MapRoute("NewRoute", "App/Do{action}",
            //        new { controller = "Home" });

            //routes.MapRoute("MyRoute", "{controller}/{action}/{id}",
            //        new
            //        {
            //            controller = "Home",
            //            action = "Index",
            //            id = UrlParameter.Optional
            //        });

            // you can select a specific route to be used to generate an outgoing URL
            routes.MapRoute("MyRoute", "{controller}/{action}");
            routes.MapRoute("MyOtherRoute", "App/{action}", new { controller = "Home" });
        }
    }
}
