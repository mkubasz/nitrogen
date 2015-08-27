using System.Collections.Generic;

namespace Startup.TrainingOneHomeworks.TomaszF
{
    public class CheckBank
    {
        private string _bankName;
        readonly Dictionary<string, string> _bankList = new Dictionary<string, string>();


        public string TakeBankControlNumber(int number)
        {
            string numberString = number.ToString();
            string num = numberString.Substring(2, 4);

            return num;
        }

        public string WhichBank(string number)
        {

            _bankList.Add("1010", "Narodowy Bank Polski");
            _bankList.Add("1020", "PKO BP");
            _bankList.Add("1030", "Citybank Handlowy");
            _bankList.Add("1050", "ING");
            _bankList.Add("1060", "BPH");
            _bankList.Add("1090", "BZ WBK");
            _bankList.Add("1130", "BGK");
            _bankList.Add("1140", "mBank");
            _bankList.Add("1160", "Bank Milennium");
            _bankList.Add("1240", "Pekao");
            _bankList.Add("1280", "HSBC");
            _bankList.Add("1300", "Meritum Bank");
            _bankList.Add("1320", "BankPocztowy");
            _bankList.Add("1440", "Nordea Bank");
            _bankList.Add("1470", "Euro Bank");
            _bankList.Add("1540", "BOŚ");
            _bankList.Add("1580", "Mercedes-Benz Bank Polska");
            _bankList.Add("1600", "BNP Paribas Fortis");
            _bankList.Add("1610", "SGB - Bank");
            _bankList.Add("1670", "RBS Bank (Polska)");
            _bankList.Add("1680", "Plus Bank");
            _bankList.Add("1750", "Raiffeisen Bank");
            _bankList.Add("1840", "Societe Generale");
            _bankList.Add("1870", "FM Bank PBP");
            _bankList.Add("1910", "Deutsche Bank Polska");
            _bankList.Add("1930", "Bank Polskiej Spółdzielczości");
            _bankList.Add("1940", "Credit Agricole Bank Polska");
            _bankList.Add("1950", "Idea Bank");
            _bankList.Add("2000", "Rabobank Polska");
            _bankList.Add("2030", "BGŻ");
            _bankList.Add("2070", "FCE Bank Polska");
            _bankList.Add("2120", "Santander Consumer Bank");
            _bankList.Add("2030", "Volkswagen Bank");
            _bankList.Add("2040", "Fiat Bank Polska");
            _bankList.Add("2160", "Toyota Bank");
            _bankList.Add("2190", "DnB Nord");
            _bankList.Add("2480", "Getin Noble Bank");
            _bankList.Add("2490", "Alior Bank");

            if (_bankList.TryGetValue(number, out _bankName))
            {
                return _bankName;
            }
            else
            {
                throw new System.NotImplementedException();
            }
        }


    }

}