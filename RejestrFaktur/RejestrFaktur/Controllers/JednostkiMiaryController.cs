using RejestrFaktur.DAL;
using RejestrFaktur.Models;
using RejestrFaktur.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace RejestrFaktur.Controllers
{
    public class JednostkiMiaryController : Controller
    {

        private RejestrFakturContext dbcontext;
        private Opakowanie<JednostkaMiary> opakJednostkiMiar;
        //private ObslugaKolekcja<JednostkaMiary> obsluga;
        private ObslugaJednostkiMiary obslugaJM;
        private ObslugaDelegaty<int, Stany> obslugaDelegaty;


        public JednostkiMiaryController()
        {
            dbcontext = new RejestrFakturContext();
            opakJednostkiMiar = new Opakowanie<JednostkaMiary>(new JednostkiMiaryOperacje(), dbcontext);
            obslugaJM = new ObslugaJednostkiMiary(opakJednostkiMiar);
            obslugaDelegaty = new ObslugaDelegaty<int, Stany>();

            obslugaDelegaty.delegaty += obslugaJM.DoEdycji;
            obslugaDelegaty.delegaty += obslugaJM.DoPodgladu;
            obslugaDelegaty.delegaty += obslugaJM.DoUsuniencia;
            obslugaDelegaty.delegaty += obslugaJM.Nowy;

            //obsluga = new KolejkaObslugiJM(opakJednostkiMiar);
        }

        private ObiektDoWidoku<JednostkaMiary> Wypelnij(int? id, Stany? stan)
        {
            int idOb = id ?? 0;
            Stany stanOb = stan ?? default(Stany);
            //obsluga.Obsluz(idOb, stanOb);
            obslugaDelegaty.Obsluz(idOb, stanOb);
            return opakJednostkiMiar.ObiektDoWidoku;

        }

        public ActionResult Index(int? id, Stany? stan)
        {
            ViewBag.Tytul = "Jednostki miary";
            return View(Wypelnij(id,stan));

        }

        public ActionResult EdycjaNowy(int? id,Stany? stan)
        {
            ViewBag.Tytul = "Jednostki miary - edycja dodawanie";
            return View(Wypelnij(id, stan));
        }

        public ActionResult Szczegoly(int? id, Stany? stan)
        {
            ViewBag.Tytul = "Jednostki miary - szczegóły";
            return View(Wypelnij(id, stan));
        }


        public ActionResult DoUsuniencia(int? id, Stany? stan)
        {
            ViewBag.Tytul = "Jednostki miary - szczegóły";
            return View(Wypelnij(id, stan));
        }


        [ActionName("EdycjaNowy"),AcceptVerbs("Post")]
        public ActionResult Zapisz([Bind(Prefix = "Edytowany", Include = "Id,NazwaJednostki,SymbolJednostki")]JednostkaMiary jM,
                             [Bind(Include = "StanObiektu")]Stany StanObiektu)
        {

            if (ModelState.IsValid)
            {
                if (opakJednostkiMiar.ZapiszObiekt(jM, StanObiektu))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            }
            else
            {
                opakJednostkiMiar.ObiektDoWidoku.Edytowany = jM;
                opakJednostkiMiar.ObiektDoWidoku.StanObiektu = StanObiektu;
                return View(opakJednostkiMiar.ObiektDoWidoku);
            }

        }

        [HttpPost]
        public ActionResult Usun([Bind(Prefix = "Edytowany", Include = "Id,NazwaJednostki,SymbolJednostki")]JednostkaMiary jM)
        {
            if (ModelState.IsValid)
            {
                if (opakJednostkiMiar.UsunObiekt(jM))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            }
            else
            {
                return RedirectToAction("Index");
            }    
        }
    }
}