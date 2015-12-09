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
            throw new NotImplementedException();
        }
    }
}