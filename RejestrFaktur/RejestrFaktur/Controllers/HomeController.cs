using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RejestrFaktur.DAL;

namespace RejestrFaktur.Controllers
{
    public class HomeController : Controller
    {
        private  RejestrFakturContext _db ;

        public HomeController()
        {
            _db = new RejestrFakturContext();
        }

        public ActionResult Index()
        {
           
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page5.";
       
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}