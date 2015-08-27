using System;
using System.Collections.Generic;
using Startup.TrainingOneHomeworks.TomaszF.Banks;

namespace Startup.TrainingOneHomeworks.TomaszF
{
    public class TransactionMenager : Transaction
    {
        public TransactionMenager(string sender, string reciver, int amount) : base(sender, reciver, amount)
        {
            SenderNumber = sender;
            ReceiverNumber = reciver;
            Amount = amount;
        }

        protected new Dictionary<string, BankTransaction> BankList = new Dictionary<string, BankTransaction>()
        {
            {"1020", new BankTransactionPkoBp()},
            {"1050", new BankTransactionIng()}
        };

        private List<Transaction> list = new List<Transaction>()
        {
            new TransactionMenager("83102014690081781398000000","83105004690081781398000000", 150),
            new TransactionMenager("83102014690081781398000001","83105014690081781398000001", 200),
            new TransactionMenager("83105014690081781398000000","83102014690081781398000000", 250),
            new TransactionMenager("83105014690081781398000001","83102014690081781398000001", 300)
        };


        public void WszystkiePrzelewy(List<Transaction> transactions)
        {
            foreach (var item in transactions)
            {
                var sourceNbr = item.SenderNumber;
                string controlSourceNumber = TakeBankControlNumber(sourceNbr);
                var recieverNbr = item.ReceiverNumber;
                string controlReceiverNumber = TakeBankControlNumber(recieverNbr);

                BankTransaction bankInstancionSender;
                BankTransaction bankInstancionReciver;
                //tworzenie na IFach instancji chyba bym zrobil
                if (BankList.TryGetValue(controlSourceNumber, out bankInstancionSender) && BankList.TryGetValue(controlReceiverNumber, out bankInstancionReciver))
                {
                    var tr = bankInstancionSender;//utworze w takie sposob instancje obiektu?
                    tr.CashOut(item);
                    var tr2 = bankInstancionReciver;
                    tr2.CashIn(item);
                }
            }
            throw new NotImplementedException();
        }

        public string TakeBankControlNumber(string number)
        {
            //   string numberString = number.ToString();
            string num = number.Substring(2, 4);
            return num;
        }



    }
}