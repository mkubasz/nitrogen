namespace Startup.TrainingOneHomeworks.Rubi.PeselValidator.Interfaces
{
    public class DayValidation : IDayValidation
    {
        public bool LongMonth(int day)
        {
            return day > 1 && day < 31;
        }

        public bool ShortMonth(int day)
        {
            return day > 1 && day < 30;
        }

        public bool NormalFebruary(int day)
        {
            return day > 1 && day < 28;
        }

        public bool LeapsedFebruary(int day)
        {
            return day > 1 && day < 29;
        }
    }
}