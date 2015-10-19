using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using System.Web;

namespace RejestrFaktur.Models
{
    public class FakturaSzczegoly
    {
        public int Id { get; set; }
        public int Ilosc { get; set; }
        public decimal WartoscNetto { get; set; }
        public decimal WartoscBrutto { get; set; }
        public decimal WartoscVat { get; set; }
        public decimal StawkaVat { get; set; }
        public string PKWIU { get; set; }


    }
}