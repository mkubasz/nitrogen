﻿using System;

namespace RejestrFaktur.utils.atrybuty
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