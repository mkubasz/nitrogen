using System;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExceptionTranslator.OpenSys;

namespace ExceptionTranslator
{
    public class ExceptionFactoryXml : AbstractFactory<int, string>
    {
        public ExceptionFactoryXml()
        {
            var file = new XmlOpenerSys("C:\\Users\\Igor\\Documents\\nitrogen\\ConverterDll\\ExceptionTranslator\\XML_List\\ExceptionList.xml");
            elements = new Dictionary<int, Func<string>>();
            foreach(var obj in file.getList())
            {
                elements.Add(obj.Key, () => obj.Value);
            }
        }
    }
}