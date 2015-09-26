using System.Collections.Generic;

namespace Homeworks.Igor.OperationSystem
{
    public interface IOperation
    {
        object GetResult(List<string> dataSet);
    }
}
