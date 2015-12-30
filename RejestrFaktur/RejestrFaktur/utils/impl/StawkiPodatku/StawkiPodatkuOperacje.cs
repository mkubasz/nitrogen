using RejestrFaktur.DAL;
using RejestrFaktur.Models;
using RejestrFaktur.utils.AbstrKlasyInterfejsyGenerics;

namespace RejestrFaktur.utils.impl.StawkiPodatku
{
    public class StawkiPodatkuOperacje : GeneryczneOperacje<StawkaPodatku>
    {

        public override bool Edytuj(StawkaPodatku t, RejestrFakturContext dbcontext)
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
    }
}