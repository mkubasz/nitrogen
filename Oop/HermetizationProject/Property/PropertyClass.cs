namespace Property
{
    public class PropertyClass
    {
        public int TestProperty { get; set; } 
        //tylko w wersji C# 6.0
        public int TestPropertyPrivate => _propertyPrivate; 
        private int _propertyPrivate = 10;
        //dla wczesniejszych jezykow
        public int TestPropertyOld { get { return _propertyPrivate; } set { _propertyPrivate = value; } }
        /// <summary>
        /// </summary>
        public int Property { get; private set; }

        public PropertyClass()
        {
            
        }


    }
}