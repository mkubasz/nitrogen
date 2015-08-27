using System.Collections.Generic;
using Startup.TrainingOneHomeworks.AndzejC.Banki.Abstrakty;
using Startup.TrainingOneHomeworks.AndzejC.Banki.Banks;

namespace Startup.TrainingOneHomeworks.AndzejC.Banki
{
    public class BankList2 : GenFactory<SendTransaction>
    {
        public BankList2()
        {
            ItemList = new Dictionary<string, SendTransaction>
            {
                {"1050", new Ing()},
                {"1010", new NarodowyBankPolski()},
                {"1020", new Pkobp()}
            };
        }
    }
}