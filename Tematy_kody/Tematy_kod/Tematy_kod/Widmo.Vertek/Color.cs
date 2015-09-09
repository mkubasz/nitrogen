namespace Tematy_kod.Widmo.Vertek
{
    public class Color
    {
        public void Rysuj(IWall iwall)
        {
           iwall.Show();
           
          
        }

        public void NOwa()
        {
            Wall2 wall2 = new Wall2();
            Wall wall1 = new Wall();
            Rysuj(wall2);
            Rysuj(wall1);
        }
    }
}