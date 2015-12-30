using RejestrFaktur.DAL;
using RejestrFaktur.utils.AbstrKlasyInterfejsyGenerics;

namespace RejestrFaktur.utils.impl.PlatnoscTyp
{
    public class PlatnoscTypOperacje : GeneryczneOperacje<Models.PlatnoscTyp>
    {
        public override bool Edytuj(Models.PlatnoscTyp t, RejestrFakturContext dbcontext)
        {
            bool wart = false;
            try
            {
                Models.PlatnoscTyp temp = dbcontext.PlatnosciTypy.Find(t.Id);
                if (temp != null)
                {
                    temp.Nazwa = t.Nazwa;
                    temp.Opis = t.Opis;
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