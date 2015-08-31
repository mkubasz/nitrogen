using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krzysztof.Banks
{
    public interface IBank
    {
        string  BankName();
        Address BankAddress();
//        Account AccontInfo();
//        bool MoneyTransfer(Account FromAccount, Account ToAccount);
    }
}
