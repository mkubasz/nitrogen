using System;
using System.Collections.Generic;

namespace Startup.TrainingOneHomeworks.GroupMati.Bank.Factory
{
    public class AbstractFactoryBankTransaction <TK,T>
    {
        /// <summary>
        /// Beautiful abstrac factory delegat dictonary usless code
        /// </summary>
        #region DictionaryDelegate

            public Dictionary<TK, Func<T>> BankDictionary;

            public void Add(TK key, T value)
            {
                 BankDictionary.Add(key,() => value); 
            }

            public Func<T> GetValue(TK key)
            {
                return BankDictionary[key];
            }

            public T GetItem(TK key)
            {
                if (BankDictionary.ContainsKey(key))
                  return BankDictionary[key]();
                else
                {
                    return (T)(object)null;
                }
            } 
        #endregion
    }
}