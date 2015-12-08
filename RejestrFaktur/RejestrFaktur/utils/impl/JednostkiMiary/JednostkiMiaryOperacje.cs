using RejestrFaktur.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using RejestrFaktur.DAL;

namespace RejestrFaktur.utils
{
    public class JednostkiMiaryOperacje : IOperacje<JednostkaMiary>
    {

        public bool Ustaw(ObiektDoWidoku<JednostkaMiary> obiektDW, Stany stan, int id)
        {
            JednostkaMiary jm = ZnajdzPoId(obiektDW.Lista, id);
            if (!(jm==default(JednostkaMiary)))
            {
                obiektDW.Edytowany = jm;
                obiektDW.StanObiektu = stan;
                return true;
            }
            else
            {
                obiektDW.Edytowany = default(JednostkaMiary);
                obiektDW.StanObiektu = Stany.PRZEGLADANIE;
                return false;
            }
        }

        public void UstawPoczatkowe(ObiektDoWidoku<JednostkaMiary> obiektDW, IEnumerable<JednostkaMiary> lista)
        {
            obiektDW.StanObiektu = Stany.PRZEGLADANIE;
            obiektDW.Edytowany = default(JednostkaMiary);
            obiektDW.Lista = lista;
        }

        public void UstawPoczatkowe(ObiektDoWidoku<JednostkaMiary> obiektDW, RejestrFakturContext dbcontext)
        {
            IEnumerable<JednostkaMiary> lista = new List<JednostkaMiary>();
            try
            {
                lista = dbcontext.JednostkiMiar.ToList();
            }
            catch
            {

            }
            UstawPoczatkowe(obiektDW, lista);
        }


        public JednostkaMiary ZnajdzPoId(IEnumerable<JednostkaMiary> kolekcjaOb, int id)
        {
            try
            {
                return  kolekcjaOb.Single(i => i.Id == id);
            }
            catch
            {
                return default(JednostkaMiary);
            }
        }

        public bool Usun(JednostkaMiary t, RejestrFakturContext dbcontext)
        {
            JednostkaMiary jm = ZnajdzPoId(dbcontext.JednostkiMiar, t.Id);
            try
            {
                dbcontext.JednostkiMiar.Remove(jm);
                dbcontext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
            
        }

        public bool Edytuj(JednostkaMiary t, RejestrFakturContext dbcontext)
        {
            bool wart = false;
            try
            {
                JednostkaMiary temp = dbcontext.JednostkiMiar.Find(t.Id);
                if (temp!=null)
                {
                    temp.NazwaJednostki = t.NazwaJednostki;
                    temp.SymbolJednostki = t.SymbolJednostki;
                    dbcontext.SaveChanges();
                    wart = true;
                }         
            }
            catch
            {            
            }
            return wart;
        }

        public int Dodaj(JednostkaMiary t, RejestrFakturContext dbcontext)
        {
            try
            {
                dbcontext.JednostkiMiar.Add(t);
                dbcontext.SaveChanges();
                return t.Id;
            }
            catch
            {
                return -1;
            }    
        }

        public bool UstawNowy(ObiektDoWidoku<JednostkaMiary> obiektDW)
        {

            JednostkaMiary jm = new JednostkaMiary();
            obiektDW.Edytowany = jm;
            obiektDW.StanObiektu = Stany.NOWY;
            return true;
        }
    }
}