using RejestrFaktur.DAL;
using RejestrFaktur.utils.AbstrKlasyInterfejsyGenerics;

namespace RejestrFaktur.utils.impl.Waluta
{
    public class WalutaOperacje : GeneryczneOperacje<Models.Waluta>
    {
        public override bool Edytuj(Models.Waluta t, RejestrFakturContext dbcontext)
        {
            bool wart = false;
            try
            {
                Models.Waluta temp = dbcontext.Waluty.Find(t.Id);
                if (temp != null)
                {
                    temp.Nazwa = t.Nazwa;
                    temp.Symbol = t.Symbol;
                    temp.SciezkaDoIkony = t.SciezkaDoIkony;
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