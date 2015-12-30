using RejestrFaktur.DAL;
using RejestrFaktur.Models;
using System.Net;
using System.Web.Mvc;
using RejestrFaktur.utils.AbstrKlasyInterfejsyGenerics;
using RejestrFaktur.utils.HelpersExtensions;
using RejestrFaktur.utils.impl.JednostkiMiary;
using RejestrFaktur.utils.pozostale;

namespace RejestrFaktur.Controllers
{
    public class JednostkiMiaryController : GenerycznyController<JednostkaMiary>
    {


        public JednostkiMiaryController()
        {
            dbcontext = new RejestrFakturContext();
            opakowanie = new Opakowanie<JednostkaMiary>(new JednostkiMiaryOperacje(), dbcontext);
            obslugaDelegaty = new ObslugaDelegaty<int, Stany>();

            obslugaDelegaty.delegaty += opakowanie.DoEdycji;
            obslugaDelegaty.delegaty += opakowanie.DoPodgladu;
            obslugaDelegaty.delegaty += opakowanie.DoUsuniencia;
            obslugaDelegaty.delegaty += opakowanie.Nowy;

        }

        [ActionName("EdycjaNowy"), AcceptVerbs("Post")]
        public override ActionResult Zapisz([Bind(Prefix = "Edytowany", Include = "Id,NazwaJednostki,SymbolJednostki")]JednostkaMiary t,
                             [Bind(Include = "StanObiektu")]Stany StanObiektu)
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

        [HttpPost]
        public override ActionResult Usun([Bind(Prefix = "Edytowany", Include = "Id,NazwaJednostki,SymbolJednostki")]JednostkaMiary t)
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