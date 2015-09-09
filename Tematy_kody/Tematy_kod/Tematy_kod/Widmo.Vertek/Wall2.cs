using Tematy_kod.Widmo.Vertek;

namespace Tematy_kod
{
    public class Wall2 : Farba, IWall
    {
        public void Paint(Farba farba)
        {
            farba.Paint("niebieski");
            _cost = "3000";
            getValue();
        }
    }
}