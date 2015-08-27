namespace Startup.ObjBasics
{
    public class Rubish // abstract sealed
    {
        public Rubish()
        {
            
        }

        private int Age;
        private int Century;
        protected int Month;

        public void CloudComputing() //static
        {
            Age = Century;
        }
    }

    public class RubishExtending : Rubish // Bul Ang PolaK Hisz
    {
        public void MEthodInExtendingClass()
        {
            //this.Century
        }
    }

    public class RubishClient
    {
        public void DragAndDrop()
        {
            Rubish rubish = new Rubish(); 
            Rubish moreRubish = new Rubish();

            rubish.CloudComputing();

            //Rubish u = new ;

            //Utils.Validate();
        }
    }

    public static class Utils
    {
        public static bool Validate(Patient p)
        {
            //p.CashInsurance();

            return true;
        }
    }

    public abstract class Human
    {
        private int example;

        protected int Gender;
    }

    public abstract class Patient : Human
    {
        public abstract string CountryCode(string NationalIdentified);

        protected abstract bool IsMyResponsibility(string NationalIdentified);


        public void CashInsurance(string NationalIdentified)
        {
            if (IsMyResponsibility(NationalIdentified))
            {
                
            }
        }
    }

    public class PolishPatient : Patient
    {

        public override string CountryCode(string NationalIdentified)
        {
            //
            return "PL";
        }

        protected override bool IsMyResponsibility(string NationalIdentified)
        {

            throw new System.NotImplementedException();
        }
    }

    public class ItalianPatient : Patient
    {
        public override string CountryCode(string NationalIdentified)
        {
            throw new System.NotImplementedException();
        }

        protected override bool IsMyResponsibility(string NationalIdentified)
        {
            //Singleton s = new Singleton();
            throw new System.NotImplementedException();
        }
    }

    public abstract class Singleton
    {
        protected Singleton()
        {
            Test();// override sealed


            Hour h = new Hour();
            h.hour = new Hour();
            h.hour.hour = new Hour();
        }

        protected abstract void Test();
    }

    public class Hour
    {
        public Hour hour;

        private int Ticks;

        public void ChangeTicks(Hour hour)
        {
            hour.Ticks = 9;
        }
    }



}