using RejestrFaktur.utils;
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

        public int Id { get; set; }
        [DodatkoweAtrybuty("Nazwa sposobu płatności",StanAtr.WLICZAC,Dodatkowy = "nazwa")]
        public string Nazwa { get; set; }
        [DodatkoweAtrybuty("Opis sposobu płatności",Stan =StanAtr.WLICZAC,Dodatkowy ="opis")]
        public string Opis { get; set; }

        public override bool Equals(object obj)
        {
            PlatnoscTyp pt;
            if (obj != null && obj is PlatnoscTyp)
            {
                pt = (PlatnoscTyp)obj;
                return ((pt.Id == this.Id) && (pt.Nazwa == this.Nazwa) && (pt.Opis == this.Opis));
            }
            else
            {
                return false;
            }

        }

        public override int GetHashCode()
        {
            int hash = 13;
            hash = (hash * 7) + Id.GetHashCode();
            hash = (hash * 7) + Nazwa.GetHashCode();
            hash = (hash * 7) + Opis.GetHashCode();
            return hash;
        }

    }
}