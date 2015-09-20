using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionTranslator.CHOR_MessageSys
{
    public class TestHandlerTwo : AbstractCHORHandler
    {
        public TestHandlerTwo(AbstractCHORHandler next=null) : base(next) { }

        public override string getMessage(ExceptionsPack entity)
        {
            if (entity != null)
            {
                if (entity == ExceptionsPack.Test2) return "TestHandlerTwo";
                else if (this.next != null) this.next.getMessage(entity);
            }
            return "Nie znaleziono handlera, który potrafiłby obsłużyć żądanie.";
        }
    }
}
