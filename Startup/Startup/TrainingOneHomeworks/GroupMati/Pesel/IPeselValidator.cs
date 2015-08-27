namespace Startup.TrainingOneHomeworks.GroupMati.Pesel
{
    public interface IPeselValidator
    {
        string PeselNumber { get; set; }
        string GetPesel();
        bool SetPesel(string pesel);
    }
}