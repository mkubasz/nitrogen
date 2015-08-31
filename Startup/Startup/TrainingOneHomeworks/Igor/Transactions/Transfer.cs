using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banki.ClientClass;
using Banki.Banks;

namespace Banki.Transactions
{
    public class Transfer : Transaction
    {
        protected Bank bank;

        public Transfer(string sender, string receiver, int amount, Bank bank)
        {
            this.bank = bank;

            this.operationType = "TRANSFER";
            this.receiverBankName = bank.getName();
            this.sender = sender;
            this.receiver = receiver;
            this.amount = amount;
        }

        public override bool doOperation()
        {
            if (bank.checkIfNumberIsCorrect(sender) && bank.checkIfNumberIsCorrect(receiver))
            {
                Bank receiverBank = bank.getBank(receiver);

                if (receiverBank != null)
                {
                    this.receiverBankName = receiverBank.getName();

                    return receiverBank.addTransactionToHistory(this);
                }
                else return false;
            }
            else return false;
        }
    }
}
