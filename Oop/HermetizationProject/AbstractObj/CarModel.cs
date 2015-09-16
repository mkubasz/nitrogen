using System;

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

        public override void spij()
        {
            Console.WriteLine("spie");
        }

        public override void jedz()
        {
            throw new System.NotImplementedException();
        }

        public override void zle()
        {
            throw new NotImplementedException();
        }
    }
}