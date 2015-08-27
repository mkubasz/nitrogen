using System.Security.Cryptography.X509Certificates;

namespace Startup.TrainingOneHomeworks.Mati.InterfaceBanks
{
    public interface IBankTransactionMenager
    {
        IClientTransaction ClientTranstaction { get; set; }
        IBankTransaction BankTransaction { get; set; }
        bool VerifyTransfer();
    }
}