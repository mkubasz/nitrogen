using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homeworks.Igor.OperationSystem
{
    public interface IOperation
    {
        HashSet<string> getResult(HashSet<string> DataSet);
    }
}
