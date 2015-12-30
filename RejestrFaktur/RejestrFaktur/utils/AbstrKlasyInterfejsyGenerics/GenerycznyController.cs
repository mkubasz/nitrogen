using System.Web.Mvc;
using RejestrFaktur.DAL;
using RejestrFaktur.utils.pozostale;

namespace RejestrFaktur.utils.AbstrKlasyInterfejsyGenerics
{

    public abstract class GenerycznyController<T> : Controller where T :class,new()
    {
        protected RejestrFakturContext dbcontext;
        protected Opakowanie<T> opakowanie;
        protected ObslugaDelegaty<int, Stany> obslugaDelegaty;


        protected virtual ObiektDoWidoku<T> Wypelnij(int? id, Stany? stan)
        {
            int idOb = id ?? 0;
            Stany stanOb = stan ?? default(Stany);
            obslugaDelegaty.Obsluz(idOb, stanOb);
            return opakowanie.ObiektDoWidoku;

        }

        public virtual ActionResult Index(int? id, Stany? stan)
        {
            //ViewBag.Tytul = "Jednostki miary";
            return View(Wypelnij(id, stan));
        }

        public virtual ActionResult EdycjaNowy(int? id, Stany? stan)
        {
            //ViewBag.Tytul = "Jednostki miary - edycja dodawanie";
            return View(Wypelnij(id, stan));
        }

        public virtual ActionResult Szczegoly(int? id, Stany? stan)
        {
            //ViewBag.Tytul = "Jednostki miary - szczegóły";
            return View(Wypelnij(id, stan));
        }


        public ActionResult DoUsuniencia(int? id, Stany? stan)
        {
            //ViewBag.Tytul = "Jednostki miary - szczegóły";
            return View(Wypelnij(id, stan));
        }


        public abstract ActionResult Zapisz(T t, Stany StanObiektu);
        public abstract ActionResult Usun(T t);

    }
}