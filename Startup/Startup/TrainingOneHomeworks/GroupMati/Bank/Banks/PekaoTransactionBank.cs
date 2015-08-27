using System;

namespace Startup.TrainingOneHomeworks.Mati.Banks
{
    public class PekaoTransactionBank : BankTransaction
    {
        public override void IncommingTransaction()
        {
            throw new NotImplementedException();
        }

        public override void OutCommingTransaction()
        {
            throw new NotImplementedException();
        }

        public string GetBankName()
        {
            throw new NotImplementedException();
        }

        public PekaoTransactionBank(string name) : base(name)
        {
        }
    }
}