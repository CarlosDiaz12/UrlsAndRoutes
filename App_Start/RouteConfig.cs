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

            // Enabling Attribute Routing
            routes.MapMvcAttributeRoutes();

            routes.MapRoute("Default", "{controller}/{action}/{id}",
            new
            {
                controller = "Home",
                action = "Index",
                id = UrlParameter.Optional
            },
            new[] { "UrlsAndRoutes.Controllers" });




            // Applying a Custom Constraint in a Route
            /*
             routes.MapRoute("ChromeRoute", "{*catchall}",
                new { controller = "Home", action = "Index" },
                new { customConstraint = new UserAgentConstraint("Chrome")
                },
                    new[] { "UrlsAndRoutes.AdditionalControllers" });
                         
             */


            // Using Multiple Routes to Control Namespace Resolution

            /*
             routes.MapRoute("AddContollerRoute", "Home/{action}/{id}/{*catchall}",
                    new { controller = "Home", action = "Index",
                    id = UrlParameter.Optional },
                    new[] { "URLsAndRoutes.AdditionalControllers" });
             
             routes.MapRoute("MyRoute", " {controller}/{action}/{id}/{*catchall}",
                    new { controller = "Home", action = "Index",
                    id = UrlParameter.Optional },
                    new[] { "URLsAndRoutes.Controllers" });


             
             */

            // Disabling Fallback Namespaces
            /*
             Route myRoute = routes.MapRoute("AddContollerRoute", "Home/{action}/{id}/{*catchall}",
                new { controller = "Home", action = "Index",
                id = UrlParameter.Optional },
                new[] { "URLsAndRoutes.AdditionalControllers" });
            myRoute.DataTokens["UseNamespaceFallback"] = false;
             */
        }
    }
}
