using RejestrFaktur.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RejestrFaktur.Models
{
    public class StawkaPodatku
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [DodatkoweAtrybuty("Nazwa stawki", StanAtr.WLICZAC)]
        [Required]
        public string NazwaStawki { get; set; }
        [Required]
        //[Range(typeof(decimal), "0.00", "49.99")]
        public decimal WysokoscStawki { get; set; }
    }
}