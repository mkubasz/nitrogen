using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homeworks.Igor.DataLoadSystem
{
    internal class XMLDataLoader : AbstractLoadDataSys
    {
        HashSet<string> data = new HashSet<string>();

        public XMLDataLoader(string path)
        {

        }

        HashSet<string> GetData()
        {
            return this.data;
        }
    }
}
