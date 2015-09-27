using System.Collections.Generic;

namespace Homeworks.Igor.DataLoadSystem.FileLoader
{
    public abstract class FileLoader<T> : ILoadDataSys<T>
    {
        protected List<T> DataSet = new List<T>();
        public virtual List<T> GetData()
        {
            return DataSet;
        }
    }
}
