namespace Startup.TrainingOneHomeworks.Rubi.Banks.Interfaces
{
    public interface IBankInformation
    {
        string TwoFirstChar(string accountNumber);
        bool IsNRBorIBAN(string accountNumber);
        string BankFromCounry(string accountNumber);
        bool ValidNumber(string accountNumber);//Length etc in the future
        string NameOfBank(string accountNumber);
    }
}