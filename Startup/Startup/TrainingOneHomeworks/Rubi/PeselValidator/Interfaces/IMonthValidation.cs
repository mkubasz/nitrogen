namespace Startup.TrainingOneHomeworks.Rubi.PeselValidator.Interfaces
{
    public interface IMonthValidation
    {
        bool CorrectMonth1800(int month);
        bool CorrectMonth1900(int month);
        bool CorrectMonth2000(int month);
        bool CorrectMonth2100(int month);
        bool CorrectMonth2200(int month);
        bool IsFebruary(int month);
        bool ShortMonth(int month);

    }
}