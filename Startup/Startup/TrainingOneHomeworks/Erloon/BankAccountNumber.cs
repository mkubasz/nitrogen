namespace Startup.TrainingOneHomeworks.Erloon
{
    public class BankAccountNumber: IIdentificationBankAccountNumber
    {
        public string CheckBank(AccountNumber accountNumber)
        {
            string tempAccountNumber = accountNumber.AcountNumber.Substring(3, 8);
            var fundBank = BamkList.ListAllBank.Find(bank => bank.BranchBankId.Equals(tempAccountNumber));
            return "Nazwa banku: " + fundBank.BankName + " oddział w " + fundBank.BranchBankName;
        }
    }
}