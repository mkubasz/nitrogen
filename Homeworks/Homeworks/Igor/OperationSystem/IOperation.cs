using System.Collections.Generic;

namespace Homeworks.Igor.OperationSystem
{
    public interface IOperation
    {
        List<string> GetResult(List<string> dataSet);
    }
}
