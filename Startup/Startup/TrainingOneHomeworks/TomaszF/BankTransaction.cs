namespace Startup.TrainingOneHomeworks.TomaszF
{
    public abstract class BankTransaction
    {
        public string BankName;
        public abstract void CashIn(Transaction transaction);
        public abstract void CashOut(Transaction transaction);//odnotuj wpływ
        protected int Balance;
        public abstract string GetBankName();
    }
}