using RejestrFaktur.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RejestrFaktur.utils
{
    public interface IOperacje<T>
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
    }
}
