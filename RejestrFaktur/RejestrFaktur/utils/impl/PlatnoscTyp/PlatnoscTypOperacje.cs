using RejestrFaktur.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RejestrFaktur.DAL;

namespace RejestrFaktur.utils
{
    public class PlatnoscTypOperacje : GeneryczneOperacje<PlatnoscTyp>
    {
        public override bool Edytuj(PlatnoscTyp t, RejestrFakturContext dbcontext)
        {
            bool wart = false;
            try
            {
                PlatnoscTyp temp = dbcontext.PlatnosciTypy.Find(t.Id);
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