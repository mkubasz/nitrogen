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
    public class StawkiPodatkuController : Controller
    {
        private RejestrFakturContext dbcontext;
        private Opakowanie<StawkaPodatku> opakStawkiPodatku;
        private ObslugaStawkiPodatku obslugaSP;
        private ObslugaDelegaty<int, Stany> obslugaDelegaty;
        public StawkiPodatkuController()

        {
            dbcontext = new RejestrFakturContext();
            opakStawkiPodatku = new Opakowanie<StawkaPodatku>(new StawkiPodatkuOperacje(), dbcontext);
            obslugaSP = new ObslugaStawkiPodatku(opakStawkiPodatku);
            obslugaDelegaty = new ObslugaDelegaty<int, Stany>();

            obslugaDelegaty.delegaty += obslugaSP.DoEdycji;
            obslugaDelegaty.delegaty += obslugaSP.DoPodgladu;
            obslugaDelegaty.delegaty += obslugaSP.DoUsuniencia;
            obslugaDelegaty.delegaty += obslugaSP.Nowy;
        }

        private ObiektDoWidoku<StawkaPodatku> Wypelnij(int? id, Stany? stan)
        {
            int idOb = id ?? 0;
            Stany stanOb = stan ?? default(Stany);
            obslugaDelegaty.Obsluz(idOb, stanOb);
            return opakStawkiPodatku.ObiektDoWidoku;

        }

        public ActionResult Index(int? id, Stany? stan)
        {
            ViewBag.Tytul = "Stawki podatku";
            return View(Wypelnij(id, stan));

        }

        public ActionResult EdycjaNowy(int? id, Stany? stan)
        {
            ViewBag.Tytul = "Stawki podatku - edycja dodawanie";
            return View(Wypelnij(id, stan));
        }

        public ActionResult Szczegoly(int? id, Stany? stan)
        {
            ViewBag.Tytul = "Stawki podatku - szczegóły";
            return View(Wypelnij(id, stan));
        }


        public ActionResult DoUsuniencia(int? id, Stany? stan)
        {
            ViewBag.Tytul = "Stawki podatku - szczegóły";
            return View(Wypelnij(id, stan));
        }


        [ActionName("EdycjaNowy"), AcceptVerbs("Post")]
        public ActionResult Zapisz([Bind(Prefix = "Edytowany", Include = "Id,NazwaStawki, WysokoscStawki")]StawkaPodatku sP,
                             [Bind(Include = "StanObiektu")]Stany StanObiektu)
        {

            if (ModelState.IsValid)
            {
                if (opakStawkiPodatku.ZapiszObiekt(sP, StanObiektu))
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
                opakStawkiPodatku.ObiektDoWidoku.Edytowany = sP;
                opakStawkiPodatku.ObiektDoWidoku.StanObiektu = StanObiektu;
                return View(opakStawkiPodatku.ObiektDoWidoku);
            }

        }

        [HttpPost]
        public ActionResult Usun([Bind(Prefix = "Edytowany", Include = "Id,NazwaStawki, WysokoscStawki")]StawkaPodatku sP)
        {
            if (ModelState.IsValid)
            {
                if (opakStawkiPodatku.UsunObiekt(sP))
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