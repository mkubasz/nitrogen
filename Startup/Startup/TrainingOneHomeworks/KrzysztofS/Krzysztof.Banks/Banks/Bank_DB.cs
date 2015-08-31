using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krzysztof.Banks.Banks
{
    class Bank_DB: Bank
    {
        public override string BankName()
        {
            return "Deutsche Bank Polska";
        }

        protected override bool MyAccount(string ABankNumber)
        {
            return ABankNumber == "1910";
        }
    }
}
