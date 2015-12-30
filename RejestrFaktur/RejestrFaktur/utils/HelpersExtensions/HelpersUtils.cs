using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Web.Routing;
using RejestrFaktur.utils.atrybuty;
using RejestrFaktur.utils.pozostale;

namespace RejestrFaktur.utils.HelpersExtensions
{
    public static class HelpersUtils
    {

        /*Metody pomocnicze do helperów
        */

        public static string WypiszAtrybutyObiektu(object obj,bool opcjaWszystkie=false)
        {
            /*zamienia atrybuty obiektu na tagi option z 
              odpowiednimi wartosciami
            */
            StringBuilder sBuilder = new StringBuilder("");
            List<DodatkoweAtrybuty> listaDodAtr = CzytaczAnotacji.WypiszWszystkieAtrybuty(StanAtr.WLICZAC, obj);
            if (listaDodAtr != null && listaDodAtr.Any())
            {
                if (opcjaWszystkie)
                {
                    sBuilder.AppendFormat("<option value =\"{0}\">{1}</option>", Stale.WSZYSTKIE, Stale.WSZYSTKIE);
                }

                foreach (var dodAtr in listaDodAtr)
                {
                    sBuilder.AppendFormat("<option value =\"{0}\">{1}</option>", dodAtr.Dodatkowy, dodAtr.Nazwa);
                }
            }
            return sBuilder.ToString();
        }

        public static string WyliczHtmlAttributes(object htmlAttributes)
        {
            /*zamienia obj klasy IDictionary<string,Object> na lancuch znakow
            tak sformatowany jak atrybuty znacznika HTML tj. nazwa="wartosc" gdzie
            nazwa klucz klasy string, wartosc to Object.ToString()  
            */
            RouteValueDictionary atr;
            StringBuilder sBuilder = new StringBuilder("");
            if (htmlAttributes != null)
            {
                atr = new RouteValueDictionary(htmlAttributes);
                foreach (var elem in atr)
                {
                    sBuilder.AppendFormat(" {0}=\"{1}\"", elem.Key, elem.Value);
                }
                sBuilder.Append(" ");
            }
            return sBuilder.ToString();
        }



        public static IEnumerable<string> WypiszWszystkiePliki(string sciezkaDoPlikow)
        {
            try
            {
                return Directory.EnumerateFiles(sciezkaDoPlikow);
            }
            catch (Exception)
            {
                return new List<string>();
            }
        }

        public static IEnumerable<string> WypiszPlikiGrafika(string sciezkaDoPlikow)
        {
            try
            {
               return Directory.EnumerateFiles(sciezkaDoPlikow).ToList().Where(s => s.IsPathToImgFile());
            }
            catch (Exception)
            {
                return new List<string>();
            }
        }
    }
}