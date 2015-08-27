using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Startup.TrainingOneHomeworks.Erloon;

namespace Toci.Startup.Test.ErloonTest
{
    [TestClass]
    public class BankTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            AccountNumber number = new AccountNumber("86102024981111222233334444");

            if (number.AcountNumber.Length == 26)
            {
                BankAccountNumber bankAccount = new BankAccountNumber();
               string test= bankAccount.CheckBank(number);
            }
            else if (number.AcountNumber.Length == 28)
            {
                TheInternationalBankAccountNumber bankAccount = new TheInternationalBankAccountNumber();
                string test = bankAccount.CheckBank(number);
            }
            else
            {
                string test = "Błędny numer konta bankowego";
            }

        }
    }
}
