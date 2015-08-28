namespace Startup.TrainingOneHomeworks.GroupMati.Bank.Factory.Interface
{
    public interface IBankTransactionFactory <T>
    {
        bool TryGetTransaction(string key, out T bankTransaction);
    }
}