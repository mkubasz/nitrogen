using System.Collections.Generic;
using System.Linq;

namespace Homeworks.Igor.OperationSystem
{
    public class RemoveRepeat : IOperation
    {
        public object GetResult(List<string> dataSet)
        {
            var ret = new HashSet<string>();
            foreach (var obj in dataSet)
            {
                ret.Add(obj);
            }
            return ret.ToList();
            /*
             * drugi sposób :
            var ret = new List<string>();
            foreach (var obj in dataSet.Where(obj => !ret.Contains(obj)))
            {
                ret.Add(obj);
            }
            return ret;
             */
        }
    }
}
