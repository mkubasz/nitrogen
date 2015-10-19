using RejestrFaktur.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RejestrFaktur.Models
{
    public class JednostkaMiary
    {
        public JednostkaMiary()
        {
        }

        public int Id { get; set; }
        [DodatkoweAtrybuty("Nazwa jednostki miary", StanAtr.WLICZAC,Dodatkowy = "nazwa")]
        public string NazwaJednostki { get; set; }
        public string SymbolJednostki { get; set; }

        public override bool Equals(object obj)
        {
            JednostkaMiary j;
            if (obj != null && obj is JednostkaMiary)
            {
                j = (JednostkaMiary)obj;
                return ((j.Id == this.Id) && (j.NazwaJednostki == this.NazwaJednostki) && (j.SymbolJednostki == this.SymbolJednostki));
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
            hash = (hash * 7) + NazwaJednostki.GetHashCode();
            hash = (hash * 7) + SymbolJednostki.GetHashCode();
            return hash;
        }
    }
}
