using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banki.Banks;

namespace Banki.ClientClass
{
    public abstract class Transaction
    {
        protected string sender;
        protected string receiver;
        protected int amount;
        public string senderBankName;
        public string receiverBankName;
        public string operationType;

        public virtual string getSender()
        {
            return sender;
        }

        public virtual string getReceiver()
        {
            return receiver;
        }

        public virtual int getAmount()
        {
            return amount;
        }

        public abstract bool doOperation();
    }
}