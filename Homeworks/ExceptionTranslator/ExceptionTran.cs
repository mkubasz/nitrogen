using System;

namespace ExceptionTranslator
{
    public class ExceptionTran : Exception // Logika - przyjmuje enuma, zwraca string message
    {
        protected static ExceptionFactoryXml ExceptionList = new ExceptionFactoryXml();

        public ExceptionTran(ExceptionsPack entity) : base(GetMessage(entity)) { }

        protected static string GetMessage(ExceptionsPack entity)
        {
            return ExceptionList.GetElement((int)entity);
        }
    }
}