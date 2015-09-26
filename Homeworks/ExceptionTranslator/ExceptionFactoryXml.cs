using System;
using System.Collections.Generic;
using ExceptionTranslator.OpenSys;

namespace ExceptionTranslator
{
    public class ExceptionFactoryXml : AbstractFactory<int, string>
    {
        public ExceptionFactoryXml()
        {
            var file = new XmlOpenerSys("C:\\Users\\Igor\\Documents\\nitrogen\\Homeworks\\ExceptionTranslator\\XML_List\\ExceptionList.xml");
            Elements = new Dictionary<int, Func<string>>();
            foreach(var obj in file.GetList())
            {
                var obj1 = obj;
                Elements.Add(obj.Key, () => obj1.Value);
            }
        }
    }
}