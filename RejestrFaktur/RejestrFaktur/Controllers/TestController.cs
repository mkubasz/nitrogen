using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RejestrFaktur.Models;

namespace RejestrFaktur.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            JednostkaMiary jm = new JednostkaMiary();
            return View(jm);
        }
    }
}