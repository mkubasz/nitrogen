using System;
using Startup.TrainingOneHomeworks.Rubi.Banks.Interfaces;

namespace Startup.TrainingOneHomeworks.Rubi.Banks
{
    public class BankInformation:IBankInformation
    {
        public string TwoFirstChar(string accountNumber)
        {
            return accountNumber.Substring(0, 2);
        }

        public bool IsNRBorIBAN(string accountNumber)//if NRB is true/ if IBAN is false
        {
            var toVerify = TwoFirstChar(accountNumber);
            
            int output;
            var result = int.TryParse(toVerify, out output);

            if (result)
                return true;
            else
                return false;

        }

        public string BankFromCounry(string accountNumber)
        {
            if (!IsNRBorIBAN(accountNumber))
                return new ListOfBanks()._abroadBanks[TwoFirstChar(accountNumber)];
            else
                return "Polska";
        }

        public bool ValidNumber(string accountNumber)
        {

            var len = accountNumber.Length;

            if (IsNRBorIBAN(accountNumber))
                return len == new ListOfBanks()._numberOfChar[BankFromCounry(accountNumber)];
            else
                return (len + 2) == new ListOfBanks()._numberOfChar[BankFromCounry(accountNumber)];

        }

        public string NameOfBank(string accountNumber)
        {
            if(BankFromCounry(accountNumber)=="Polska" && ValidNumber(accountNumber))
                if (IsNRBorIBAN(accountNumber))
                {
                    var control = accountNumber.Substring(2, 4);
                    return new ListOfBanks()._polishBanksDictionary[control];
                }
                else
                {
                    var control = accountNumber.Substring(4, 4);
                    return new ListOfBanks()._polishBanksDictionary[control];
                }

            return "Niestety, to nie jest bank z Polski, w przyszlosci bedzie obsluzona kontrola takze inncyh panstw";
        }

        
    }
}