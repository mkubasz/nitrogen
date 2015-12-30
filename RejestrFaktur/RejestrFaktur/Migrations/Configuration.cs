namespace RejestrFaktur.Migrations
{
    using Models;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<RejestrFaktur.DAL.RejestrFakturContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RejestrFaktur.DAL.RejestrFakturContext context)
        {
            context.JednostkiMiar.AddOrUpdate(new JednostkaMiary { NazwaJednostki = "metr", SymbolJednostki = "m" });
            context.JednostkiMiar.AddOrUpdate(new JednostkaMiary { NazwaJednostki = "kilogram", SymbolJednostki = "kg" });
            context.JednostkiMiar.AddOrUpdate(new JednostkaMiary { NazwaJednostki = "sztuka", SymbolJednostki = "szt" });
            context.JednostkiMiar.AddOrUpdate(new JednostkaMiary { NazwaJednostki = "litr", SymbolJednostki = "l" });

            context.PlatnosciTypy.AddOrUpdate(new PlatnoscTyp { Nazwa = "Przelew", Opis = "przelew" });
            context.PlatnosciTypy.AddOrUpdate(new PlatnoscTyp { Nazwa = "Zap³ata w kasie", Opis = "zap³ata w kasie" });
            context.PlatnosciTypy.AddOrUpdate(new PlatnoscTyp { Nazwa = "Karta kredytowa", Opis = "zap³ata kart¹ kredytow¹" });

            context.StawkiPodatku.AddOrUpdate(new StawkaPodatku { NazwaStawki = "23%", WysokoscStawki = 23 });
            context.StawkiPodatku.AddOrUpdate(new StawkaPodatku { NazwaStawki = "11%", WysokoscStawki = 11 });
            context.StawkiPodatku.AddOrUpdate(new StawkaPodatku { NazwaStawki = "8%", WysokoscStawki = 8 });
            context.StawkiPodatku.AddOrUpdate(new StawkaPodatku { NazwaStawki = "5%", WysokoscStawki = 5 });

            context.Waluty.AddOrUpdate(new Waluta { Nazwa = "Z³oty", Symbol = "PLN", SciezkaDoIkony = "" });
            context.Waluty.AddOrUpdate(new Waluta { Nazwa = "Euro", Symbol = "EUR", SciezkaDoIkony = "" });
            context.Waluty.AddOrUpdate(new Waluta { Nazwa = "Funt", Symbol = "GBP", SciezkaDoIkony = "" });


        }
    }
}
