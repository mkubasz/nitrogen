using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExceptionTranslator.CHOR_MessageSys;

namespace ExceptionTranslator
{
    public class ExceptionTranslator : Exception // Logika - przyjmuje enuma, zwraca string message
    {
        public string Message {get; protected set;}

        public ExceptionTranslator(ExceptionsPack entity)
        {
            this.Message = getMessage(entity);
        }

        static string getMessage(ExceptionsPack entity)
        {
            LinkedList<AbstractCHORHandler> Handlers = new LinkedList<AbstractCHORHandler>();
            Handlers.AddFirst(new TestHandlerOne());
            Handlers.AddFirst(new TestHandlerTwo(Handlers.ElementAt(0)));
            return Handlers.ElementAt(Handlers.Count() - 1).getMessage(entity);
        }
    }
}
