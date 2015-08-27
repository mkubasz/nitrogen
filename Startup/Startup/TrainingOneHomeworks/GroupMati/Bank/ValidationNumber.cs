using System;
using System.Globalization;

namespace Startup.TrainingOneHomeworks.Mati
{
    public static class ValidationNumber
    {
        public static bool Validation(string number)
        {
            if (number.Length != 26) return false;
            
            int[] weight = new[]
            {
                1, 10, 3, 30, 9, 90, 27, 76, 81, 34, 49, 5, 50, 15, 53, 45, 62, 38, 89, 17,
                73, 51, 25, 56, 75, 71, 31, 19, 93, 57
            };
            number += "2521";
            int counter = 0;
            for (int i = 0; i < 30; i++)
            {
                counter += (int)Char.GetNumericValue(number[29-i]) * weight[i];
            }
            
            if (counter % 97 == 1)
                return true;
            return false;
        } 
    }
}