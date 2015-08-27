using System.Collections.Generic;

namespace Startup.TrainingOneHomeworks.Mati.InterfaceBanks
{
    public interface IBankTransactionFactory <T>
    {
        bool TryGetTransaction(string key, out T bankTransaction);
        
    }
}