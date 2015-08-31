using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Krzysztof.Banks.Banks;
using System.Text.RegularExpressions;

namespace Krzysztof.Banks
{
    public abstract class Bank: IBank
    {
        protected abstract bool MyAccount(string ABankNumber);
        public abstract string BankName();

        public Address BankAddress()
        {
            throw new NotImplementedException();
        }

        public bool IsMyAccount(string Account)
        {
            string bankNumber = Account.Substring(2, 4);
            return MyAccount(bankNumber);
            
        }
    }
}
