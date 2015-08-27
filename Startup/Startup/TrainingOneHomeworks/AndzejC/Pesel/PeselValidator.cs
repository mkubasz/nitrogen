namespace Startup.TrainingOneHomeworks.AndzejC.Pesel
{
    public class PeselValidator
    {
        protected bool CheckPeselNumber(string pesel)
        {
            return PeselNumberCheck.PeselControl(pesel);
        }

        protected bool CheckPeselDate(string pesel)
        {     
            return DateGetCheck.DateCheck(pesel);
        }

        public bool IsValidatePesel(string pesel)
        {
            return CheckPeselNumber(pesel) && CheckPeselDate(pesel);
        }
    }
}