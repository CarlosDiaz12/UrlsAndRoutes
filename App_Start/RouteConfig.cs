using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace UrlsAndRoutes
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //Route myRoute = new Route("{controller}/{action}", , new MvcRouteHandler());
            //routes.Add("myRoute", myRoute);

            // Designating a Catchall Variable
            // There is no upper limit to the number of segments that the URL pattern in this route will match
            routes.MapRoute("MyRoute00", "{controller}/{action}/{id}/{*catchall}", new
            {
                controller = "Home",
                action = "Index",
                id = UrlParameter.Optional
            },
            // Specifying Namespace Resolution Order
                new[] { "URLsAndRoutes.AdditionalControllers" }
             );

            // custom segments
            routes.MapRoute("MyRoute", "{controller}/{action}/{id}",
                new
                {                    controller = "Home",
                    action = "Index",
                    id = "DefaultId"
                });

            // optional parameter
            // id = UrlParameter.Optional

            // Aliasing a Controller and an Action
            routes.MapRoute("ShopSchema2", "Shop/OldAction",
                new { controller = "Home", action = "Index" });

            // Mixing Static URL Segments and Default Values - replace "Shop" with "Home"
            routes.MapRoute("ShopSchema", "Shop/{action}",
                new { controller = "Home" });

            routes.MapRoute("", "X{controller}/{action}");

            routes.MapRoute("myRoute2", "{controller}/{action}",
                new { controller = "Home", action = "Index" });

            // static segments
            routes.MapRoute("", "Public/{controller}/{action}",
                new { controller = "Home", action = "Index" });



            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);


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
