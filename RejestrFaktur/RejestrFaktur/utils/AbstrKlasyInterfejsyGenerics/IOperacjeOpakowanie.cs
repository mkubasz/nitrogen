using RejestrFaktur.utils.pozostale;

namespace RejestrFaktur.utils.AbstrKlasyInterfejsyGenerics
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
