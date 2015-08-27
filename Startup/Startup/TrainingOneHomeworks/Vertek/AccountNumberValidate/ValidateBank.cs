using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Startup.TrainingOneHomeworks.Vertek.AccountNumberValidation
{
    public class ValidateBank : ValidateAccountNumber
    {
        public string[] AccountNumbers = new string[5]
        {
            "86102024123458860123531234",
            "76130024980234620202631234",
            "66175024980000863444444234",
            "26216024980734660204534534",
            "36249024567340860202631234"
        };

        public string GetBankName()
        {
            int x = 4; //wybieramy numer konta
            int code = Convert.ToInt32(AccountNumbers[x].Substring(2,4));
            return CheckNumber(code);
        }
    }
}
