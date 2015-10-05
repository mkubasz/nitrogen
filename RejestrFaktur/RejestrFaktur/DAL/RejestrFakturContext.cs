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

        DbSet<Faktura> Faktury { get; set; }
        DbSet<FakturaSzczegoly> FakturySzczegoly { get; set; }
        DbSet<Firma> Firma { get; set; }
        DbSet<Klient> Klient { get; set; }
        DbSet<Produkt> Produkt { get; set; }
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
