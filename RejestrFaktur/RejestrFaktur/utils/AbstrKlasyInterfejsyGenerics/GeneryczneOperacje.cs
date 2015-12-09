using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RejestrFaktur.DAL;
using System.Data.Entity;

namespace RejestrFaktur.utils
{
    public abstract class GeneryczneOperacje<T> : IOperacje<T> where T : class, IHasID,  new()
    {
        /**
          Abstrakcyjna generyczna klasa implementująca jak najwięcej metod interfejsu
          IOperacje. Zrobiona po to żeby nie przepisywać tych metod, które nie różnią się dla różnych 
          klas T.
        **/


        public virtual int Dodaj(T t, RejestrFakturContext dbcontext)
        {
            try
            {
                DbSet<T> dbSet = dbcontext.Set<T>();
                dbSet.Add(t);
                dbcontext.SaveChanges();
                return t.Id;
            }
            catch
            {
                return -1;
            }
        }


        public abstract bool Edytuj(T t, RejestrFakturContext dbcontext);



        public virtual bool Ustaw(ObiektDoWidoku<T> obiektDW, Stany stan, int id)
        {
            T t = ZnajdzPoId(obiektDW.Lista, id);
            if (!(t == null))
            {
                obiektDW.Edytowany = t;
                obiektDW.StanObiektu = stan;
                return true;
            }
            else
            {
                obiektDW.Edytowany = default(T);
                obiektDW.StanObiektu = Stany.PRZEGLADANIE;
                return false;
            }
        }


        public virtual bool UstawNowy(ObiektDoWidoku<T> obiektDW)
        {
            T t = new T();
            obiektDW.Edytowany = t;
            obiektDW.StanObiektu = Stany.NOWY;
            return true;
        }

        public virtual void UstawPoczatkowe(ObiektDoWidoku<T> obiektDW, IEnumerable<T> lista)
        {
            obiektDW.StanObiektu = Stany.PRZEGLADANIE;
            obiektDW.Edytowany = default(T);
            obiektDW.Lista = lista;
        }


        public virtual void UstawPoczatkowe(ObiektDoWidoku<T> obiektDW, RejestrFakturContext dbcontext)
        {
            IEnumerable<T> lista = new List<T>();
            try
            {
                DbSet<T> dbSet = dbcontext.Set<T>();
                lista = dbSet.ToList();
            }
            catch
            {
            }
            UstawPoczatkowe(obiektDW, lista);
        }

        public virtual bool Usun(T t, RejestrFakturContext dbcontext)
        {
            DbSet<T> dbSet = dbcontext.Set<T>();
            T tTemp = ZnajdzPoId(dbSet, t.Id);
            try
            {
                dbSet.Remove(tTemp);
                dbcontext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public virtual T ZnajdzPoId(IEnumerable<T> kolekcjaOb, int id)
        {
            try
            {
                return kolekcjaOb.Single(i => i.Id == id);
            }
            catch
            {
                return default(T);
            }
        }
    }
}