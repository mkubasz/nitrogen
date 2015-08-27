using Startup.TrainingOneHomeworks.Rubi.PeselValidator.Interfaces;

namespace Startup.TrainingOneHomeworks.Rubi.PeselValidator
{
    public class MonthValidation:IMonthValidation
    {

        public bool CorrectMonth1800(int month)
        {
            return month > 80 && month < 93;
        }

        public bool CorrectMonth1900(int month)
        {
            return month > 0 && month < 12;
        }

        public bool CorrectMonth2000(int month)
        {
            return month > 20 && month < 33;
        }

        public bool CorrectMonth2100(int month)
        {
            return month > 40 && month < 53;
        }

        public bool CorrectMonth2200(int month)
        {
            return month > 61 && month < 72;
        }

        public bool IsFebruary(int month)
        {
            return month == 82 || month == 02 || month ==22 || month ==42 || month ==62;
        }

        public bool ShortMonth(int month)
        {
            return month%2==0;
        }
    }
}