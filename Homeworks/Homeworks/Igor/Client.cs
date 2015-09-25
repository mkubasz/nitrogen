using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homeworks.Igor.DataLoadSystem;

namespace Homeworks.Igor
{
    public class Client
    {
        HashSet<string> DataSet = new HashSet<string>();

        public Client(AbstractLoadDataSys LoadSys)
        {
            DataSet = LoadSys.GetData();
        }
    }
}
