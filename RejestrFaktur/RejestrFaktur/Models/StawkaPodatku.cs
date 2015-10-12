using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RejestrFaktur.Models
{
    public class StawkaPodatku
    {
        public int Id { get; set; }
        public string NazwaStawki { get; set; }
        public decimal WysokoscStawki { get; set; }
    }
}