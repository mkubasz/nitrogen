using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Startup.TrainingOneHomeworks.IwonaM.Pesel
{
    public static class Pesel
    {
                  
        public static bool PeselValidator(string _pesel)
        {
            if (string.IsNullOrWhiteSpace(_pesel))
            {
                return false;
            }
            if (_pesel.Length != 11)
            {
                return false;
            }
            if (_pesel.Any(c => !char.IsDigit(c)))
            {
                return false;
            }
            int days = int.Parse(_pesel.Substring(4, 2));
            if (days > 31)
            {
                return false;
            }
            int month = int.Parse(_pesel.Substring(2, 2));
            if ((month < 13) || (20 < month && month < 33) || (month > 40 && month < 53) || (month > 60 && month < 73) || (month > 80 && month < 93) )
            {
                int suma = 0;
                var tab = new int[] {1, 3, 7, 9, 1, 3, 7, 9, 1, 3};
                for (int i = 0; i < _pesel.Length -1 ; i++)
                {
                    suma += int.Parse(_pesel[i].ToString())*tab[i];
                }
                int controlNumber = 10 - (suma%10);
                if (controlNumber == 10)
                {
                    controlNumber = 0;
                }
                if (_pesel[10].ToString() == controlNumber.ToString())
                {
                    return true;
                }
                return false;
            }
            return false;

        }
    }
}
