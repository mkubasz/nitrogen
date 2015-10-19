using RejestrFaktur.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RejestrFaktur.Models
{
    public class StawkaPodatku
    {
        public int Id { get; set; }
        [DodatkoweAtrybuty("Nazwa stawki", StanAtr.WLICZAC)]
        public string NazwaStawki { get; set; }
        public decimal WysokoscStawki { get; set; }
    }
}