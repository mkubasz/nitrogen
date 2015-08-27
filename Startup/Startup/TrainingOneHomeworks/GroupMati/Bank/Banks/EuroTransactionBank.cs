namespace Startup.TrainingOneHomeworks.Mati.Banks
{
    public class EuroTransactionBank : BankTransaction
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

        public EuroTransactionBank(string name) : base(name)
        {
        }
    }
}