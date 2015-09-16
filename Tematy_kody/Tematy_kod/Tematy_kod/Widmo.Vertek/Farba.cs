using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tematy_kod.Widmo.Vertek
{
    public class Farba
    {
        private string _companyCost;
        protected string cost;

        private void setValue(string _companyCost)
        {
            cost = _companyCost;
        }
        protected void getValue()
        {
           Console.WriteLine(cost);
        }

        public void Paint(string color)
        {
            Console.WriteLine(color);
        }
    }
}
