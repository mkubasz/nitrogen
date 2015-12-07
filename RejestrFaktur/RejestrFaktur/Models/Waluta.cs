using RejestrFaktur.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RejestrFaktur.Models
{
    public class Waluta
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [DodatkoweAtrybuty("Nazwa waluty", StanAtr.WLICZAC)]
        [Required]
        public string Nazwa { get; set; }
        [DodatkoweAtrybuty("Symbol waluty", StanAtr.WLICZAC)]
        [Required]
        public string Symbol { get; set; }
        public string SciezkaDoIkony { get; set; }
    }
}