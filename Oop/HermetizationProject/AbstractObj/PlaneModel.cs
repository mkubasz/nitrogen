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

    }
}