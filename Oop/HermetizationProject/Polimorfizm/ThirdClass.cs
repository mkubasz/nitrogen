namespace Polimorfizm
{
#if true
    public class ThirdClass : ChildClass
    {
        public override bool methodTest()
        {
            return true;
        }

    }
#endif

#if false
    public class ThirdClass : SealdedClass
    {
        //public override bool methodTest()
        //{
        //    return true;
        //}

    }
#endif

    
}