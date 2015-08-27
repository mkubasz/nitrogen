namespace Startup.TrainingOneHomeworks.Rubi.PeselValidator.Interfaces
{
    public interface IPeselValidation
    {
        bool ControlNumber(string pesel);
        bool IsPeselCorret(string pesel);
        bool ManOrWoman(string pesel);
    }
}