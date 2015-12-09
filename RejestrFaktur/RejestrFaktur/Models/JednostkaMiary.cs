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
    public class JednostkaMiary:IHasID
    {
        public JednostkaMiary()
        {
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DodatkoweAtrybuty("Nazwa jednostki miary", StanAtr.WLICZAC,Dodatkowy = "nazwa")]
        [Required(ErrorMessage = "Musisz podać nazwę jednostki miary")]
        [StringLength(65, ErrorMessage = "Nazwa jednostki miary jest za długa, maks. długość 65 znaków")]
        [DisplayName("Nazwa jednostki")]
        public string NazwaJednostki { get; set; }

        [Required(ErrorMessage = "Musisz podać symbol jednostki miary")]
        [StringLength(3, ErrorMessage = "Nazwa symbolu jednostki miary jest za długa, maks. długość 3 znaki")]
        [DisplayName("Symbol jednostki")]
        public string SymbolJednostki { get; set; }

        public override bool Equals(object obj)
        {
            JednostkaMiary j;
            if (obj != null && obj is JednostkaMiary)
            {
                j = (JednostkaMiary)obj;
                return ((j.Id == this.Id) && (j.NazwaJednostki == this.NazwaJednostki) && (j.SymbolJednostki == this.SymbolJednostki));
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
                hash = (hash * 7) + NazwaJednostki.GetHashCode();
                hash = (hash * 7) + SymbolJednostki.GetHashCode();
            }
            catch
            {
                hash = 0;
            }
            return hash;
        }
    }
}
