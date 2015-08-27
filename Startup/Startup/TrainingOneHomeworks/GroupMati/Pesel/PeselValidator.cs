using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Startup.TrainingOneHomeworks.GroupMati.Pesel
{
    public class PeselValidator : IPeselValidator
    {
        private string peselNumber;

        public string PeselNumber
        {
            get
            {
                return this.peselNumber;
            }
            set
            {
                if (CheckPesel(value.ToString()))
                {
                    this.peselNumber = value;
                }
                else
                {
                    peselNumber = null;
                }
            }
        }

        public PeselValidator()
        {
            peselNumber = " ";
        }

        public PeselValidator(string pesel)
            : this()
        {
            this.PeselNumber = pesel;
        }

        public string GetPesel()
        {
            return this.peselNumber;
        }

        public bool SetPesel(string pesel)
        {
            if (CheckPesel(pesel))
            {
                this.peselNumber = pesel;
                return true;
            }
            return false;
        }

        public static bool CheckPesel(string pesel)
        {
            if (pesel.Length == 11)
            {
                foreach (char i in pesel)
                {
                    if (!Char.IsNumber(i))
                    {
                        return false;
                        throw new InvalidPeselExeptions("You put into PESEL char");
                    }
                }
                DateTime time;

                int year = Convert.ToInt32(pesel.Substring(0, 2));
                int month = Convert.ToInt32(pesel.Substring(2, 2));
                int day = Convert.ToInt32(pesel.Substring(4, 2));

                int testyear = year;
                int testmonth = month % 20;
                int testday = day;
                if (month / 20 == 4) testyear += 1800;
                if (month / 20 == 0) testyear += 1900;
                if (month / 20 == 1) testyear += 2000;

                try
                {
                    time = new DateTime(testyear, testmonth, testday);
                }
                catch (ArgumentOutOfRangeException arg)
                {
                    throw new InvalidPeselExeptions(arg.Message);
                }

                int[] peselWeights = new int[11] { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3, 1 };
                int controlSum = 0;
                for (int i = 0; i < 11; i++)
                {
                    controlSum += pesel[i] * peselWeights[i];
                }
                if (controlSum % 10 != 0) throw new InvalidPeselExeptions("Wrong cotrol sum in Pesel");


                return true;
            }
            else if (pesel.Length < 11)
            {
                throw new InvalidPeselExeptions("Your PESEL is too short ");
            }
            else
            {
                throw new InvalidPeselExeptions("Your PESEL is too long ");
            }
            //return false;
        }
    }
}
