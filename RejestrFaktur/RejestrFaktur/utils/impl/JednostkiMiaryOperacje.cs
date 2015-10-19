using RejestrFaktur.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RejestrFaktur.utils.impl
{
    public class JednostkiMiaryOperacje : IOperacjeOpakowanie<JednostkaMiary>
    {
        public JednostkaMiary ZnajdzPoId(IEnumerable<JednostkaMiary> kolekcjaOb, int id)
        {
            try
            {
                return kolekcjaOb.Single(i => i.Id == id);
            }
            catch
            {
                return default(JednostkaMiary);
            }
        }

        public JednostkaMiary ZnajdzTakiSam(IEnumerable<JednostkaMiary> kolekcjaOb, JednostkaMiary t)
        {
            JednostkaMiary j;
            JednostkaMiary def = default(JednostkaMiary);
            try
            {
                j = kolekcjaOb.Single(i => i.Id == t.Id);
                return (j.Equals(t))? j : def;
            }
            catch
            {
                return def;
            }      
        }
    }
}