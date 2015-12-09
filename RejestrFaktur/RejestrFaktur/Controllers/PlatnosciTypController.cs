using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RejestrFaktur.DAL;
using RejestrFaktur.Models;
using RejestrFaktur.utils;
using Extensions;

namespace RejestrFaktur.Controllers
{
    public class PlatnosciTypController : Controller
    {
        private RejestrFakturContext dbcontext;
        private Opakowanie<PlatnoscTyp> opakPlatnoscTyp;
        private ObslugaDelegaty<int, Stany> obslugaDelegaty;
        
        public PlatnosciTypController()
        {
            dbcontext = new RejestrFakturContext();
            opakPlatnoscTyp = new Opakowanie<PlatnoscTyp>(new PlatnoscTypOperacje(), dbcontext);
            obslugaDelegaty = new ObslugaDelegaty<int, Stany>();

            obslugaDelegaty.delegaty += opakPlatnoscTyp.DoEdycji;
            obslugaDelegaty.delegaty += opakPlatnoscTyp.DoPodgladu;
            obslugaDelegaty.delegaty += opakPlatnoscTyp.DoUsuniencia;
            obslugaDelegaty.delegaty += opakPlatnoscTyp.Nowy;
        }
        
        // GET: PlatnosciTyp
        public ActionResult Index()
        {
            return View();
        }
    }
}