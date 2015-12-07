using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RejestrFaktur.Models;
using RejestrFaktur.utils;
using System.Data.Entity;
using RejestrFaktur.DAL;

namespace RejestrFaktur.utils
{
    public class Opakowanie<T>:IOperacjeOpakowanie<T> where T: new()
    {
        
        private IOperacje<T> _ipostawoweOperacje;
        private RejestrFakturContext _dbcontext;
        private ObiektDoWidoku<T> _obiektDoWidoku;


        public IOperacje<T> PodstawoweOperacje {
               get { return _ipostawoweOperacje; }
               set {  _ipostawoweOperacje = value; }
        }

        public ObiektDoWidoku<T> ObiektDoWidoku
        {
            get { return _obiektDoWidoku;}
        }

        public Opakowanie(IOperacje<T> ipodst, RejestrFakturContext dbcontext)
        {
            _obiektDoWidoku = new ObiektDoWidoku<T>();
            _dbcontext = dbcontext;
            _ipostawoweOperacje = ipodst;
            _ipostawoweOperacje.UstawPoczatkowe(_obiektDoWidoku, _dbcontext);
        }

        public bool UstawDoEdycji(int id)
        {
            return _ipostawoweOperacje.Ustaw(_obiektDoWidoku, Stany.DO_EDYCJI, id);
        }

        public bool UstawDoPodgladu(int id)
        {
            return _ipostawoweOperacje.Ustaw(_obiektDoWidoku, Stany.SZCZEGOLY, id);
        }

        public bool UstawDoUsuniecia(int id)
        {
            return _ipostawoweOperacje.Ustaw(_obiektDoWidoku, Stany.DO_USUNIECIA, id);
        }

        public bool DodajObiekt(T t)
        {
            return (_ipostawoweOperacje.Dodaj(t, _dbcontext)>0);
        }

        public bool UsunObiekt(T t)
        {
            return _ipostawoweOperacje.Usun(t, _dbcontext);
        }

        public bool EdytujObiekt(T t)
        {
            return _ipostawoweOperacje.Edytuj(t, _dbcontext);
        }

        public bool UstawNowy()
        {
            return _ipostawoweOperacje.UstawNowy(_obiektDoWidoku);
        }

        public bool ZapiszObiekt(T t, Stany stan)
        {
           bool val=false;
           switch (stan)
            {
                case Stany.DO_EDYCJI:
                {
                        val = EdytujObiekt(t);
                        break;
                }

                case Stany.NOWY:
                    {
                        val = DodajObiekt(t);
                        break;
                    }

            }
            return val;
        }
    }
}