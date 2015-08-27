using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Startup.TrainingOneHomeworks.Bolec.Interface;

namespace Startup.TrainingOneHomeworks.Bolec
{
    public class UserAccount : TransferInfo
    {
        public int balance;
        public void DecreaseBalance(int amount)
        {
            balance = balance - amount;
        }
        public void IncreaseBalance(int amount)
        {
            balance = balance + amount;
        }
    }
}
