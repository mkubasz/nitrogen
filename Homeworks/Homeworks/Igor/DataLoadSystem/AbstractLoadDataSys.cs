using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homeworks.Igor.DataLoadSystem
{
    interface AbstractLoadDataSys
    {
        HashSet<string> GetData();
    }
}
