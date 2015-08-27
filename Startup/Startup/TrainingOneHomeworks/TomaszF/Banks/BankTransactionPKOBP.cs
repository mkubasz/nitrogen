namespace Startup.TrainingOneHomeworks.TomaszF.Banks
{
    public class BankTransactionPkoBp : BankTransaction
    {

        protected new int Balance;
        public new string BankName = "PKO BP";
        public override void CashIn(Transaction transaction)
        {
            Balance += transaction.Amount;
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