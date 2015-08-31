using System;

namespace KusterPeselValidator
{
    public class KkPeselValidator
    {
        public static readonly int[] coefficients = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
        public DateTime time;

        public KkPeselValidator(string pesel)
        {
            PeselValidatorFinall(pesel);
        }

        public string GetNick()
        {
            return "Kuster";
        }
        public bool PeselCorrectnessLegnth(string pesel)
        {
            return pesel.Length == 11;
        }
        public bool PeselCorrectnessNumbers(string pesel)
        {
            int checkingSum = 0;

            for (int i = 0; i < 10; i++)
            {
                checkingSum += (coefficients[i] * (pesel[i]-48) );
            }
            if (checkingSum % 10 == 0 && ( (pesel[10]-48) == 0))
                return true;
            else if (10 - checkingSum%10 == (pesel[10]-48))
                return true;
            else
                return false;
        }
        public bool PeselCorrectnessBirthDate(string pesel)
        {
            int birthDateYearInt = int.Parse(pesel.Substring(0, 2));
            int birthDateMonthInt = int.Parse(pesel.Substring(2, 2));
            int birthDateDayInt = int.Parse(pesel.Substring(4, 2));

            if (birthDateMonthInt / 20 == 0) birthDateYearInt += 1900;
            if (birthDateMonthInt / 20 == 1) birthDateYearInt += 2000;
            if (birthDateMonthInt / 20 == 2) birthDateYearInt += 2100;
            if (birthDateMonthInt / 20 == 3) birthDateYearInt += 2200;
            if (birthDateMonthInt / 20 == 4) birthDateYearInt += 1800;
            birthDateMonthInt = birthDateMonthInt % 20;

            try
            {
                time = new DateTime(birthDateYearInt, birthDateMonthInt, birthDateDayInt);
            }
            catch
            {
                return false;
            }

            return true;
        }
        public bool PeselValidatorFinall(string pesel)
        {
            return (PeselCorrectnessLegnth(pesel) && PeselCorrectnessNumbers(pesel) && PeselCorrectnessBirthDate(pesel));
        }
    }
}