using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RejestrFaktur.DAL;
using RejestrFaktur.Models;

namespace RejestrFaktur.utils
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
            }
            return wart;
        }

    }
}