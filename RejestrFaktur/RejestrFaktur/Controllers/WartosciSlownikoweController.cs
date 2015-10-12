using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RejestrFaktur.Controllers
{
    public class WartosciSlownikoweController : Controller
    {
        // GET: WartosciSlownikowe
        public ActionResult Index()
        {
            ViewBag.Title = "Wartości słownikowe";
            return View();
        }

        // GET: WartosciSlownikowe
        public ActionResult JednostkiMiary()
        {
            ViewBag.Title = "Jednostki miary";
            return View();
        }

        // GET: WartosciSlownikowe
        public ActionResult StawkiPodatku()
        {
            ViewBag.Title = "Stawki podatku";
            return View();
        }


        // GET: WartosciSlownikowe
        public ActionResult Waluty()
        {
            ViewBag.Title = "Waluty";
            return View();
        }

        // GET: WartosciSlownikowe
        public ActionResult TypyPlatnosci()
        {
            ViewBag.Title = "Typy płatności";
            return View();
        }

    }
}