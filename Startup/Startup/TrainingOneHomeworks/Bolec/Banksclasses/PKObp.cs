using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Startup.TrainingOneHomeworks.Bolec;
using Startup.TrainingOneHomeworks.Bolec.Interface;

namespace Startup.TrainingOneHomeworks.Bolec
{
    public class PKObp : UserAccount
   
    {
        public void PKObp_Debit(string senderAccountNo, int amount)
        {
            UserAccount UserAccount1 = new UserAccount();
            UserAccount1.DecreaseBalance(amount);
        }

        public void PKObp_Credit(string receiverAccountNo, int amount)
        {
            UserAccount UserAccount2 = new UserAccount();
          
            UserAccount2.IncreaseBalance(amount);
        }

    }
}