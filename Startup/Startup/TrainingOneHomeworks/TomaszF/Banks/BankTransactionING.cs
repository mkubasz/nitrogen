namespace Startup.TrainingOneHomeworks.TomaszF.Banks
{
    public class BankTransactionIng : BankTransaction
    {
        protected new int Balance;
        public new string BankName = "ING";
        public override void CashIn(Transaction transaction)
        {
            Balance += transaction.Amount;
            // throw new System.NotImplementedException();
        }

        public override void CashOut(Transaction transaction)
        {
            Balance -= transaction.Amount;
        }

        public override string GetBankName()
        {
            return BankName;
        }
    }
}