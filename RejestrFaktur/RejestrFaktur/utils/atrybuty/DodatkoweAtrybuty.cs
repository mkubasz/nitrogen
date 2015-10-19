using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RejestrFaktur.utils
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class DodatkoweAtrybuty : Attribute
    {
        public DodatkoweAtrybuty(string nazwa)
        {
            Nazwa = nazwa;
        }

        public DodatkoweAtrybuty(string nazwa, StanAtr stan) : this(nazwa)
        {
            Stan = stan;
        }


        public string Nazwa { get; set; }

        public StanAtr Stan { get; set; }

        public string Dodatkowy { get; set; }
    }

    public enum StanAtr
    {
        WLICZAC = 1,
        POMIJAC = 2
    }

}