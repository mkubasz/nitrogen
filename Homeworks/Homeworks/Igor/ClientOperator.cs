using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homeworks.Igor.DataLoadSystem;
using Homeworks.Igor.OperationSystem;

namespace Homeworks.Igor
{
    public class ClientOperator
    {
        protected HashSet<string> DataSet = new HashSet<string>();

        public ClientOperator(ILoadDataSys LoadSys)
        {
            DataSet = LoadSys.GetData();
        }

        public HashSet<string> GetResult(IOperation operation)
        {
            return operation.getResult(DataSet);
        }

        public HashSet<string> GetSetResult(IOperation operation)
        {
            this.DataSet = operation.getResult(DataSet);
            return this.DataSet;
        }
    }
}
