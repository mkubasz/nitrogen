namespace Startup.TrainingOneHomeworks.TomaszF
{
    public abstract class Transaction
    {
        protected Transaction(string sender, string reciver, int amount)
        {
            SenderNumber = sender;
            ReceiverNumber = reciver;
            Amount = amount;
        }

        public string SenderNumber;
        public string ReceiverNumber;
        public int Amount;//wartosc przelewu
    }
}