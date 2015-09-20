﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionTranslator
{
    public class ExceptionTran : Exception // Logika - przyjmuje enuma, zwraca string message
    {
        public string Message {get; protected set;}
        protected ExceptionFactoryXml ExceptionList = new ExceptionFactoryXml();

        public ExceptionTran(ExceptionsPack entity)
        {
            this.Message = getMessage(entity);
        }

        protected string getMessage(ExceptionsPack entity)
        {
            return ExceptionList.getElement((int)entity);
        }
    }
}
