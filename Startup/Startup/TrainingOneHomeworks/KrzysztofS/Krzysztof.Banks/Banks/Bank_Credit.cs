using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krzysztof.Banks.Banks
{
    class Bank_Credit: Bank
    {
        public override string BankName()
        {
            return "Credit Agricole Bank Polska";
        }

        protected override bool MyAccount(string ABankNumber)
        {
            return ABankNumber == "1940";
        }
    }
}
