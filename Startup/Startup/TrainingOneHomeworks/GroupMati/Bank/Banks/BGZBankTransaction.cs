    using System;
    using Startup.TrainingOneHomeworks.Mati;
    namespace Startup.TrainingOneHomeworks.GroupMati.Bank.Banks
    {
        public sealed class BGZTransactionBank : BankTransaction
        {
            public BGZTransactionBank() : base("BGZ Bank")
            {
            }
            public void DescriptionTransaction()
            {
                base.DescriptionTransaction();
            }
            public string GetBankName(string name)
            {
                return BankName;
            }
            public override void IncommingTransaction()
            {
                throw new NotImplementedException();
            }
            public override void OutCommingTransaction()
            {
                throw new NotImplementedException();
            }
        }
    }
