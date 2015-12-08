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
    public class StawkaPodatku
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [DodatkoweAtrybuty("Nazwa stawki", StanAtr.WLICZAC)]
        [Required(ErrorMessage = "Musisz podać nazwę stawki podatku")]
        [StringLength(120, ErrorMessage = "Nazwa stawki podatku jest za długa, maks. długość 120 znaków")]
        [DisplayName("Nazwa stawki")]
        public string NazwaStawki { get; set; }

        [Required(ErrorMessage = "Musisz podać wysokość stawki podatku")]
        [Range(typeof(decimal), "0,00", "99,99",ErrorMessage = "Wysokość stawki podatku musi być większa lub równa zero i mniejsza niż 100")]
        [DisplayName("Wysokość stawki")]
        public decimal WysokoscStawki { get; set; }

        public override bool Equals(object obj)
        {
            StawkaPodatku sp;
            if (obj != null && obj is StawkaPodatku)
            {
                sp = (StawkaPodatku)obj;
                return ((sp.Id == this.Id) && (sp.NazwaStawki == this.NazwaStawki) && (sp.WysokoscStawki == this.WysokoscStawki));
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
                hash = (hash * 7) + (Id.GetHashCode());
                hash = (hash * 7) + NazwaStawki.GetHashCode();
                hash = (hash * 7) + WysokoscStawki.GetHashCode();
            }
            catch
            {
                hash = 0;
            }
            return hash;
        }
    }
}