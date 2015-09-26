using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homeworks.Igor.OperationSystem
{
    public class RemoveAllCitiesAtName : IOperation
    {
        protected string name;
        public RemoveAllCitiesAtName(string name)
        {
            this.name = name;
        }
        public object GetResult(List<string> dataSet)
        {
            dataSet.Remove(name);
            return dataSet;
        }
    }
}
