using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krzysztof.Banks.Banks
{
    class Bank_Mercedes: Bank
    {
        public override string BankName()
        {
            return "Mercedes-Benz Bank Polska";
        }

        protected override bool MyAccount(string ABankNumber)
        {
            return ABankNumber == "1580";
        }
    }
}
