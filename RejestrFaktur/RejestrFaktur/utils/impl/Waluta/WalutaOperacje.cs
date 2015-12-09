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
            throw new NotImplementedException();
        }
    }
}