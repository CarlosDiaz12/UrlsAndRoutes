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

            // Using a Regular Expression to Constrain a Route
            
            routes.MapRoute("MyRoute", " { controller}/{ action}/{ id}/{ *catchall}",
                new
                {
                    controller = "Home",
                    action = "Index",
                    // Using a Built-in Type/Value Constraint - Combining Route Constraints
                    /*
                     id = new CompoundRouteConstraint(new IRouteConstraint[] { new AlphaRouteConstraint(), new MinLengthRouteConstraint(6) })
                     */
                    id = new RangeRouteConstraint(10, 20)
                },

                // Constraining a Route to a Specific Set of Segment Variable Values
                new { 
                    controller = "^H.*", action =  "^ Index$| ^About$",
                    // Constraining a Route Based on an HTTP Method
                    httpMethod = new HttpMethodConstraint("GET"),
                    // Applying a Custom Constraint in a Route
                    customConstraint = new UserAgentConstraint("Chrome")
                },
                new[] { "URLsAndRoutes.Controllers" });


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
