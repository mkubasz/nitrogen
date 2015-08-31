using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krzysztof.Banks.Banks
{
    class Bank_VW: Bank
    {
        public override string BankName()
        {
            return "Volkswagen Bank";
        }

        protected override bool MyAccount(string ABankNumber)
        {
            return ABankNumber == "2130";
        }
    }
}
