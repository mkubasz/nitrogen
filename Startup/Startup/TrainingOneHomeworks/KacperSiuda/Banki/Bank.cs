using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Startup.TrainingOneHomeworks.KacperSiuda.Banki

    public abstract class Bank : iBank
    {
        protected string BankName = "";

        protected int BankId = 0;

        public void SetBankName(string name)
        {
            this.BankName = name;
        }

        public void SetBankId(int id)
        {
            this.BankId = id;
        }

        public string ReturnBankName()
        {
            return BankName;
        }

        public int ReturnBankId()
        {
            return BankId;
        }

        public void EnterTransaction()
        {
            throw new NotImplementedException();
        }
    }
}
