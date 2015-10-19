using RejestrFaktur.DAL;
using RejestrFaktur.Models;
using RejestrFaktur.utils;
using RejestrFaktur.utils.impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RejestrFaktur.Controllers
{
    public class WartosciSlownikoweController : Controller
    {

        private RejestrFakturContext context;
        private Opakowanie<JednostkaMiary> jednostkiMiaryKol;
        //Opakowanie<PlatnoscTyp> platnosciTypy;
        //Opakowanie<Waluta> waluty;
        //Opakowanie<StawkaPodatku> stawkiPodatku;

        public WartosciSlownikoweController()
        {
            context = new RejestrFakturContext();
            jednostkiMiaryKol = new Opakowanie<JednostkaMiary>(context.JednostkiMiar.ToList(), new OpakowanieJednostkiFactory().create());
        }

        

        // GET: WartosciSlownikowe
        public ActionResult Index()
        {
            ViewBag.Title = "Wartości słownikowe";
            return View();
        }

        // GET: WartosciSlownikowe
        public ActionResult JednostkiMiary(int? idx)
        {
            ViewBag.Title = "Jednostki miary";
            int i = idx ?? default(int);
            jednostkiMiaryKol.ustawDoEdycji(i);
            return View(jednostkiMiaryKol);
        }


        //[HttpPost]
        //public ActionResult Edytuj(int? idc)
        //{
        //    int i = idc ?? default(int);
        //    jednostkiMiaryKol.ustawDoEdycji(i);
        //    return RedirectToAction("JednostkiMiary",i);
        //}


        // GET: WartosciSlownikowe
        public ActionResult StawkiPodatku()
        {
            ViewBag.Title = "Stawki podatku";
            return RedirectToAction("JednostkiMiary");
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