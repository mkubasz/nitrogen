using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionTranslator
{
    public abstract class AbstractFactory<T, T1>
    {
        protected Dictionary<T, Func<T1>> Elements = new Dictionary<T, Func<T1>>();

        public T1 GetElement(T key)
        {
            return (Elements.ContainsKey(key) ? Elements[key]() : default(T1));
        }
    }
}