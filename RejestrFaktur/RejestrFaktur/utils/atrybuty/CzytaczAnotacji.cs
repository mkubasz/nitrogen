using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace RejestrFaktur.utils.atrybuty
{
    //klasa do przetwarzania atrybutów z klasy DodatkoweAtrybuty
    public class CzytaczAnotacji
    {
        public static List<string> WypiszWszystkieAtrybutyNazwa(StanAtr stan,object obj)
        {
            if (obj != null)
            {
                Type type = obj.GetType();
                PropertyInfo[] properties = type.GetProperties();
                return (from p in properties from dA in p.GetCustomAttributes<DodatkoweAtrybuty>() where dA.Stan.Equals(stan) select dA.Nazwa).ToList();
            }
            return null;
        }

        public static List<DodatkoweAtrybuty> WypiszWszystkieAtrybuty(StanAtr stan, object obj)
        {
            if (obj != null)
            {
                Type type = obj.GetType();
                PropertyInfo[] properties = type.GetProperties();

                return (from p in properties
                        from dA in p.GetCustomAttributes<DodatkoweAtrybuty>()
                        where dA.Stan.Equals(stan)
                        select dA).ToList();

            }
            return null;
        }
    }
}