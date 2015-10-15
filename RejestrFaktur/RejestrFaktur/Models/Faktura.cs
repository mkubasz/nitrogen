using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RejestrFaktur.Models
{
    public class Faktura
    {
        public int Id { get; set; }
        public string Numer { get; set; }
        public DateTime DataWystawienia { get; set; }
        public DateTime DataSprzedazy { get; set; }
        public decimal walutaKurs  { get; set; }
        public DateTime DataZaplaty { get; set; }


    }
}