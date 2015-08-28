using System.Collections.Generic;
using Startup.TrainingOneHomeworks.GroupMati.Bank.InterfaceBanks;
using Startup.TrainingOneHomeworks.Mati;

namespace Startup.TrainingOneHomeworks.GroupMati.Bank
{
    public class ClientTransaction :IClientTransaction
    {
        /// <summary>
        ///  Client Ania
        /// swoj numer 13214124
        /// numer do wysalania 323412423
        /// </summary>
        public string IncomingNumber { get; set; }
        public string OutcomingNumber { get; set; }
        private List<BankTransaction> transactions;

        public ClientTransaction()
        {
            transactions = new List<BankTransaction>();

        }
        public List<BankTransaction> GetTransactions(BankTransaction bankTransaction)
        {
             if(bankTransaction != null)
            transactions.Add(bankTransaction);

            if (transactions.Count == 2 )
            {
                return transactions;
            }

            return null;
        }
    }
}