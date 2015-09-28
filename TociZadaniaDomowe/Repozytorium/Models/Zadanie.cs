using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Repozytorium.Models
{
    public class Zadanie //pola w tabeli
    {
        [Display(Name="ID:")]
        public int Id { get; set; }

        [Display(Name = "Temat:")]
        [MaxLength(100)]
        public string TematZadania { get; set; }


        [Display(Name = "Treść:")]
        [DataType(DataType.MultilineText)]
        [MaxLength(1000)]
        public string TrescZadania { get; set; }

        [Display(Name = "Rejestrator:")]
        public string RejestratorZadania { get; set; }

        [Display(Name = "Data dodania:")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd")]
        public System.DateTime DataDodaniaZadania { get; set; }

        [Display(Name = "Modyfikator:")]
        public string ModyfikatorZadania { get; set; }

        [Display(Name = "Data modyfikacji:")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd")]
        public System.DateTime DataModyfikacjiZadania { get; set; }

        [Display(Name = "Id uzytkownika:")]
        public string Uzytkownik_Id { get; set; }

        public Uzytkownik Uzytkownik { get; set; }


        

         
    }
}