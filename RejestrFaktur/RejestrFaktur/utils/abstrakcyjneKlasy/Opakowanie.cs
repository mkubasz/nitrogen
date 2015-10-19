using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RejestrFaktur.Models;
using RejestrFaktur.utils;

namespace RejestrFaktur.utils
{
    public class Opakowanie<T>
    {
        private IEnumerable<T> _lista;
        private IOperacjeOpakowanie<T> _ipostawoweOperacje;
        public IEnumerable<T> Lista { get { return _lista; }}
        private T _edytowany;
        private Stany _stanObiektu;

        public T Edytowany { get { return _edytowany; } }
        public Stany StanObiektu { get { return _stanObiektu; } }


        public Opakowanie(IOperacjeOpakowanie<T> ipodst)
        {
            _lista = new List<T>();
            _ipostawoweOperacje = ipodst;
            _edytowany = default(T);
            _stanObiektu = Stany.PRZEGLADANIE;
        }

        public Opakowanie(IEnumerable<T> lista, IOperacjeOpakowanie<T> ipods) : this(ipods)
        {
            _lista = lista;
        }

        public T ZnajdzPoId(int id)
        {
            try
            {
                return _ipostawoweOperacje.ZnajdzPoId(_lista, id);
            }
            catch
            {
                return default(T);
            }
        }

        public bool ustawDoEdycji(int id)
        {
            T t = ZnajdzPoId(id);
            bool val = false;
            if (t!=null)
            {
                _stanObiektu = Stany.DO_EDYCJI;
                _edytowany = t;
                val = true;
            }
            else
            {
                _stanObiektu = Stany.PRZEGLADANIE;
                _edytowany = default(T);
            }
            return val;
        }
    }
}