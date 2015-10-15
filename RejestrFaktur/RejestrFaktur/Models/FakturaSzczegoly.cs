using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RejestrFaktur.Models
{
    public class FakturaSzczegoly
    {
        public int ID  { get; set; }
        public int ilosc { get; set; }
        public decimal wartoscNetto { get; set; }
        public decimal wartoscBrutto { get; set; }
        public decimal wartoscVat { get; set; }
        public decimal stawkaVat { get; set; }
        public string PKWIU { get; set; }
    }
}