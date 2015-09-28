using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Repozytorium.Models.View
{
    public class RozwiazanieViewModel
    {
        public IList<Rozwiazanie> Rozwiazania { get; set; }
        public string NazwaZadania { get; set; }
    } 


    }
