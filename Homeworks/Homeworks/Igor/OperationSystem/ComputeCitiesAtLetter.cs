using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homeworks.Igor.OperationSystem
{
    public class ComputeCitiesAtLetter : IOperation
    {
        protected char letter;
        public ComputeCitiesAtLetter(char letter)
        {
            this.letter = letter;
        }
        public object GetResult(List<string> dataSet)
        {
            return dataSet.Where(s => s[0] == letter).Count();
        }
    }
}
