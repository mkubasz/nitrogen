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
        public virtual  Faktura Faktura { get; set; }
        public virtual Produkt Produkt { get; set; }
        public double Ilosc { get; set; }


    }
}