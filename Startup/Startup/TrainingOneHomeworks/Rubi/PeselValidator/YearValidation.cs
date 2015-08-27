using Startup.TrainingOneHomeworks.Rubi.PeselValidator.Interfaces;

namespace Startup.TrainingOneHomeworks.Rubi.PeselValidator
{
    public class YearValidation:IYearValidation
    {

        public bool IsYearCorrect(int year)
        {
            return year >= 0 && year<100;
        }

        public bool IsLeapsedYear(int year)
        {
            return year%4 == 0;
        }
    }
}