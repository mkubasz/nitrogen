using System.Collections.Generic;
using System.Linq;
using Homeworks.Igor.DataLoadSystem;
using Homeworks.Igor.OperationSystem;
using ExceptionTranslator;

namespace Homeworks.Igor
{
    public class ClientOperator
    {
        protected List<string> DataSet;

        public ClientOperator(ILoadDataSys loadSys)
        {
            DataSet = new List<string>();
            DataSet = loadSys.GetData();
        }

        public void AddData(string obj)
        {
            if(obj!="")
            {
                DataSet.Add(obj);
            }
            else throw new ExceptionTran(ExceptionsPack.StringIsEmpty);
        }

        public List<string> GetList()
        {
            return DataSet.ToList();
        }

        public List<string> GetResult(IOperation operation)
        {
            return operation.GetResult(DataSet);
        }

        public List<string> GetSetResult(IOperation operation)
        {
            this.DataSet = operation.GetResult(DataSet);
            return this.DataSet;
        }
    }
}
