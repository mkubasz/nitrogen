using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Startup.TrainingOneHomeworks.Vertek.ValidatePESEL
{
    class PESEL
    {
        string[] PESELs = new string[5]
        {
            "95010500699",
            "85032130353",
            "35531120263",
            "55014170223",
            "65060764237"
        };

        int[] multiply = new int[10]
        {
            1,
            3,
            7,
            9,
            1,
            3,
            7,
            9,
            1,
            3
        };

        bool result = false;

        public string ValidatePESEL()
        {
            int checkSum = 0;
            int x = 0; // wybieramy numer pesel

            for (int a = 0; a < multiply.Length; a++)
            {
                checkSum += (multiply[a] * Convert.ToInt32(PESELs[x].Substring(a, 1)));
            }

            result = (10 - (checkSum % 10) == Convert.ToInt32(PESELs[x].Substring(10, 1)));

            if (result)
                return "PESEL poprawny";
            else
                return "PESEL błędny";

        }
    }
}
