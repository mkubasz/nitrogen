namespace Startup.TrainingOneHomeworks.wojteko22
{
    public class AccountNumber
    {
        private string number;

        public AccountNumber(string text)
        {
            number = text.Replace(" ", "");
        }

        public string GetNumber()
        {
            return number;
        }

        public string GetBank()
        {
            string code = number.Substring(0, 4);
            switch (code)
            {
                case "1010":
                    return "Narodowy Bank Polski";
                case "1020":
                    return "PKO BP";
                case "1030":
                    return "Citibank Handlowy";
                default:
                    return "inny bank (za dużo pisania)";
            }
        }
    }
}