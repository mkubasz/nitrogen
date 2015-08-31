using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krzysztof.Banks.Banks
{
    class Bank_Societe: Bank
    {
        public override string BankName()
        {
            return "Societe Generale";
        }

        protected override bool MyAccount(string ABankNumber)
        {
            return ABankNumber == "1840";
        }
    }
}
