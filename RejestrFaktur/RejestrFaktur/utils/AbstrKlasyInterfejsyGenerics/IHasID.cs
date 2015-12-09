using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RejestrFaktur.utils
{
    public interface IHasID
    {
        /**
           Intefrejs potrzebny aby klasa GeneryczneOperacje poprawnie działała.
        **/
        int Id {get;set;}
    }
}
