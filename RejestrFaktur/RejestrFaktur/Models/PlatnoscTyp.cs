using RejestrFaktur.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RejestrFaktur.Models
{
    public class PlatnoscTyp : IHasID
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DodatkoweAtrybuty("Nazwa sposobu płatności", StanAtr.WLICZAC, Dodatkowy = "nazwa")]
        [Required(ErrorMessage = "Musisz podać nazwę sposobu płatności")]
        [StringLength(55, ErrorMessage = "Nazwa płatności jest za długa, maks. długość 55 znaków")]
        [DisplayName("Nazwa płatności")]
        public string Nazwa { get; set; }


        [DodatkoweAtrybuty("Opis sposobu płatności", Stan = StanAtr.WLICZAC, Dodatkowy = "opis")]
        [StringLength(128, ErrorMessage = "Nazwa opisu płatności jest za długa, maks. długość 128 znaków")]
        [DisplayName("Opis płatności")]
        public string Opis { get; set; }

        public override bool Equals(object obj)
        {
            PlatnoscTyp pt;
            if (obj != null && obj is PlatnoscTyp)
            {
                pt = (PlatnoscTyp) obj;
                return ((pt.Id == this.Id) && (pt.Nazwa == this.Nazwa) && (pt.Opis == this.Opis));
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            int hash = 13;
            try
            {
                hash = (hash*7) + Id.GetHashCode();
                hash = (hash*7) + Nazwa.GetHashCode();
                hash = (hash*7) + Opis.GetHashCode();
            }
            catch
            {
                hash = 0;
            }
            return hash;
        }
    }
}