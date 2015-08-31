using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banki.ClientClass;
using Banki.Banks;

namespace Banki.Transactions
{
    public class PayIn : Transaction
    {
        protected Bank bank;

        public PayIn(string sender, int amount, Bank bank)
        {
            this.bank = bank;

            this.operationType = "PAY IN";
            this.receiverBankName = bank.getName();
            this.senderBankName = bank.getName();
            this.sender = sender;
            this.receiver = "<ACCOUNT>";
            this.amount = amount;
        }

        public override bool doOperation()
        {
            if (bank.checkIfNumberIsCorrect(sender))
            {
                return bank.addTransactionToHistory(this);
            }
            else return false;
        }
    }
}
