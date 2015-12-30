using System;

namespace RejestrFaktur.Models
{
    public class Faktura
    {
        public int Id { get; set; }
        public string Numer { get; set; }
        public DateTime DataWystawienia { get; set; }
        public DateTime DataSprzedazy { get; set; }
        public decimal WalutaKurs { get; set; }
        public DateTime DataZaplaty { get; set; }

    }
}