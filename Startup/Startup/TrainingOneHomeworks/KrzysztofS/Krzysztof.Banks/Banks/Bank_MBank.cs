using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krzysztof.Banks.Banks
{
    class Bank_MBank: Bank
    {
        public override string BankName()
        {
            return "mBank";
        }

        protected override bool MyAccount(string ABankNumber)
        {
            return ABankNumber == "1140";
        }
    }
}
