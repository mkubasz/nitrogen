using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace RejestrFaktur.utils
{
    //klasa do przetwarzania atrybutów z klasy DodatkoweAtrybuty
    public class CzytaczAnotacji
    {
        public static List<string> WypiszWszystkieAtrubutyNazwa(StanAtr stan,object obj)
        {
            Type type = obj.GetType();
            List<string> lista = new List<string>();
            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo p in properties)
            {
                IEnumerable<DodatkoweAtrybuty> listaAtr = p.GetCustomAttributes<DodatkoweAtrybuty>();

                foreach (DodatkoweAtrybuty dA in listaAtr)
                {
                    if (dA.Stan.Equals(stan))
                    {
                        lista.Add(dA.Nazwa);
                    }
                }

            }
            return lista;
        }

        public static List<DodatkoweAtrybuty> WypiszWszystkieAtrybuty(StanAtr stan, object obj)
        {
            Type type = obj.GetType();
            List<DodatkoweAtrybuty> lista = new List<DodatkoweAtrybuty>();
            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo p in properties)
            {
                IEnumerable<DodatkoweAtrybuty> listaAtr = p.GetCustomAttributes<DodatkoweAtrybuty>();

                foreach (DodatkoweAtrybuty dA in listaAtr)
                {
                    if (dA.Stan.Equals(stan))
                    {
                        lista.Add(dA);
                    }
                }

            }
            return lista;
        }


        public static string TypNazwa(object obj)
        {
            return obj.GetType().ToString();
        }
    }
}