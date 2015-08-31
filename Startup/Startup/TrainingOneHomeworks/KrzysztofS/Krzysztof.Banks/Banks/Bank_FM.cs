using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krzysztof.Banks.Banks
{
    class Bank_FM: Bank
    {
        public override string BankName()
        {
            return "FM Bank PBP";
        }

        protected override bool MyAccount(string ABankNumber)
        {
            return ABankNumber == "1870";
        }
    }
}
