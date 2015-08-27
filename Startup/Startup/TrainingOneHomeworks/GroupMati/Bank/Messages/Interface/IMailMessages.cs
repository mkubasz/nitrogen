namespace Startup.TrainingOneHomeworks.Mati.Messages
{
    public interface IMailMessages
    {
        void SendMail(BankMailEnum bankMailEnum,string to);
        string GetSubject(BankMailEnum bankMailEnum);
        string GetBody(BankMailEnum bankMailEnum);
    }
}