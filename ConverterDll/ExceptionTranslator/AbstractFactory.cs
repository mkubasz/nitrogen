using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionTranslator
{
    public abstract class AbstractFactory<T, T1>
    {
        protected Dictionary<T, Func<T1>> elements = new Dictionary<T, Func<T1>>();

        public T1 getElement(T key)
        {
            return (elements.ContainsKey(key) ? elements[key]() : default(T1));
        }
    }
}