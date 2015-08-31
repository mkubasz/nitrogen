using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Krzysztof.BanksTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestBank()
        {
            List<string> accounts = new List<string>();
            accounts.Add("39191012343458860123531234");
            accounts.Add("39111012343458860123531234 ");
            accounts.Add("391110 X12343458860123531234 ");
            accounts.Add("39 1010 1234 1234 8601 2353 1234");
            accounts.Add("afsdsdfsdfs");
            accounts.Add(null);

            List<string> results = new List<string>();
            foreach(string account in accounts)
            {
                string bankName = Krzysztof.Banks.ManageBanks.GetBankName(account);
                results.Add(account + " - " + bankName);
            }
        }
    }
}
