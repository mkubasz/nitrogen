using RejestrFaktur.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RejestrFaktur.utils.impl
{
    public class OpakowaniePlatnoscTypFactory : IOperacjeOpakowanieFactory<PlatnoscTypOperacje>
    {
        public PlatnoscTypOperacje create()
        {
            return new PlatnoscTypOperacje();
        }

    }
}