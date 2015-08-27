using Startup.TrainingOneHomeworks.Mati.InterfaceBanks;

namespace Startup.TrainingOneHomeworks.Mati
{
    public class BankTransactionMenager : IBankTransactionMenager
    {
        public string incomingBank;
        public string outcomingBank;


        public IClientTransaction ClientTranstaction { get; set; }
        public IBankTransaction BankTransaction { get; set; }
        public bool VerifyTransfer()
        {
            throw new System.NotImplementedException();
        }
    }
}