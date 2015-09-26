using System.Collections.Generic;
using System.Linq;

namespace Homeworks.Igor.OperationSystem
{
    public class FindAllCitiesAtLetter : IOperation
    {
        protected char Letter;

        public FindAllCitiesAtLetter(char letter)
        {
            this.Letter = letter;
        }
        public object GetResult(List<string> dataSet)
        {
            return dataSet.Where(s => s[0] == Letter).Select(obj => dataSet.FindIndex(s => s == obj)).Cast<object>().ToList();
        }
    }
}
