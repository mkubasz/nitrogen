using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RejestrFaktur.Models
{
    public partial class PlatnoscTyp
    {
        public PlatnoscTyp()
        {
        }

        public int id { get; set; }
        public string nazwa { get; set; }
        public string opis { get; set; }
    }
}