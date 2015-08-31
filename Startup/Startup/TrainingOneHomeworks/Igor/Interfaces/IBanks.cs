using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banki.Banks;

namespace Banki.Interfaces
{
    interface IBanks
    {
        int getInstytutionId(string cardNumber);
        bool checkIfNumberIsCorrect(string cardNumber);
        Bank getBank(string cardNumber);
    }
}
