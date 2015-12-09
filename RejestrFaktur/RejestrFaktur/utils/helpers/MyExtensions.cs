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
        public static string ListaAtrubuty(this HtmlHelper html)
        {
            return "Cośtam";
        }

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