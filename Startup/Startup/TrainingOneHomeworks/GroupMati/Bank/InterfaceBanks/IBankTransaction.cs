namespace Startup.TrainingOneHomeworks.GroupMati.Bank.InterfaceBanks
{
    public interface IBankTransaction
    {
        void IncommingTransaction();
        void OutCommingTransaction();
        void DescriptionTransaction();
    }
}