using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Startup.TrainingOneHomeworks.KacperSiuda.Banki
{
    interface iBank
    {
        void SetBankName(string name);
        void SetBankId(int id);

        string ReturnBankName();
        int ReturnBankId();

        void EnterTransaction();

       

    }
}
