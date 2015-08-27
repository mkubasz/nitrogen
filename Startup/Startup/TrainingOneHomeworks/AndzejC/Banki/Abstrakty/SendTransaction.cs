namespace Startup.TrainingOneHomeworks.AndzejC.Banki.Abstrakty
{
    public abstract class SendTransaction
    {
        public abstract bool InCome(Transaction transaction);
        public abstract bool OutCome(Transaction transaction);
    }
}