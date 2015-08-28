namespace Startup.TrainingOneHomeworks.GroupMati.Bank.Messages.Interface
{
    public interface IMailMessages
    {
        void SendMail(BankMailEnum bankMailEnum,string to);
        string GetSubject(BankMailEnum bankMailEnum);
        string GetBody(BankMailEnum bankMailEnum);
    }
}