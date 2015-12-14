using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RejestrFaktur.DAL;
using RejestrFaktur.Models;

namespace RejestrFaktur.utils
{
    public class WalutaOperacje : GeneryczneOperacje<Waluta>
    {
        public override bool Edytuj(Waluta t, RejestrFakturContext dbcontext)
        {
            bool wart = false;
            try
            {
                Waluta temp = dbcontext.Waluty.Find(t.Id);
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