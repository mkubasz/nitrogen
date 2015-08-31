using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krzysztof.Banks
{
    public class Account
    {
        public string   accountNumber;
        public decimal  money;
        public List<Owner> owners;
    }
}
