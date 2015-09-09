using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tematy_kod.Widmo.Vertek
{
    public class Farba
    {
        private string _company;
        protected string _cost;

        private void setValue(string _company)
        {
            _cost = _company;
        }
        protected void getValue()
        {
           Console.WriteLine(_cost);
        }

        public void Paint(string color)
        {
            Console.WriteLine(color);
        }
    }
}
