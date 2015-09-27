using System.Collections.Generic;
using System.Linq;
using ExceptionTranslator;
using Homeworks.Igor.DataLoadSystem;

namespace Homeworks.Igor
{
    public class CityClientOperator : ClientOperator<City>
    {
        public CityClientOperator(ILoadDataSys<City> loadSys)
        {
            DataSet = new List<City>();
            DataSet = loadSys.GetData();
        }

        public override void AddData(string obj)
        {
            if(obj!="")
            {
                DataSet.Add(new City(obj));
            }
            else throw new ExceptionTran(ExceptionsPack.StringIsEmpty);
        }

        public override void RemoveRepeat()
        {
            var ret = new List<City>();
            foreach (var obj in DataSet.Where(obj => ret.All(city => city.CityName != obj.CityName)))
            {
                ret.Add(obj);
            }
            DataSet = ret;
        }

        public override void RemoveAllCitiesWithName(string name)
        {
            DataSet.RemoveAll(city => city.CityName == name);
        }

        public override int FindCity(string name)
        {
            return DataSet.FindIndex(city => city.CityName == name);
        }

        public override List<int> FindCitiesAtLetter(char letter)
        {
            return DataSet.Where(city => city.CityName[0] == letter).Select(obj => DataSet.FindIndex(city => city.CityName == obj.CityName)).ToList();
        }

        public override int FindOneCityAtLetter(char letter)
        {
            return DataSet.FindIndex(city => city.CityName[0] == letter);
        }

        public override int ComputeCitiesAtLetter(char letter)
        {
            return DataSet.Count(city => city.CityName[0] == letter);
        }
    }
}
