using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Startup.TrainingOneHomeworks.IwonaM.Banks
{
    public class Transfer
    {
        public Transfer(string senderAccount, string recipientAccount)
        {
            this.SenderAccount = senderAccount;
            this.RecipientAccount = recipientAccount;
        }
        public string SenderAccount;
        public string RecipientAccount;
    }
}
