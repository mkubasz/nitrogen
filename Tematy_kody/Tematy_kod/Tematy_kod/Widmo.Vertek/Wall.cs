using Tematy_kod.Widmo.Vertek;
namespace Tematy_kod
{
    public class Wall : Farba, IWall
    {
        
        public void Paint(Farba farba)
        {
            farba.Paint("czerwony");
            _cost = "1000";
            getValue();
            
        }
    }
}