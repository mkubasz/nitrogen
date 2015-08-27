using System.Collections.Generic;

namespace Startup.TrainingOneHomeworks.AndzejC.Banki
{
    public class TransactionMenager
    {
        private readonly BankList2 _banks = new BankList2();
        protected List<Transaction> TransferList;

        public void SendTransfers()
        {
            foreach (var item in TransferList)
            {
                //sender
                _banks.GetElement(item.SenderAccNumber.Substring(2, 4)).OutCome(item);
                //receiver
                _banks.GetElement(item.ReceiverAccNumber.Substring(2, 4)).InCome(item);
            }
        }
    }
}