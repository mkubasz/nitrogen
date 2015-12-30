using System.Collections.Generic;
using RejestrFaktur.DAL;
using RejestrFaktur.utils.pozostale;

namespace RejestrFaktur.utils.AbstrKlasyInterfejsyGenerics
{
    public interface IOperacje<T> where T:class,new()
    {
        /**Interfejs zawiera operacje, które są wstrzykiwane do klasy Opakowanie.
        Operacje te mają pomóc w wykonaniu operacji określonych w interfejsie 
        IOperacjeOpakowanie
        **/

        T ZnajdzPoId(IEnumerable<T> kolekcjaOb, int id);
        bool Ustaw(ObiektDoWidoku<T> obiektDW, Stany stan, int id);
        bool UstawNowy(ObiektDoWidoku<T> obiektDW);
        void UstawPoczatkowe(ObiektDoWidoku<T> obiektDW,RejestrFakturContext dbcontext);
        void UstawPoczatkowe(ObiektDoWidoku<T> obiektDW,IEnumerable<T> lista);
        bool Edytuj(T t, RejestrFakturContext dbcontext);
        int  Dodaj(T t, RejestrFakturContext dbcontext);
        bool Usun(T t, RejestrFakturContext dbcontext);
        List<T> Wyszukaj(IEnumerable<T> kolekcjaOb,string attributeName, string szukanyTxt);
    }
}
