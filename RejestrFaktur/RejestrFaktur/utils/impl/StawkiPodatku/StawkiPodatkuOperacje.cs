using RejestrFaktur.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RejestrFaktur.DAL;

namespace RejestrFaktur.utils
{
    public class StawkiPodatkuOperacje : IOperacje<StawkaPodatku>
    {
        public int Dodaj(StawkaPodatku t, RejestrFakturContext dbcontext)
        {
            try
            {
                dbcontext.StawkiPodatku.Add(t);
                dbcontext.SaveChanges();
                return t.Id;
            }
            catch
            {
                return -1;
            }
        }

        public bool Edytuj(StawkaPodatku t, RejestrFakturContext dbcontext)
        {
            bool wart = false;
            try
            {
                StawkaPodatku temp = dbcontext.StawkiPodatku.Find(t.Id);
                if (temp != null)
                {
                    temp.NazwaStawki = t.NazwaStawki;
                    temp.WysokoscStawki = t.WysokoscStawki;
                    dbcontext.SaveChanges();
                    wart = true;
                }
            }
            catch
            {
            }
            return wart;
        }

        public bool Ustaw(ObiektDoWidoku<StawkaPodatku> obiektDW, Stany stan, int id)
        {
            StawkaPodatku objTemp = ZnajdzPoId(obiektDW.Lista, id);
            if (!(objTemp == default(StawkaPodatku)))
            {
                obiektDW.Edytowany = objTemp;
                obiektDW.StanObiektu = stan;
                return true;
            }
            else
            {
                obiektDW.Edytowany = default(StawkaPodatku);
                obiektDW.StanObiektu = Stany.PRZEGLADANIE;
                return false;
            }
        }

        public bool UstawNowy(ObiektDoWidoku<StawkaPodatku> obiektDW)
        {
            StawkaPodatku objTemp = new StawkaPodatku();
            obiektDW.Edytowany = objTemp;
            obiektDW.StanObiektu = Stany.NOWY;
            return true;
        }

        public void UstawPoczatkowe(ObiektDoWidoku<StawkaPodatku> obiektDW, IEnumerable<StawkaPodatku> lista)
        {
            obiektDW.StanObiektu = Stany.PRZEGLADANIE;
            obiektDW.Edytowany = default(StawkaPodatku);
            obiektDW.Lista = lista;
        }

        public void UstawPoczatkowe(ObiektDoWidoku<StawkaPodatku> obiektDW, RejestrFakturContext dbcontext)
        {
            IEnumerable<StawkaPodatku> lista = new List<StawkaPodatku>();
            try
            {
                lista = dbcontext.StawkiPodatku.ToList();
            }
            catch
            {

            }
            UstawPoczatkowe(obiektDW, lista);
        }

        public bool Usun(StawkaPodatku t, RejestrFakturContext dbcontext)
        {
            StawkaPodatku objTemp = ZnajdzPoId(dbcontext.StawkiPodatku, t.Id);
            try
            {
                dbcontext.StawkiPodatku.Remove(objTemp);
                dbcontext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public StawkaPodatku ZnajdzPoId(IEnumerable<StawkaPodatku> kolekcjaOb, int id)
        {
            try
            {
                return kolekcjaOb.Single(i => i.Id == id);
            }
            catch
            {
                return default(StawkaPodatku);
            }
        }
    }
}