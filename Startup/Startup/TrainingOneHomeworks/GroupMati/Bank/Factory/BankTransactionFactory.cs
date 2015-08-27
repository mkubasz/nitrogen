using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Startup.TrainingOneHomeworks.GroupMati.Bank.Factory;
using Startup.TrainingOneHomeworks.Mati.InterfaceBanks;

namespace Startup.TrainingOneHomeworks.Mati.Banks
{
    public class FactoryBankTransaction<T>  : AbstractFactoryBankTransaction<T>
    {

        /// <summary>
        /// Delegata zrobic
        /// </summary>

        
        public FactoryBankTransaction()
        {
            //BankDictionary = new Dictionary<string, Func<T>>()
            //{
            //    { "1010", () => new NarodowyBankPolski()},
            //    { "1020", () => new Pkobp},
            //    { "1030", () => new CitybankHandlowy},
            //    { "1050", () => new Ing},
            //    { "1060", () => new Bph},
            //    { "1090", () => new Bzwbk},
            //    { "1130", () => new Bgk},
            //    { "1140", () => new mBank},
            //    { "1160", () => new BankMilennium},
            //    { "1240", () => new Pekao},
            //    { "1280", () => new Hsbc},
            //    { "1300", () => new MeritumBank},
            //    { "1320", () => new BankPocztowy},
            //    { "1440", () => new NordeaBank},
            //    { "1470", () => new EuroBank},
            //    { "1540", () => new Bos},
            //    { "1580", () => new MercedesBenzBankPolska},
            //    { "1600", () => new BnpParibasFortis},
            //    { "1610", () => new SGBBank},
            //    { "1670", () => new RbsBankPolska)},
            //    { "1750", () => new RaiffeisenBank},
            //    { "1840", () => new SocieteGenerale},
            //    { "1870", () => new FmBankPBP},
            //    { "1910", () => new DeutscheBankPolska},
            //    { "1930", () => new BankPolskiejSpoldzielczosci},
            //    { "1940", () => new CreditAgricoleBankPolska},
            //    { "1950", () => new IdeaBank},
            //    { "2000", () => new RabobankPolska},
            //    { "2030", () => new BGZ},
            //    { "2070", () => new FceBankPolska},
            //    { "2120", () => new SantanderConsumerBank},
            //    { "2140", () => new FiatBankPolska},
            //    { "2160", () => new ToyotaBank},
            //    { "2190", () => new DnBNord},
            //    { "2480", () => new GettinNobleBank},
            //    { "2490", () => new AliorBank}
            //};


}
       

        public void Add(string key, object value) 
        {
           // BankDictionary.Add(key, value);
        }

        public Func<T> GetValue(string key) 
        {
            return  BankDictionary[key];
        }
        public bool TryGetTransaction(string key, Func<T> bankTransaction)
        {
            return BankDictionary.TryGetValue(key, out bankTransaction);
        
        }
    }
}