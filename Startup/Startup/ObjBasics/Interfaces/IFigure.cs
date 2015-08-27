namespace Startup.ObjBasics.Interfaces
{
    public interface IFigure
    {
        int Colour();

        bool Move(int x, int y);

        string Shape();
    }
}