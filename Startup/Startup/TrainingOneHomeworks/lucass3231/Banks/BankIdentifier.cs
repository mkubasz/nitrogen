using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Startup.TrainingOneHomeworks.Erloon;

namespace Startup.TrainingOneHomeworks.lucass3231.Banks
{
   



    public class BankIdentifier
    {
        public void FormatVerification(string AccountNumber)
        {
            AccountNumber = AccountNumber.Replace(" ", string.Empty);

            if (AccountNumber.Length == 26 || AccountNumber.Length == 28)
            {

                if (AccountNumber.All(char.IsDigit))
                {
                    AccountNumber = AccountNumber.Remove(0, 2);
                    AccountNumber = AccountNumber.Remove(4, 20);
                    Console.WriteLine(AccountNumber);
                }
                else
                {
                    AccountNumber = AccountNumber.Remove(0, 2);
                    if (AccountNumber.All(char.IsDigit))
                    {
                        AccountNumber = AccountNumber.Remove(0, 2);
                        AccountNumber = AccountNumber.Remove(4, 20);
                        Console.WriteLine(AccountNumber);
                    }

                }
            }
            else
            {
                Console.WriteLine("Invalid Account Number");
            }

            switch (AccountNumber)
            {
                case "1010":
                    Console.WriteLine("Your bank's name is Narodowy Bank Polski");
                    break;
                case "1020":
                    Console.WriteLine("Your bank's name is PKO BP");
                    break;
                case "1030":
                    Console.WriteLine("Your bank's name is Citybank Handlowy");
                    break;

                case "1050":
                    Console.WriteLine("Your bank's name is ING");
                    break;
                case "1060":
                    Console.WriteLine("Your bank's name is BPH");
                    break;

                case "1090":
                    Console.WriteLine("Your bank's name is BZ WBK");
                    break;
                case "1130":
                    Console.WriteLine("Your bank's name is BGK");
                    break;

                case "1140":
                    Console.WriteLine("Your bank's name is mBank");
                    break;
                case "1160":
                    Console.WriteLine("Your bank's name is Bank Millennium");
                    break;

                case "1240":
                    Console.WriteLine("Your bank's name is Pekao");
                    break;
                case "1280":
                    Console.WriteLine("Your bank's name is HSBC");
                    break;

                case "1300":
                    Console.WriteLine("Your bank's name is Meritum Bank");
                    break;
                case "1320":
                    Console.WriteLine("Your bank's name is Bank Pocztowy");
                    break;

                case "1440":
                    Console.WriteLine("Your bank's name is Nordea Bank");
                    break;
                case "1470":
                    Console.WriteLine("Your bank's name is Euro Bank");
                    break;

                case "1540":
                    Console.WriteLine("Your bank's name is BOŚ");
                    break;
                case "1580":
                    Console.WriteLine("Your bank's name is Mercedes-Benz Bank Polska");
                    break;

                case "1600":
                    Console.WriteLine("Your bank's name is BNP Paribas Fortis");
                    break;
                case "1610":
                    Console.WriteLine("Your bank's name is SGB - Bank");
                    break;

                case "1670":
                    Console.WriteLine("Your bank's name is RBS Bank (Polska)");
                    break;
                case "1680":
                    Console.WriteLine("Your bank's name is Plus Bank");
                    break;

                case "1750":
                    Console.WriteLine("Your bank's name is Raiffeisen Bank");
                    break;
                case "1840":
                    Console.WriteLine("Your bank's name is Societe Generale");
                    break;

                case "1870":
                    Console.WriteLine("Your bank's name is FM Bank PBP");
                    break;
                case "1910":
                    Console.WriteLine("Your bank's name is Deutsche Bank Polska");
                    break;

                case "1930":
                    Console.WriteLine("Your bank's name is Bank Polskiej Spółdzielczości");
                    break;
                case "1940":
                    Console.WriteLine("Your bank's name is Credit Agricole Bank Polska");
                    break;

                case "1950":
                    Console.WriteLine("Your bank's name is Idea Bank");
                    break;
                case "2000":
                    Console.WriteLine("Your bank's name is Rabobank Polska");
                    break;

                case "2030":
                    Console.WriteLine("Your bank's name is BGŻ");
                    break;
                case "2070":
                    Console.WriteLine("Your bank's name is FCE Bank Polska");
                    break;
                case "2120":
                    Console.WriteLine("Your bank's name is Santander Consumer Bank");
                    break;
                case "2130":
                    Console.WriteLine("Your bank's name is Volkswagen Bank");
                    break;
                case "2140":
                    Console.WriteLine("Your bank's name is Fiat Bank Polska");
                    break;
                case "2160":
                    Console.WriteLine("Your bank's name is Toyota Bank");
                    break;
                case "2190":
                    Console.WriteLine("Your bank's name is DnB Nord");
                    break;
                
                case "2480":
                    Console.WriteLine("Your bank's name is Getin Noble Bank");
                    break;
                case "2490":
                    Console.WriteLine("Your bank's name is Alior Bank");
                    break;

                default:
                    Console.WriteLine("Your bank doesn't exist in our data base");
                    break;
            }


        }

        static void Main(string[] args)
        {
            BankIdentifier program = new BankIdentifier();
            program.FormatVerification("86 10202 4981111222233334444");
        }
    }
}

    
  
    
