using RejestrFaktur.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RejestrFaktur.Models
{
    public class Waluta
    {
        public int Id { get; set; }
        [DodatkoweAtrybuty("Nazwa waluty", StanAtr.WLICZAC)]
        public string Nazwa { get; set; }
        [DodatkoweAtrybuty("Symbol waluty", StanAtr.WLICZAC)]
        public string Symbol { get; set; }
        public string SciezkaDoIkony { get; set; }
    }
}