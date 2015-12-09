using RejestrFaktur.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RejestrFaktur.utils
{
    public interface IOperacjeOpakowanie<T>
    {
        /**Podstawowe operacje wykonywane na danych**/

        bool UstawDoEdycji(int id);
        bool UstawDoPodgladu(int id);
        bool UstawDoUsuniecia(int id);
        bool UstawNowy(); 
        bool DodajObiekt(T t);
        bool UsunObiekt(T t);
        bool EdytujObiekt(T t);
        bool ZapiszObiekt(T t, Stany stan);    
    }
}
