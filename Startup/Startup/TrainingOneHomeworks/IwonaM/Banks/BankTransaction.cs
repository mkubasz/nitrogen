using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Startup.TrainingOneHomeworks.IwonaM.Banki
{
    public abstract class BankTransaction
    {
     

        public virtual string InputTransaction()
        {
            return null;
        }

        public virtual string OutputTransaction()
        {
            return null;
        }

    }
}
