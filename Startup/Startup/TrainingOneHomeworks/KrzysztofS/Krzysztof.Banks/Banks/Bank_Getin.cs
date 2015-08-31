using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krzysztof.Banks.Banks
{
    class Bank_Getin: Bank
    {
        public override string BankName()
        {
            return "Getin Noble Bank";
        }

        protected override bool MyAccount(string ABankNumber)
        {
            return ABankNumber == "2480";
        }

    }
}
