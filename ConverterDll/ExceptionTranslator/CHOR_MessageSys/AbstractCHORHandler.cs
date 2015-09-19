using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExceptionTranslator.CHOR_MessageSys;

namespace ExceptionTranslator.CHOR_MessageSys
{
    public abstract class AbstractCHORHandler
    {
        protected AbstractCHORHandler next;

        public AbstractCHORHandler(AbstractCHORHandler next)
        {
            this.next = next;
        }

        public abstract string getMessage(ExceptionsPack entity);
    }
}
