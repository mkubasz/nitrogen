using System;

namespace Startup.TrainingOneHomeworks.Mati.Banks
{
    public class IngTransactionBank : BankTransaction
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

        public IngTransactionBank(string name) : base(name)
        {
        }
    }
}