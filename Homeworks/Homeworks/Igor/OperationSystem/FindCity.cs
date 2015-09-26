using System.Collections.Generic;

namespace Homeworks.Igor.OperationSystem
{
    public class FindCity : IOperation
    {
        protected string name;

        public FindCity(string name)
        {
            this.name = name;
        }
        public object GetResult(List<string> dataSet)
        {
            return dataSet.Contains(name) ? dataSet.FindIndex(s => s==name) : default(int);
        }
    }
}
