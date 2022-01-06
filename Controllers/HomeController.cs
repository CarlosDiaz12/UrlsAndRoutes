using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UrlsAndRoutes.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Controller = "Home";
            ViewBag.Action = "Index";
            return View("ActionName");
        }

        // Defining a Default Value for an Action Method Parameter
        public ActionResult CustomVariable(string id = "DefaultId")
        {
            ViewBag.Controller = "Home";
            ViewBag.Action = "CustomVariable";
            ViewBag.CustomVariable = id;
            return View();
        }

        // Generating an Outgoing URL
        public ViewResult MyActionMethod()
        {
            string myActionUrl = Url.Action("Index", new { id = "MyID" });
            string myRouteUrl = Url.RouteUrl(new
            {
                controller = "Home",
                action = "Index"
            });
            //... do something with URLs...
            return View();
        }

        // Redirecting to Another Action
        // public RedirectToRouteResult MyActionMethod()
        // {
        //     return RedirectToAction("Index");
       
        // return RedirectToRoute(new { controller = "Home", action = "Index", id = "MyID" });
        // }
    }
}