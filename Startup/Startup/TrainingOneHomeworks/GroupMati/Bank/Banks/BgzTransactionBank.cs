using System;

namespace Startup.TrainingOneHomeworks.Mati.Banks
{
    public sealed class BgzTransactionBank : BankTransaction
    {
        private const string bankName = "Bank BGZ";

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
            return bankName;
        }

        public BgzTransactionBank(string name) : base(name)
        {
        }
    }
}