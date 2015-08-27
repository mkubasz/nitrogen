using System;
using System.Collections.Generic;
using Startup.TrainingOneHomeworks.Rubi.PeselValidator.Interfaces;

namespace Startup.TrainingOneHomeworks.Rubi.PeselValidator
{
    public class PeselValidation:IPeselValidation
    {

        public bool ControlNumber(int pesel)
        {
            throw new NotImplementedException();
        }


        public bool IsPeselCorret(string pesel)
        {
            List<int> date= new List<int>();
            date.Add(Int32.Parse(pesel.Substring(0,2)));
            date.Add(Int32.Parse(pesel.Substring(2, 2)));
            date.Add(Int32.Parse(pesel.Substring(4, 2)));

            bool length = (pesel.Length == 11);
            var month = false;
            var daysFebruaryLeapsed = false;
            var daysFebruaryNormal = false;
            var shortMonth = false;
            var longMonth = false;
            var yC = new YearValidation().IsYearCorrect(date[0]);
            var yL = new YearValidation().IsLeapsedYear(date[0]);

            if (new MonthValidation().CorrectMonth1800(date[1]) ||
                new MonthValidation().CorrectMonth1900(date[1]) ||
                new MonthValidation().CorrectMonth2000(date[1]) ||
                new MonthValidation().CorrectMonth2100(date[1]) ||
                new MonthValidation().CorrectMonth2200(date[1]))
            {
                month = true;
            }

            if (yL ==true && 
                new MonthValidation().IsFebruary(date[1]) && 
                new DayValidation().LeapsedFebruary(date[2]))
            {
                daysFebruaryLeapsed = true;
            }
            else
            {
                if (yL == false && new MonthValidation().IsFebruary(date[1]) &&
                    new DayValidation().NormalFebruary(date[2]))
                {
                    daysFebruaryNormal = true;
                }
            }

            if (yL == false &&
                new MonthValidation().IsFebruary(date[1]) == false &&
                new MonthValidation().ShortMonth(date[1]) == true)
            {
                shortMonth = new DayValidation().ShortMonth(date[2]);
            }
            else if (yL == false &&
                     new MonthValidation().ShortMonth(date[1]) == false)
            {
                longMonth = new DayValidation().LongMonth(date[2]);
            }


            return yC && yL && month && (daysFebruaryLeapsed ||daysFebruaryNormal ||shortMonth || longMonth); //final ;
        }

        public bool ManOrWoman(string pesel)
        {
            throw new NotImplementedException();
        }

        public bool ControlNumber(string pesel)
        {
            throw new NotImplementedException(); 
        }
    }
}