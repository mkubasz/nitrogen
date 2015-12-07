using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RejestrFaktur.utils
{
    public class ObiektDoWidoku<T> : IDoWidokow<T>
    {
        private IEnumerable<T> _lista;
        private T _edytowany;
        private Stany _stanObiektu;

        public ObiektDoWidoku()
        {
            _lista = new List<T>();
            _edytowany = default(T);
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