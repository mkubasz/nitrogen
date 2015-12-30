using System;

namespace RejestrFaktur.utils.AbstrKlasyInterfejsyGenerics
{
    public class ObslugaDelegaty<T,V>
    {
        public Action<T, V> delegaty;

        public void Obsluz(T t, V v)
        {
            delegaty(t, v);
        }
    }
}