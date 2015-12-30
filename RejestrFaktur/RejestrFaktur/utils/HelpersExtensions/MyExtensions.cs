using RejestrFaktur.utils.AbstrKlasyInterfejsyGenerics;
using RejestrFaktur.utils.pozostale;

namespace RejestrFaktur.utils.HelpersExtensions
{
    public static class MyExtensions
    {

        public static bool HasText(this object obj,string txt)
        {
            return (obj.ToString().ToUpper().Contains(txt.ToUpper()));
        }

        public static bool IsPathToImgFile(this string str)
        {
            return (str.EndsWith(".jpg") || str.EndsWith(".png") || str.EndsWith(".gif") || str.EndsWith(".jpeg"));
        }
        
        
        //Rozszerzenia moich klas

        public static void DoUsuniencia<T>(this Opakowanie<T> opak, int i, Stany stan) where T : class, new()
        {
                if (stan == Stany.DO_USUNIECIA) opak.UstawDoUsuniecia(i);
        }

        public static void DoEdycji<T>(this Opakowanie<T> opak, int i, Stany stan) where T : class, new()
        {
            if (stan == Stany.DO_EDYCJI) opak.UstawDoEdycji(i);
        }

        public static void DoPodgladu<T>(this Opakowanie<T> opak, int i, Stany stan) where T : class, new()
        {
            if (stan == Stany.SZCZEGOLY) opak.UstawDoPodgladu(i);
        }

        public static void Nowy<T>(this Opakowanie<T> opak, int i, Stany stan) where T : class, new()
        {
            if (stan == Stany.NOWY) opak.UstawNowy();
        }
    }
}