namespace AbstractObj
{
    public class CarModel : AbstractModel
    {
        public bool Steer()
        {
            return true;
        }
        
        public override void Drive()
        {
            Steer();
        }

        public override string Steady()
        {
            return "brumbrum";
        }
    }
}