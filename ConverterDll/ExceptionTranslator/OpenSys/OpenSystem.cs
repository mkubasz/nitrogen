using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionTranslator.OpenSys
{
    public abstract class OpenSystem
    {
        protected Dictionary<int, string> elements = new Dictionary<int, string>();

        public virtual Dictionary<int, string> getList()
        {
            return elements;
        }
    }
}
