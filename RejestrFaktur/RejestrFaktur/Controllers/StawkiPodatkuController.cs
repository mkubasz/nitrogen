using RejestrFaktur.DAL;
using RejestrFaktur.Models;
using System.Net;
using System.Web.Mvc;
using RejestrFaktur.utils.AbstrKlasyInterfejsyGenerics;
using RejestrFaktur.utils.HelpersExtensions;
using RejestrFaktur.utils.impl.StawkiPodatku;
using RejestrFaktur.utils.pozostale;

namespace RejestrFaktur.Controllers
{
    public class StawkiPodatkuController : GenerycznyController<StawkaPodatku>
    {

        public StawkiPodatkuController()
        {
            dbcontext = new RejestrFakturContext();
            opakowanie = new Opakowanie<StawkaPodatku>(new StawkiPodatkuOperacje(), dbcontext);
            obslugaDelegaty = new ObslugaDelegaty<int, Stany>();

            obslugaDelegaty.delegaty +=opakowanie.DoEdycji;
            obslugaDelegaty.delegaty +=opakowanie.DoPodgladu;
            obslugaDelegaty.delegaty += opakowanie.DoUsuniencia;
            obslugaDelegaty.delegaty += opakowanie.Nowy;
        }



        [ActionName("EdycjaNowy"), AcceptVerbs("Post")]
        public override ActionResult Zapisz([Bind(Prefix = "Edytowany", Include = "Id,NazwaStawki, WysokoscStawki")]StawkaPodatku sP,
                             [Bind(Include = "StanObiektu")]Stany StanObiektu)
        {

            if (ModelState.IsValid)
            {
                if (opakowanie.ZapiszObiekt(sP, StanObiektu))
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
                opakowanie.ObiektDoWidoku.Edytowany = sP;
                opakowanie.ObiektDoWidoku.StanObiektu = StanObiektu;
                return View(opakowanie.ObiektDoWidoku);
            }

        }

        [HttpPost]
        public override ActionResult Usun([Bind(Prefix = "Edytowany", Include = "Id,NazwaStawki, WysokoscStawki")]StawkaPodatku sP)
        {
            if (ModelState.IsValid)
            {
                if (opakowanie.UsunObiekt(sP))
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