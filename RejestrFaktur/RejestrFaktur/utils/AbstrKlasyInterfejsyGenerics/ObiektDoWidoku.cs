using System.Collections.Generic;
using RejestrFaktur.utils.pozostale;

namespace RejestrFaktur.utils.AbstrKlasyInterfejsyGenerics
{
    public class ObiektDoWidoku<T> : IDoWidokow<T> where T:class,new()
    {
        private IEnumerable<T> _lista;
        private T _edytowany;
        private Stany _stanObiektu;

        public ObiektDoWidoku()
        {
            _lista = new List<T>();
            _edytowany = new T();
            _stanObiektu = Stany.PRZEGLADANIE;
        }

        public IEnumerable<T> Lista
        {
            get { return _lista; }
            set { _lista = value; }
        }

        public T Edytowany
        {
            get { return _edytowany; }
            set { _edytowany = value; }
        }

        public Stany StanObiektu
        {
            get { return _stanObiektu; }
            set { _stanObiektu = value; }
        }
    }
}