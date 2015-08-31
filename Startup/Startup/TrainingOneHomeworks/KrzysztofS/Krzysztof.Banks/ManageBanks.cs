using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Krzysztof.Banks
{
    public class ManageBanks
    {
        private static List<Bank> GetBankList()
        {
            List<Bank> banks = new List<Bank>();
            banks.Add(new Banks.Bank_Alior());
            banks.Add(new Banks.Bank_BGK());
            banks.Add(new Banks.Bank_BGZ());
            banks.Add(new Banks.Bank_BNP());
            banks.Add(new Banks.Bank_BOS());
            banks.Add(new Banks.Bank_BPH());
            banks.Add(new Banks.Bank_BPS());
            banks.Add(new Banks.Bank_BZWBK());
            banks.Add(new Banks.Bank_Citi());
            banks.Add(new Banks.Bank_Credit());
            banks.Add(new Banks.Bank_DB());
            banks.Add(new Banks.Bank_DnB());
            banks.Add(new Banks.Bank_Euro());
            banks.Add(new Banks.Bank_FCE());
            banks.Add(new Banks.Bank_Fiat());
            banks.Add(new Banks.Bank_FM());
            banks.Add(new Banks.Bank_Getin());
            banks.Add(new Banks.Bank_HSBC());
            banks.Add(new Banks.Bank_Idea());
            banks.Add(new Banks.Bank_ING());
            banks.Add(new Banks.Bank_MBank());
            banks.Add(new Banks.Bank_Mercedes());
            banks.Add(new Banks.Bank_Meritum());
            banks.Add(new Banks.Bank_Millenium());
            banks.Add(new Banks.Bank_NBP());
            banks.Add(new Banks.Bank_Nordea());
            banks.Add(new Banks.Bank_Pekao());
            banks.Add(new Banks.Bank_PKOBP());
            banks.Add(new Banks.Bank_Plus());
            banks.Add(new Banks.Bank_Pocztowy());
            banks.Add(new Banks.Bank_Rabobank());
            banks.Add(new Banks.Bank_Raiffeisen());
            banks.Add(new Banks.Bank_RBS());
            banks.Add(new Banks.Bank_Santander());
            banks.Add(new Banks.Bank_SGB());
            banks.Add(new Banks.Bank_Societe());
            banks.Add(new Banks.Bank_Toyota());
            banks.Add(new Banks.Bank_VW());

            return banks;
        }

        private static bool IsValidNumber(string Account)
        {
            // is only digits
            string pattern = @"[^\d]";
            Regex parser = new Regex(pattern);
            string parseAccount = parser.Replace(Account, "");
            if (parseAccount != Account)
                return false;

            // is proper length
            return Account.Length == 26;
        }

        private static string NormalizeNumber(string Account)
        {
            return Account.Replace(" ", "");
        }

        private static IBank GetBank(string Account)
        {
            List<Bank> banks = GetBankList();
            foreach (Bank bank in banks)
            {
                if (bank.IsMyAccount(Account))
                {
                    return bank;
                }
            }

            return null;
        }

        public static string GetBankName(string Account)
        {
            if (Account == null)
                return "No data";

            Account = NormalizeNumber(Account);
            if (IsValidNumber(Account))
            {
                IBank bank = GetBank(Account);
                if (bank == null)
                    return "Unknown bank account";
                else
                    return bank.BankName();
            }
            else
                return "Invalid account number"; 
        }

    }
}

