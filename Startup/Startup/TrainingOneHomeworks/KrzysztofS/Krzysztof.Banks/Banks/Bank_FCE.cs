using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krzysztof.Banks.Banks
{
    class Bank_FCE: Bank
    {
        public override string BankName()
        {
            return "FCE Bank Polska";
        }

        protected override bool MyAccount(string ABankNumber)
        {
            return ABankNumber == "2070";
        }
    }
}
