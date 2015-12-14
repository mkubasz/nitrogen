using RejestrFaktur.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Extensions
{
    public static class MyExtensions
    {
        public static MvcHtmlString ListaAtrybuty(this HtmlHelper html,string nazwa,Object obj)
        {
            string s="";
            List<DodatkoweAtrybuty> listaDodAtr = CzytaczAnotacji.WypiszWszystkieAtrybuty(StanAtr.WLICZAC, obj);
            
            if (listaDodAtr.Any())
            {
                s += "<select name =\"" + nazwa + "\">";
                foreach (var  dodAtr in listaDodAtr)
                {
                    s += "<option value =\"" + dodAtr.Dodatkowy + "\">" +dodAtr.Nazwa+ "</option>";
                }
                s += "</select>";
            }
            return  MvcHtmlString.Create(s);
        }

        //---- 
        public static void DoUsuniencia<T>(this Opakowanie<T> opak, int i, Stany stan) where T : new()
        {
                if (stan == Stany.DO_USUNIECIA) opak.UstawDoUsuniecia(i);
        }

        public static void DoEdycji<T>(this Opakowanie<T> opak, int i, Stany stan) where T : new()
        {
            if (stan == Stany.DO_EDYCJI) opak.UstawDoEdycji(i);
        }

        public static void DoPodgladu<T>(this Opakowanie<T> opak, int i, Stany stan) where T : new()
        {
            if (stan == Stany.SZCZEGOLY) opak.UstawDoPodgladu(i);
        }

        public static void Nowy<T>(this Opakowanie<T> opak, int i, Stany stan) where T : new()
        {
            if (stan == Stany.NOWY) opak.UstawNowy();
        }



    }
}