namespace Startup.TrainingOneHomeworks.Mati.Banks
{
    public class MBankTransactionBank : BankTransaction
    {
        public override void IncommingTransaction()
        {
            throw new System.NotImplementedException();
        }

        public override void OutCommingTransaction()
        {
            throw new System.NotImplementedException();
        }

        public string GetBankName()
        {
            throw new System.NotImplementedException();
        }

        public MBankTransactionBank(string name) : base(name)
        {
        }
    }
}