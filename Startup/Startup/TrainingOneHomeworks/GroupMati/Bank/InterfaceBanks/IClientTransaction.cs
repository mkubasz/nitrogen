using System.Collections.Generic;

namespace Startup.TrainingOneHomeworks.GroupMati.Bank.InterfaceBanks
{
    public interface IClientTransaction
    {
        string IncomingNumber { get; set; }
        string OutcomingNumber { get; set; }
        List<BankTransaction> GetTransactions(BankTransaction bankTransaction);
    }
}