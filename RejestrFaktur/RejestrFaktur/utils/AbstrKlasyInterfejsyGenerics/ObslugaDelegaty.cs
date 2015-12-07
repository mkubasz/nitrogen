using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RejestrFaktur.utils
{
    public class ObslugaDelegaty<T,V>
    {
        public Action<T, V> delegaty;

        public void Obsluz(T t, V v)
        {
            delegaty(t, v);
        }
    }
}