using System.Net.Mail;
using System.Security;

namespace Startup.TrainingOneHomeworks.Mati.Messages
{
    public abstract class MailMessages : IMailMessages
    {
        private MailMessage mailMessage;
        private SmtpClient smtpClient = new SmtpClient();

        protected MailMessages(string from , string host, int port) 
        {
            mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(from);
            smtpClient.Host = host;
            smtpClient.Port = port;
            
        }

        public void SendMail(BankMailEnum bankMailEnum,string to)
        {
            mailMessage.To.Add(to);
            mailMessage.Subject = GetSubject(bankMailEnum);
            mailMessage.Body = GetBody(bankMailEnum);
            smtpClient.Send(this.mailMessage);
        }

        public abstract string GetSubject(BankMailEnum bankMailEnum);
        public abstract string GetBody(BankMailEnum bankMailEnum);


    }
}