using System.Collections.Generic;

namespace Startup.TrainingOneHomeworks.Mati.InterfaceBanks
{
    public interface IClientTransaction
    {
         string IncomingNumber { get; set; }  // 1111 3234234234
         string OutcomingNumber { get; set; }
         List<BankTransaction> GetTransactions();
         string GetNrbNumber(string number);
        BankTransaction SearchAccount(string number, Dictionary<string, BankTransaction> bankTransactions);



    }
}