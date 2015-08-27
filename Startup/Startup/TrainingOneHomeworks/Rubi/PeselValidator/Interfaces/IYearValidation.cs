namespace Startup.TrainingOneHomeworks.Rubi.PeselValidator.Interfaces
{
    public interface IYearValidation
    {
        bool IsYearCorrect(int year);
        bool IsLeapsedYear(int year);
    }
}