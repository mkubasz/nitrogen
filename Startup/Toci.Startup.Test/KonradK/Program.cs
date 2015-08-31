using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toci
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("wpisz numer konta bankowego");
            string number = Console.ReadLine();
            Bank bank = BankList.GetBank(number);
            Console.WriteLine(bank.GetType().ToString().Substring(5));
            Console.ReadKey();
        }
    }


    public static class BankList
    {
        public static Bank GetBank(string fstrClientNumber)
        {
            switch (Int32.Parse( fstrClientNumber.Substring(2, 4)))
            {
                case 1010: return new NarodowyBankPolski(fstrClientNumber);
                case 1020: return new PKOBP(fstrClientNumber);
                case 1030: return new CitybankHandlowy(fstrClientNumber);
                case 1050: return new ING(fstrClientNumber);
                case 1060: return new BPH(fstrClientNumber);
                case 1090: return new BZWBK(fstrClientNumber);
                case 1130: return new BGK(fstrClientNumber);
                case 1140: return new mBank(fstrClientNumber);
                case 1160: return new BankMillennium(fstrClientNumber);
                case 1240: return new Pekao(fstrClientNumber);
                case 1280: return new HSBC(fstrClientNumber);
                case 1300: return new MeritumBank(fstrClientNumber);
                case 1320: return new BankPocztowy(fstrClientNumber);
                case 1440: return new NordeaBank(fstrClientNumber);
                case 1470: return new EuroBank(fstrClientNumber);
                case 1540: return new BOŚ(fstrClientNumber);
                case 1580: return new MercedesBenzBankPolska(fstrClientNumber);
                case 1600: return new BNPParibasFortis(fstrClientNumber);
                case 1610: return new SGBBank(fstrClientNumber);
                case 1670: return new RBSBank(fstrClientNumber);
                case 1680: return new PlusBank(fstrClientNumber);
                case 1750: return new RaiffeisenBank(fstrClientNumber);
                case 1840: return new SocieteGenerale(fstrClientNumber);
                case 1870: return new FMBankPBP(fstrClientNumber);
                case 1910: return new DeutscheBankPolska(fstrClientNumber);
                case 1930: return new BankPolskiejSpółdzielczości(fstrClientNumber);
                case 1940: return new CreditAgricoleBankPolska(fstrClientNumber);
                case 1950: return new IdeaBank(fstrClientNumber);
                case 2000: return new RabobankPolska(fstrClientNumber);
                case 2030: return new BGŻ(fstrClientNumber);
                case 2070: return new FCEBankPolska(fstrClientNumber);
                case 2120: return new SantanderConsumerBank(fstrClientNumber);
                case 2130: return new VolkswagenBank(fstrClientNumber);
                case 2140: return new SGBBank(fstrClientNumber);
                case 2160: return new ToyotaBank(fstrClientNumber);
                case 2190: return new DnBNord(fstrClientNumber);
                case 2480: return new GetinNobleBank(fstrClientNumber);
                case 2490: return new AliorBank(fstrClientNumber);
                default: return null;
            }
        }
    }
}
