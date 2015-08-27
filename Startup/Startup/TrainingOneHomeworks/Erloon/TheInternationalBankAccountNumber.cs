namespace Startup.TrainingOneHomeworks.Erloon
{
    public class TheInternationalBankAccountNumber:IIdentificationBankAccountNumber
    {
        public string CheckBank(AccountNumber accountNumber)
        {
            string tempAccountNumber = "";
            tempAccountNumber = accountNumber.AcountNumber.Substring(5, 8);
            var fundBank = BamkList.ListAllBank.Find(bank => bank.BranchBankId.Equals(tempAccountNumber));
            return "Nazwa banku: " + fundBank.BankName + " oddział w " + fundBank.BranchBankName;
        }
    }
}