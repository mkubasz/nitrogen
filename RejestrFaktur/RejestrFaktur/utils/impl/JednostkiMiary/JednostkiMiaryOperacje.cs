using RejestrFaktur.DAL;
using RejestrFaktur.Models;
using RejestrFaktur.utils.AbstrKlasyInterfejsyGenerics;

namespace RejestrFaktur.utils.impl.JednostkiMiary
{
    public class JednostkiMiaryOperacje: GeneryczneOperacje<JednostkaMiary>
    {
 
        public override bool Edytuj(JednostkaMiary t, RejestrFakturContext dbcontext)
        {
            bool wart = false;
            try
            {
                JednostkaMiary temp = dbcontext.JednostkiMiar.Find(t.Id);
                if (temp != null)
                {
                    temp.NazwaJednostki = t.NazwaJednostki;
                    temp.SymbolJednostki = t.SymbolJednostki;
                    dbcontext.SaveChanges();
                    wart = true;
                }
            }
            catch
            {
                // ignored
            }
            return wart;
        }
    }
}