using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homeworks.Igor.DataLoadSystem
{
    public interface ILoadDataSys
    {
        HashSet<string> GetData();
    }
}
