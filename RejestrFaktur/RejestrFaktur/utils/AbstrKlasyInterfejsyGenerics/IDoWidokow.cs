using System.Collections.Generic;
using RejestrFaktur.utils.pozostale;

namespace RejestrFaktur.utils.AbstrKlasyInterfejsyGenerics
{
    public interface IDoWidokow<T>
    {
        /**
          Obiekty klas implemetujących ten intefejs mają służyć jako modele przekazywane przez 
          kontrolery do odpowiednich widoków
        **/

        IEnumerable<T> Lista { get; set; }
        T Edytowany { get; set; }
        Stany StanObiektu { get; set;}
    }
}