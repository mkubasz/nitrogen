using RejestrFaktur.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RejestrFaktur.utils.impl
{
    public class OpakowanieJednostkiFactory : IOperacjeOpakowanieFactory<JednostkiMiaryOperacje>
    {
        public JednostkiMiaryOperacje create()
        {
            return new JednostkiMiaryOperacje();
        }
    }
}