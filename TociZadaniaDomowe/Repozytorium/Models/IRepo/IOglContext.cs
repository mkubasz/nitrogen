using System.Data.Entity;

namespace Repozytorium.Models.IRepo
{
    public interface IOglContext
    {
        DbSet<Zadanie> Zadania { get; set; } //tabela zadania
        DbSet<Rozwiazanie> Rozwiazania { get; set; } //tabela rozzwiazania 
        DbSet<Uzytkownik> Uzytkownik { get; set; } //tabala uzytkownik
        int SaveChanges();
        Database Database { get; }
    }
}