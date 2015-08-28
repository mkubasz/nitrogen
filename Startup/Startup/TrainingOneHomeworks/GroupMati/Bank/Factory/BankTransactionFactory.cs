using System;
using System.Collections.Generic;
using Startup.TrainingOneHomeworks.GroupMati.Bank.Banks;

namespace Startup.TrainingOneHomeworks.GroupMati.Bank.Factory
{
    public class FactoryTransactionBank  : AbstractFactoryBankTransaction<String,BankTransaction>
    {

        /// <summary>
        /// Fabryka z instancjami banków.
        /// </summary>

        public FactoryTransactionBank()
        {
            BankDictionary = new Dictionary<string, Func<BankTransaction>>()
            {
                { "1010", () => new NarodowyBankPolskiTransactionBank()},
                { "1020", () => new PkobpTransactionBank()},
                { "1030", () => new CitybankHandlowyTransactionBank()},
                { "1050", () => new IngTransactionBank()},
                { "1060", () => new BphTransactionBank()},
                { "1090", () => new BzwbkTransactionBank()},
                { "1130", () => new BgkTransactionBank()},
                { "1140", () => new mBankTransactionBank()},
                { "1160", () => new BankMilenniumTransactionBank()},
                { "1240", () => new PekaoTransactionBank()},
                { "1280", () => new HsbcTransactionBank()},
                { "1300", () => new MeritumBankTransactionBank()},
                { "1320", () => new BankPocztowyTransactionBank()},
                { "1440", () => new NordeaBankTransactionBank()},
                { "1470", () => new EuroBankTransactionBank()},
                { "1540", () => new BosTransactionBank()},
                { "1580", () => new MercedesBenzBankPolskaTransactionBank()},
                { "1600", () => new BnpParibasFortisTransactionBank()},
                { "1610", () => new SGBBankTransactionBank()},
                { "1670", () => new RbsBankPolskaTransactionBank()},
                { "1750", () => new RaiffeisenBankTransactionBank()},
                { "1840", () => new SocieteGeneraleTransactionBank()},
                { "1870", () => new FmBankPBPTransactionBank()},
                { "1910", () => new DeutscheBankPolskaTransactionBank()},
                { "1930", () => new BankPolskiejSpoldzielczosciTransactionBank()},
                { "1940", () => new CreditAgricoleBankPolskaTransactionBank()},
                { "1950", () => new IdeaBankTransactionBank()},
                { "2000", () => new RabobankPolskaTransactionBank()},
                { "2030", () => new BGZTransactionBank()},
                { "2070", () => new FceBankPolskaTransactionBank()},
                { "2120", () => new SantanderConsumerBankTransactionBank()},
                { "2140", () => new FiatBankPolskaTransactionBank()},
                { "2160", () => new ToyotaBankTransactionBank()},
                { "2190", () => new DnBNordTransactionBank()},
                { "2480", () => new GettinNobleBankTransactionBank()},
                { "2490", () => new AliorBankTransactionBank()}
            };
        }
    }
}