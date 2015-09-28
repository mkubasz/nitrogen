using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Repozytorium.Models.View
{
    public class ZadanieViewModel
    {
        public IList<Zadanie> Zadania { get; set; }
        public string NazwaUzytkownika { get; set; }
    } 


    }
