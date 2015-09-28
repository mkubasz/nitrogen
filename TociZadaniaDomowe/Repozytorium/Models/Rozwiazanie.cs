using System.ComponentModel.DataAnnotations;

namespace Repozytorium.Models
{
    public class Rozwiazanie //pola  w tabeli
    {
        [Display(Name = "ID:")]
        public int Id { get; set; }


        [Display(Name = "Rozwiązanie:")]
        [DataType(DataType.MultilineText)]
        [MaxLength(3000)]
        public string TrescRozwiazania { get; set; }

        [Display(Name = "Rejestrator:")]
        public string RejestratorRozwiazania { get; set; }

        [Display(Name = "Data dodania:")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd")]
        public System.DateTime DataDodaniaRozwiazania { get; set; }

        [Display(Name = "Modyfikator:")]
        public string ModyfikatorRozwiazania { get; set; }

        [Display(Name = "Data modyfikacji:")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd")]
        public System.DateTime DataModyfikacjiRozwiazania { get; set; }


        public string Uzytkownik_Id { get; set; }

        public int ZadanieId { get; set; }

        public Zadanie Zadanie { get; set; }

        public Uzytkownik Uzytkownik { get; set; }



         
    }
}