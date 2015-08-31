using System;

namespace Startup.TrainingOneHomeworks.GroupMati.Pesel
{
    public class DateOfBirthd
    {
        public DateTime dateTime { get; set; }

        public DateTime GetDateOfBirth(string pesel)
        {
            DateTime time;
            if (PeselValidator.CheckPesel(pesel) == true)
            {
                int year = Convert.ToInt32(pesel.Substring(0, 2));
                int month = Convert.ToInt32(pesel.Substring(2, 2));
                int day = Convert.ToInt32(pesel.Substring(4, 2));

                int testyear = year;
                int testmonth = month % 20;
                int testday = day;
                if (month / 20 == 4) testyear += 1800;
                if (month / 20 == 0) testyear += 1900;
                if (month / 20 == 1) testyear += 2000;

                try
                {
                    time = new DateTime(testyear, testmonth, testday);
                }
                catch (ArgumentOutOfRangeException arg)
                {
                    throw new InvalidPeselExeptions("Wrong data in Pesel");
                }
                return time;
            }
            throw new InvalidPeselExeptions("Wrong data in Pesel");

        }
    }
}