namespace Polimorfizm
{
    public class ChildClass : BaseClass
    {
        public int value = 20;

        public sealed override bool methodTest()
        {
           return true;
        }

        public override int Ania(int a)
        {
            a = value;
            return a;
        }

    }
}