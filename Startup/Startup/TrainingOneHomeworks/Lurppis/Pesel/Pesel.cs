using System;
namespace Startup.TrainingOneHomeworks.Lurppis.Pesel
{
    public class Pesel : Interface.IPesel
    {
        private string pesel;

        public Pesel()
        {
            pesel = "";
        }

        public Pesel(string pesel)
        {
            this.pesel = pesel;
        }

        public bool CheckLength()
        {
            if (pesel.Length == 11)
            {
                foreach (var i in pesel)
                {
                    if (!char.IsNumber(i))
                    {
                        throw new Exception("Pesel zawiera literki");
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool IsCorrect()
        {
            //int year = Convert.ToInt32(pesel.Substring(0, 2));
            int month = Convert.ToInt32(pesel.Substring(2, 2));
            int day = Convert.ToInt32(pesel.Substring(4, 2));

            if (month > 12 || day > 31)
            {
                return false;
            }
            return false;
        }
    }
}