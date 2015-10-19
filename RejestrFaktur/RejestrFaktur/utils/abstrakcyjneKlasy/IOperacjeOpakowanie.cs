using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RejestrFaktur.utils
{
    public interface IOperacjeOpakowanie<T>
    {
        T ZnajdzPoId(IEnumerable<T> kolekcjaOb, int id);
        T ZnajdzTakiSam(IEnumerable<T> kolekcjaOb,T t);
        //T ZnajdzObiektPoAtrybucie(IEnumerable<T> kolekcjaOb, string nazwa, object wartosc);
    }
}
