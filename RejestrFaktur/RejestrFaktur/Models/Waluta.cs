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
    public class Waluta:IHasID
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DodatkoweAtrybuty("Nazwa waluty", StanAtr.WLICZAC)]
        [Required(ErrorMessage = "Musisz podać nazwę waluty")]
        [StringLength(65, ErrorMessage = "Nazwa waluty jest za długa, maks. długość 65 znaków")]
        [DisplayName("Nazwa waluty")]
        public string Nazwa { get; set; }

        [DodatkoweAtrybuty("Symbol waluty", StanAtr.WLICZAC)]
        [Required(ErrorMessage = "Musisz podać symbol waluty")]
        [StringLength(3, ErrorMessage = "Symbol waluty maks. 3 znaki")]
        [DisplayName("Symbol waluty")]
        public string Symbol { get; set; }


        public string SciezkaDoIkony { get; set; }


        public override bool Equals(object obj)
        {
            Waluta wal;
            if (obj != null && obj is StawkaPodatku)
            {
                wal = (Waluta)obj;
                return ((wal.Id == this.Id) && (wal.Nazwa == this.Nazwa) 
                 && (wal.Symbol == this.Symbol)
                 && (wal.SciezkaDoIkony == this.SciezkaDoIkony));
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
                hash = (hash * 7) + Nazwa.GetHashCode();
                hash = (hash * 7) + Symbol.GetHashCode();
                hash = (hash * 7) + SciezkaDoIkony.GetHashCode();
            }
            catch
            {
                hash = 0;
            }
            return hash;
        }


    }
}