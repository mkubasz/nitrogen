using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RejestrFaktur.Models
{
    public class JednostkiMiary
    {
        public JednostkiMiary()
        {
        }

        public int Id { get; set; }
        public string NazwaJednostki { get; set; }
        public string SymbolJednostki { get; set; }
    }
}
