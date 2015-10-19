using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace RejestrFaktur.Models
{
    public class Faktura
    {
        public int Id { get; set; }
        public string Numer { get; set; }
        public DateTime DataWystawienia { get; set; }
        public Klient Klient { get; set; }
        public Firma Firma { get; set; }
        public string Wystawiajacy { get; set; }
        public bool Stan { get; set; } //jeśli false mysle o tym ze zostala anulowana.


       
    }
}