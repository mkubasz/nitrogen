using System.Collections.Generic;
using System.Linq;

namespace Startup.TrainingOneHomeworks.AndzejC.Pesel
{
    public static class DateGetCheck
    {
        
        private static int CutMonth(int month)
        {
            return month%20;
        }
        private static int CutYear(int month)
        {
            var yearGenerator = new Dictionary<int, int> {{80, 1900}, {60, 2220}, {40, 2100}, {20, 2000}, {0, 1900}};
            return (from key in yearGenerator.Keys where key > month select yearGenerator[key]).FirstOrDefault();
        }


        public static string GetYear(string pesel)
        {
            return (int.Parse(pesel.Substring(0, 2)) + CutYear(int.Parse(pesel.Substring(2, 2)))).ToString();
        }
        public static string GetMonth(string pesel)
        {
            var month = CutMonth(int.Parse(pesel.Substring(2, 2)));
            if (month < 10) return "0" + month;
            return month.ToString();
        }
        public static string GetDay(string pesel)
        {
            return pesel.Substring(4, 2);
        }
        public static string GetDateFromPesel(string pesel)
        {
            return GetDay(pesel) + GetMonth(pesel) + GetYear(pesel);
        }
            
        public static bool DateCheck(string pesel)
        {
            return IsValidateDate(int.Parse(GetYear(pesel)), int.Parse(GetMonth(pesel)), int.Parse(GetDay(pesel)));
        }
        public static bool DateCheck(int year, int month, int day)
        {
            return IsValidateDate(year, month, day);
        }
        private static bool IsValidateDate(int year, int month, int day)
        {
            if (month > 12 || month == 0) return false;
            int[] daysInMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            if (year % 4 == 0 && year % 100 != 0 || year % 400 == 0)
            {
                daysInMonth[1] = 29;
            }
            return day <= daysInMonth[month - 1];
        }
    } 
}
