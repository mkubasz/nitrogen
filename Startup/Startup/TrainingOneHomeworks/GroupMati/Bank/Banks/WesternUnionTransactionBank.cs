﻿using System;

namespace Startup.TrainingOneHomeworks.Mati.Banks
{
    public class WesternUnionTransactionBank : BankTransaction
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

        public WesternUnionTransactionBank(string name) : base(name)
        {
        }
    }
}