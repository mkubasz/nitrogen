using System.Collections.Generic;

namespace Homeworks.Igor.DataLoadSystem
{
    public interface ILoadDataSys<T>
    {
        List<T> GetData();
    }
}
