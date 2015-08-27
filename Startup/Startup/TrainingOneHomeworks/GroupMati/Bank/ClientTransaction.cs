using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using Startup.TrainingOneHomeworks.Mati.Banks;
using Startup.TrainingOneHomeworks.Mati.InterfaceBanks;

namespace Startup.TrainingOneHomeworks.Mati
{
    public class ClientTransaction :IClientTransaction
    {

        public string IncomingNumber { get; set; }
        public string OutcomingNumber { get; set; }

        public List<BankTransaction> GetTransactions()
        {
            List<BankTransaction> temporaryBanks = new List<BankTransaction>();
            temporaryBanks.Add(SearchAccount(GetNrbNumber(IncomingNumber),new Dictionary<string, BankTransaction>()));
            temporaryBanks.Add(SearchAccount(GetNrbNumber(OutcomingNumber), new Dictionary<string, BankTransaction>()));
            if (temporaryBanks.Count == 2 
                || ValidationNumber.Validation(OutcomingNumber) 
                || ValidationNumber.Validation(IncomingNumber))
            {
                return null;
            }

            return temporaryBanks;
              
        }
        public string GetNrbNumber(string number)
        {   if(number != null)
                return number.Substring(2, 4);
            return null;
        }

        public BankTransaction SearchAccount(string number, Dictionary<string, BankTransaction> bankList)
        {
            if (number == null)
                return null;
            BankTransaction bank;
            foreach (var item in bankList)
            {
                if (bankList.TryGetValue(number, out bank))
                    return bank;
            }
            return null;

        }

    }
}