using RejestrFaktur.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RejestrFaktur.utils.impl
{
    public class PlatnoscTypOperacje : IOperacjeOpakowanie<PlatnoscTyp>
    {
        public PlatnoscTyp ZnajdzPoId(IEnumerable<PlatnoscTyp> kolekcjaOb, int id)
        {
            try
            {
                return kolekcjaOb.Single(i => i.Id == id);
            }
            catch
            {
                return default(PlatnoscTyp);
            }
        }

        public PlatnoscTyp ZnajdzTakiSam(IEnumerable<PlatnoscTyp> kolekcjaOb, PlatnoscTyp t)
        {
            {
                PlatnoscTyp pt;
                PlatnoscTyp def = default(PlatnoscTyp);
                try
                {
                    pt = kolekcjaOb.Single(i => i.Id == t.Id);
                    return (pt.Equals(t)) ? pt : def;
                }
                catch
                {
                    return def;
                }
            }
        }
    }
}