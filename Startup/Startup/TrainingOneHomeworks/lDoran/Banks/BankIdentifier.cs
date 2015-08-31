using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace lDoran
{
    public class BankIdentifier
    {
        private string accountNumber;
        private XElement xmlElement;

        public BankIdentifier(string pathToXmlDocument) 
        {
            xmlElement = XElement.Load(pathToXmlDocument);
        }

        public BankIdentifier(string accountNumber, string pathToXmlDocument) : this (pathToXmlDocument)
        {
            this.accountNumber = ParseAccountNumber(accountNumber);
        }

        public string GetBankNameByAccountNumber()
        {
            return GetBankNameByAccountNumber(accountNumber);
        }

        public string GetBankNameByAccountNumber(string accountNumber)
        {
            this.accountNumber = ParseAccountNumber(accountNumber);
            string bankCode = ExtractBankCodeFromAccountNumber();
            string bankName = "";

            var result = from bank in xmlElement.Elements("bank")
                         where (string)bank.Element("id").Value == bankCode
                         select bank;

            foreach (var b in result)
            {
                bankName = b.Element("name").Value;
            }

            return bankName;
        }

        private string ExtractBankCodeFromAccountNumber()
        {
            return accountNumber.Substring(2, 4);
        }

        private string ParseAccountNumber(string accountNumber)
        {
            return Regex.Match(
                Regex.Replace(accountNumber, @"\s+", ""), 
                @"(\d+)"
                )
                .Value;
        }
    }
}
