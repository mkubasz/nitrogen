using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banki.ClientClass;
using Banki.Banks;

namespace Banki.Transactions
{
    public class PayOut : Transaction
    {
        protected Bank bank;

        public PayOut(string receiver, int amount, Bank bank)
        {
            this.bank = bank;

            this.operationType = "PAY OUT";
            this.receiverBankName = bank.getName();
            this.senderBankName = bank.getName();
            this.sender = "<CLIENT>";
            this.receiver = receiver;
            this.amount = amount;
        }

        public override bool doOperation()
        {
            if (bank.checkIfNumberIsCorrect(receiver))
            {
                return bank.addTransactionToHistory(this);
            }
            else return false;
        }
    }
}
