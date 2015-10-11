using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloWorld.Controllers
{
    public class DynamicController : Controller
    {
        // GET: Dynamic
        public ActionResult Index()
        {
	        ViewBag.DisplayText = "My text";
            return View();
        }
    }
}