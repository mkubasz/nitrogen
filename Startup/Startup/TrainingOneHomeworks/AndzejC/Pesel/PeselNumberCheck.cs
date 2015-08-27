using System;
using System.Linq;

namespace Startup.TrainingOneHomeworks.AndzejC.Pesel
{
    public static class PeselNumberCheck
    {
        public static bool PeselControl(string pesel)
        {
            int[] controlNumbers = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
            var peselInt = Array.ConvertAll(pesel.ToCharArray(), c => (int)char.GetNumericValue(c));
            var peselTest = controlNumbers.Select((t, i) => t * peselInt[i]).Sum();
            peselTest = peselTest % 10;
            if (peselTest == 10) return (peselInt[10] == 0);
            return (peselInt[10] == 10 - peselTest);
        } 
    }
}