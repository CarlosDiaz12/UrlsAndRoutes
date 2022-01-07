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

            // Enabling Route Evaluation Before File-Checking
            routes.RouteExistingFiles = true;

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();

            // A Route Whose URL Pattern Corresponds to a Disk File
            routes.MapRoute("DiskFile", "Content/StaticContent.html",
                        new
                        {
                            controller = "Customer",
                            action = "List",
                        });

            // Using a Custom Routing Handler

            // routes.Add(new Route("SayHello", new CustomRouteHandler()));

            //routes.MapRoute("NewRoute", "App/Do{action}",
            //        new { controller = "Home" });

            routes.Add(new LegacyRoute("~/articles/Windows_3.1_Overview.html", "~/old/.NET_1.0_Class_Library"));

            routes.MapRoute("MyRoute", "{controller}/{action}/{id}",
                    new
                    {
                        controller = "Home",
                        action = "Index",
                        id = UrlParameter.Optional
                    },
                    // This change ensures that the controllers in the main project are given priority in resolving requests.
                    new[] { "UrlsAndRoutes.Controllers" });

            // you can select a specific route to be used to generate an outgoing URL
            //routes.MapRoute("MyRoute", "{controller}/{action}");
            //routes.MapRoute("MyOtherRoute", "App/{action}", new { controller = "Home" });
        }
    }
}
