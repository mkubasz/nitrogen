﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RejestrFaktur.DAL;
using RejestrFaktur.Models;
using RejestrFaktur.utils;
using Extensions;

namespace RejestrFaktur.Controllers
{
    public class PlatnosciTypController :GenerycznyController<PlatnoscTyp>
    {

        public PlatnosciTypController()
        {
            dbcontext = new RejestrFakturContext();
            opakowanie = new Opakowanie<PlatnoscTyp>(new PlatnoscTypOperacje(), dbcontext);
            obslugaDelegaty = new ObslugaDelegaty<int, Stany>();

            obslugaDelegaty.delegaty += opakowanie.DoEdycji;
            obslugaDelegaty.delegaty += opakowanie.DoPodgladu;
            obslugaDelegaty.delegaty += opakowanie.DoUsuniencia;
            obslugaDelegaty.delegaty += opakowanie.Nowy;
        }


        [ActionName("EdycjaNowy"), AcceptVerbs("Post")]
        public override ActionResult Zapisz([Bind(Prefix = "Edytowany", Include = "Id,Nazwa,Opis")]PlatnoscTyp t, [Bind(Include = "StanObiektu")]Stany StanObiektu)
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
        public override ActionResult Usun([Bind(Prefix = "Edytowany", Include = "Id,Nazwa,Opis")]PlatnoscTyp t)
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