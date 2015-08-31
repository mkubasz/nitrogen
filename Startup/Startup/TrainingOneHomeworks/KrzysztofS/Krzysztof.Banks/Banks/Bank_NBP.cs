using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krzysztof.Banks.Banks
{
    public class Bank_NBP : Bank
    {

        public override string BankName()
        {
            return "Narodowy Bank Polski";
        }

        protected override bool MyAccount(string ABankNumber)
        {
            return ABankNumber == "1010";
        }
    }
}
