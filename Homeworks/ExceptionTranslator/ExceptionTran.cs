using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionTranslator
{
    public class ExceptionTran : Exception // Logika - przyjmuje enuma, zwraca string message
    {
        protected static ExceptionFactoryXml ExceptionList = new ExceptionFactoryXml();

        public ExceptionTran(ExceptionsPack entity) : base(getMessage(entity)) { }

        protected static string getMessage(ExceptionsPack entity)
        {
            return ExceptionList.getElement((int)entity);
        }
    }
}