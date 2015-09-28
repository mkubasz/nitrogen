using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Repozytorium.Models.IRepo;

namespace Repozytorium.Models
{
   

    public class OglContext : IdentityDbContext, IOglContext  //klasa kontekstu czyli nawiazania polaczenia z baza danych
    {
        public OglContext()
            : base("DefaultConnection")
        {
        }

        public static OglContext Create()
        {
            return new OglContext();
        }

        public DbSet<Zadanie> Zadania { get; set; } //tabela zadania
        public DbSet<Rozwiazanie> Rozwiazania{ get; set; } //tabela rozzwiazania 
        public DbSet<Uzytkownik> Uzytkownik{ get; set; } //tabala uzytkownik


        protected override void OnModelCreating(DbModelBuilder modelBuilder) //napisywanie metody budujacej tabele w bazie
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); //wylacza liczbe mnoga w tworzeniu tables zeby nie zrobil z tabeli rozwiazania ->rozwianias
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>(); //wylacza kaskadowe usuwanie przy tebaleach jeden do wielu tzn. jak jakis uzytkownik doda zadanie a usuniemy uzytkownika usuwaja sie wszystkie powiazanie z nim zadania
        }

       
    }
}