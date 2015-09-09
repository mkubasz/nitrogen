using System;
using Tematy_kod.Widmo.Vertek;

namespace Tematy_kod
{
    public class Wall2 : Farba, IWall
    {
        public void Paint(Farba farba)
        {
            Wall2 wall = new Wall2();
            wall.Paint("sad");
            this.Paint("bialy");
            farba.Paint("niebieski");
            cost = "3000";
            getValue();
        }

        public void Show()
        {
            Console.WriteLine("sada_wall2");
        }
    }
}