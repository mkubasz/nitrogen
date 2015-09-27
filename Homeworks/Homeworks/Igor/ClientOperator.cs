using System.Collections.Generic;

namespace Homeworks.Igor
{
    public abstract class ClientOperator<T>
    {
        protected List<T> DataSet;

        public abstract void AddData(string obj);

        public virtual List<T> GetList()
        {
            return DataSet;
        }

        public abstract void RemoveRepeat();
        public abstract void RemoveAllCitiesWithName(string name);
        public abstract int FindCity(string name);
        public abstract List<int> FindCitiesAtLetter(char letter);
        public abstract int FindOneCityAtLetter(char letter);
        public abstract int ComputeCitiesAtLetter(char letter);
    }
}
