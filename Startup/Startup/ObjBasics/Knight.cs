using Startup.ObjBasics.Interfaces;

namespace Startup.ObjBasics
{
    public class Knight : Figure
    {
        public Knight() : base("adyfgdy") 
        {
            Shape();

           // Colour(new Knight());
        }

        public override bool Move(int x, int y)
        {
            throw new System.NotImplementedException();
        }

        public override sealed string Shape()
        {
            //return base.Shape();

            return "";
        }
    }

    public class A
    {
        public B t;

        public A()
        {
            t = new B();
        }
    }

    public class B
    {
        public A t;

        public B()
        {
            t = new A();
        }
    }
}