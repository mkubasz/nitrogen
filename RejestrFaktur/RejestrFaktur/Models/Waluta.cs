using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RejestrFaktur.Models
{
    public class Waluta
    {
            public int Id { get; set; }
            public string Nazwa { get; set; }
            public string Symbol { get; set; }
            public string SciezkaDoIkony { get; set; }
    }
}