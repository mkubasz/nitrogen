using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace lDoran
{
    public static class Txt2XmlConverter
    {
        public static void Convert(string input, string output)
        {
            SaveXml(ReadFile(input), output);
        }

        private static List<Bank> ReadFile(string input)
        {
            List<Bank> result = new List<Bank>();

            try
            {
                using (StreamReader reader = File.OpenText(input))
                {
                    string str = "";
                    
                    while ((str = reader.ReadLine()) != null)
                    {
                        result.Add(Parse(str));
                    }                  
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

            return result;
        }

        private static Bank Parse(string line)
        {
            string[] result = Regex.Split(line, @"(\d+)\s+\d+\s+");
            return new Bank(result[1], result[2]);
        }

        private static void SaveXml(List<Bank> listOfBanks, string output)
        {
            XElement xmlBanks = new XElement("banks");

            foreach (Bank bank in listOfBanks)
            {
                xmlBanks.Add(new XElement(
                    "bank",
                    new XElement("id", bank.Id),
                    new XElement("name", bank.Name)
                    ));
            }

            XDocument doc = new XDocument(xmlBanks);
            doc.Save(output);
        }
    }
}
