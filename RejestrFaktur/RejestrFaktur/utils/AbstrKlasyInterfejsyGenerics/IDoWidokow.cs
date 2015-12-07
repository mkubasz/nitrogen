using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RejestrFaktur.utils
{
    public interface IDoWidokow<T>
    {
        //obiekty klas implemetujących ten intefejs mają służyć jako modele przekazywane przez 
        //kontrolery do odpowiednich widoków

        IEnumerable<T> Lista { get; set; }
        T Edytowany { get; set; }
        Stany StanObiektu { get; set;}
    }
}