using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using RejestrFaktur.Models;


namespace RejestrFaktur.DAL
{
    public class RejestrFakturContext:DbContext
    {
        public RejestrFakturContext() : base("DefaultConnection")
        {

        }

        public DbSet<Faktura> Faktury { get; set; }
        public DbSet<FakturaSzczegoly> FakturySzczegoly { get; set; }
        public DbSet<Firma> Firma { get; set; }
        public DbSet<Klient> Klient { get; set; }
        public DbSet<Produkt> Produkt {get; set;}
        public DbSet<JednostkaMiary> JednostkiMiar { get; set; }
        public DbSet<PlatnoscTyp> PlatnosciTypy { get; set; }
        public DbSet<Waluta> Waluty { get; set; }
        public DbSet<StawkaPodatku> StawkiPodatku { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // using System.Data.Entity.ModelConfiguration.Conventions;
            // Wyłączamy konwencję, która każe zamieniać nazwę tabeli na liczbę mnogą
            // Zamiast Kategorie utworzyłoby Kategories
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            // Wyłączamy domyślną konwencję Cascade Delete dla powiązań
            // CascadeDelete zostanie włączone za pomocą Fluent API


        }

    }


    }
