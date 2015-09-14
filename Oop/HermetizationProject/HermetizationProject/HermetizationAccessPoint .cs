using System.Reflection;

namespace HermetizationProject
{
    public class HermetizationAccessPoint
    {
        private int pin = 1234;
        public string numberOfAccount = "5432175213519827531728531";
        protected bool doneTransaction = true;
        protected internal int solution;

        public bool SendTransaction(string number)
        {
            numberOfAccount = number;
            return doneTransaction;
        }

    }
}