using System;
using System.Data.Entity;
using System.Linq;
using Repozytorium.Models.IRepo;

namespace Repozytorium.Models.Repo
{
    public class ZadanieRepo:IZadanieRepo
    {
        private readonly IOglContext _db;

        public ZadanieRepo(IOglContext db)
        {
            _db = db;
        }
       // private OglContext db = new OglContext();


        public IQueryable<Zadanie> PobierzZadania()
        {

            var zadania = _db.Zadania.Include(o => o.Uzytkownik);
            return zadania;
        }

        public Zadanie GetZadanieById(int id)
        {
            Zadanie zadanie = _db.Zadania.Find(id);
            return zadanie;
        }

        public void UsunZadanie(int id)
        {
            UsunPowiazaniaZadanieRozwiazania(id);
            Zadanie zadanie = _db.Zadania.Find(id);
            _db.Zadania.Remove(zadanie);
        }


        private void UsunPowiazaniaZadanieRozwiazania(int idZadania)
        {
            var list = _db.Rozwiazania.Where(o => o.ZadanieId == idZadania);
            foreach (var item in list)
            {
                _db.Rozwiazania.Remove(item);
            }


        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }

        public void Dodaj(Zadanie zadanie)
        {
            _db.Zadania.Add(zadanie);
        }
    }
}