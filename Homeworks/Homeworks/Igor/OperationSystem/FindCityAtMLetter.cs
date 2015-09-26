using System.Collections.Generic;

namespace Homeworks.Igor.OperationSystem
{
    public class FindCityAtMLetter : IOperation
    {
        protected char letter;
        public FindCityAtMLetter(char letter)
        {
            this.letter = letter;
        }
        public object GetResult(List<string> dataSet)
        {
            return dataSet.FindIndex(s => s[0] == letter);
        }
    }
}
