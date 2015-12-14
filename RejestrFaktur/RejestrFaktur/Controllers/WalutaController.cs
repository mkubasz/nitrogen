using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RejestrFaktur.DAL;
using RejestrFaktur.Models;
using RejestrFaktur.utils;
using Extensions;
using System.Web.Mvc;
using System.Net;

namespace RejestrFaktur.Controllers
{
    public class WalutaController : GenerycznyController<Waluta>
    {

        public WalutaController()
        {
           dbcontext = new RejestrFakturContext();
           opakowanie = new Opakowanie<Waluta>(new WalutaOperacje(), dbcontext);
           obslugaDelegaty = new ObslugaDelegaty<int, Stany>();

            obslugaDelegaty.delegaty +=opakowanie.DoEdycji;
            obslugaDelegaty.delegaty +=opakowanie.DoPodgladu;
            obslugaDelegaty.delegaty +=opakowanie.DoUsuniencia;
            obslugaDelegaty.delegaty +=opakowanie.Nowy;
        }

        [ActionName("EdycjaNowy"), AcceptVerbs("Post")]
        public override ActionResult Zapisz([Bind(Prefix = "Edytowany", Include = "Id,Nazwa,Symbol,SciezkaDoIkony")]Waluta t, [Bind(Include = "StanObiektu")]Stany StanObiektu)
        {
            {

                if (ModelState.IsValid)
                {
                    if (opakowanie.ZapiszObiekt(t, StanObiektu))
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
                    opakowanie.ObiektDoWidoku.Edytowany = t;
                    opakowanie.ObiektDoWidoku.StanObiektu = StanObiektu;
                    return View(opakowanie.ObiektDoWidoku);
                }
            }
        }

        [HttpPost]
        public override ActionResult Usun([Bind(Prefix = "Edytowany", Include = "Id,Nazwa,Symbol,SciezkaDoIkony")]Waluta t)
        {
            if (ModelState.IsValid)
            {
                if (opakowanie.UsunObiekt(t))
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