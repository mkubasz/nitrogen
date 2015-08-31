namespace Startup.TrainingOneHomeworks.GroupMati.Pesel
{
    public class Gender
    {

        public string Sex
        {
            get
            {
                if (this.Sex != null)
                    return this.Sex;
                else return null;
            }
            set { this.Sex = value; }
        }

        public string CheckGender(string pesel)
            {
                if (pesel[9] % 2 == 0) this.Sex = "Female";
                else this.Sex = "Male";
                return this.Sex;
            }
        }
}