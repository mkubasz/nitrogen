using System;
using System.CodeDom.Compiler;
using System.Linq;
using Startup.TrainingOneHomeworks.GroupMati.Bank.InterfaceBanks;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using Startup.TrainingOneHomeworks.GroupMati.Bank.Factory;

namespace Startup.TrainingOneHomeworks.GroupMati.Bank
{
    public class BankTransactionMenager : IBankTransactionMenager
    {

        private FactoryTransactionBank factory = new FactoryTransactionBank();

        private List<IClientTransaction> _clientTransactions; 
        public List<IClientTransaction> ClientTransactions => _clientTransactions;
        private List<List<BankTransaction>> _verifiedClientTransactions;
        public List<List<BankTransaction>> VerifiedClientTransactions
        {
            get {
                VerifyTransfer();
                return _verifiedClientTransactions;
                }
        }
        public BankTransactionMenager()
        {
            _clientTransactions = new List<IClientTransaction>();
        }
        public BankTransactionMenager(IClientTransaction client)
        {
            _clientTransactions = new List<IClientTransaction>();
            ClientTransactions.Add(client);
        }

        // GetNrbNumber -> SearchNumber -> VerifyTransfer
        public void VerifyTransfer()
        {
            BankTransaction bank;
            _verifiedClientTransactions = new List<List<BankTransaction>>();
            foreach (var client in _clientTransactions)
            {
                if ((bank = SearchAccount(client.OutcomingNumber))!=null )
                {
                    client.GetTransactions(bank);
                    if ((bank = SearchAccount(client.IncomingNumber)) != null)
                    {
                        VerifiedClientTransactions.Add(client.GetTransactions(bank));
                    }
                }
               
            }
        }

        private string GetNrbNumber(string number)
        {
                return number.Substring(2, 4);
        }

        public BankTransaction SearchAccount(string number)
        {
            if (!ValidationNumber.Validation(number))
            {
                return null;
            }
            BankTransaction tmp;
            string shortNumber = GetNrbNumber(number);
            tmp = factory.GetItem(shortNumber);
            return tmp;
        }

    }
}