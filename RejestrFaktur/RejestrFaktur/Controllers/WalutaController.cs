using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RejestrFaktur.DAL;
using RejestrFaktur.Models;
using RejestrFaktur.utils;
using Extensions;
using System.Web.Mvc;

namespace RejestrFaktur.Controllers
{
    public class WalutaController : Controller
    {

        private RejestrFakturContext dbcontext;
        private Opakowanie<Waluta> opakWaluta;
        private ObslugaDelegaty<int, Stany> obslugaDelegaty;

        public WalutaController()
        {
            dbcontext = new RejestrFakturContext();
            opakWaluta = new Opakowanie<Waluta>(new WalutaOperacje(), dbcontext);
            obslugaDelegaty = new ObslugaDelegaty<int, Stany>();

            obslugaDelegaty.delegaty += opakWaluta.DoEdycji;
            obslugaDelegaty.delegaty += opakWaluta.DoPodgladu;
            obslugaDelegaty.delegaty += opakWaluta.DoUsuniencia;
            obslugaDelegaty.delegaty += opakWaluta.Nowy;
        }


        // GET: Waluta
        public ActionResult Index()
        {
            return View();
        }
    }
}