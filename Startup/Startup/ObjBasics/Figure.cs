using Startup.ObjBasics.Interfaces;

namespace Startup.ObjBasics
{
    public abstract class Figure : IFigure, IHuman
    {
        protected string IconPath;

        protected Figure(string path) 
        {
            Shape();
            IconPath = path;
        }

        public int Colour(IHuman fig, int i = 0)
        {
            fig.Laugh();

            throw new System.NotImplementedException();
        }

        public int Colour()
        {
            return 0;
        }

        public abstract bool Move(int x, int y); // abstract virtual


        public virtual string Shape()
        {
            return IconPath;
        }

        public void Laugh()
        {
            throw new System.NotImplementedException();
        }
    }
}