using System;
using System.Text.RegularExpressions;

namespace lDoran.Pesel
{
    public class PeselValidator
    {
        private static readonly int[] weight = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };

        public static bool Validate(string peselNumber)
        {
            peselNumber = Regex.Match(Regex.Replace(peselNumber, @"\s+", ""), @"(\d+)").Value;

            if (peselNumber.Length != 11)
            {
                return false;
            }
            
            int sum = 0;

            for (int i = 0; i < 10; i++)
            {
                sum += weight[i] * (int) Char.GetNumericValue(peselNumber[i]);
            }

            return CheckControlSum(sum, peselNumber);
        }

        private static bool CheckControlSum(int sum, string peselNumber)
        {
            int result = 10 - sum % 10;
            int controlSum = result == 10 ? 0 : result;

            return controlSum == (int)Char.GetNumericValue(peselNumber[10]) ? true : false;
        }
    }
}
