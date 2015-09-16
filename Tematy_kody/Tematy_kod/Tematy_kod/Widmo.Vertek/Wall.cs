using System;
using Tematy_kod.Widmo.Vertek;
namespace Tematy_kod
{
    public class Wall : Farba, IWall 
    {
        
        public void Paint(Farba farba)
        {
            farba.Paint("czerwony");
            cost = "1000";
            getValue();
            
            
        }

        public void Show()
        {
           Console.WriteLine("dada_wall1");
        }
    }
}