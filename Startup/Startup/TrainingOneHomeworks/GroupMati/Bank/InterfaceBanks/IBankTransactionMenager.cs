using System.Collections.Generic;
using Startup.TrainingOneHomeworks.GroupMati.Bank.InterfaceBanks;

namespace Startup.TrainingOneHomeworks.GroupMati.Bank
{
    public interface IBankTransactionMenager
    {
        List<IClientTransaction> ClientTransactions { get; }
        List<List<BankTransaction>> VerifiedClientTransactions { get; }
        void VerifyTransfer();
        BankTransaction SearchAccount(string number);
    }
}