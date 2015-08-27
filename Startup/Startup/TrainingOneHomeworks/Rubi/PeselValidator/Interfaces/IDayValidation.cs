namespace Startup.TrainingOneHomeworks.Rubi.PeselValidator.Interfaces
{
    public interface IDayValidation
    {
        bool LongMonth(int day);
        bool ShortMonth(int day);
        bool NormalFebruary(int day);
        bool LeapsedFebruary(int day);
    }
}