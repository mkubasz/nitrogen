using System;

namespace Polimorfizm
{
    public class BaseClass
    {
        public int zmienna = 10;

        public int done(int a)
        {
            a = zmienna;
            return a;

        }
        public virtual bool methodTest()
        {
            return true;
        }

        public virtual int Ania(int a)
        {
            a = zmienna;
            return a;
        }
    }
}