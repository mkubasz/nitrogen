using System;
using System.Security.Cryptography.X509Certificates;

namespace AbstractObj
{
    public class PlaneModel : AbstractModel
    {
        public bool Fly()
        {
            return true;
        }
        public override void Drive()
        {
            Fly();

        }

        public override string Steady()
        {

            return "Szzzzzzzzzzzzzz";
        }

        public override void spij()
        {
            Console.WriteLine("nie spie");
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