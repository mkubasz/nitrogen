using System.Collections.Generic;
namespace Startup.TrainingOneHomeworks.AndzejC.Banki.Abstrakty
{
    public abstract class GenFactory<T1>
    {
        protected Dictionary<string, T1> ItemList;

        public T1 GetElement(string key)
        {
            return ItemList[key];
        }
    }
}