using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UrlsAndRoutes.Controllers
{
   [RoutePrefix("Users")]
    public class CustomerController : Controller
    {
        // GET: Customer
        /*
         Prefixing the URL with ∼/ tells the MVC Framework that I don’t want the RoutePrefix attribute applied to the Index
            action method, which means that it will still be accessible through the URL /Test.
         */
        [Route("~/Test")]
        public ActionResult Index()
        {
            ViewBag.Controller = "Customer";
            ViewBag.Action = "Index";
            return View("ActionName");
        }

        // Creating an Attribute Route with a Segment Variable
        [Route("Add/{user}/{id:int}")]
        public string Create(string user, int id)
        {
            return string.Format("User: {0}, ID: {1}", user, id);
        }

        // Adding an Action Method and Route
        [Route("Add/{user}/{password}")]
        public string ChangePass(string user, string password)
        {
            return string.Format("ChangePass Method - User: {0}, Pass:{ 1}", user, password);
        }

        public ActionResult List()
        {
            ViewBag.Controller = "Customer";
            ViewBag.Action = "List";
            return View("ActionName");
        }
    }
}