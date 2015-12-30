using System;

namespace RejestrFaktur.Models
{
    public class Firma
    {
        public int Id { get; set; }
        public String Nazwa { get; set; }
        public string Ulica { get; set; }
        public string NumerDomuLokalu { get; set; }
        public string Kod { get; set; }
        public string Miejscowosc { get; set; }
        public string Telefon { get; set; }
        public string Nip { get; set; }
        public string NumerKonta { get; set; }
    }
}