using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Repozytorium.Models;

namespace Repozytorium.Repo
{
    public class FotoRepo
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public IQueryable<FotoModel> GetAllFotos()
        {
            return db.Fotos.AsNoTracking();
        }

        public FotoModel GetFotoById(int id)
        {
            return db.Fotos.Find(id);
        }

        public void EditFotoModel(FotoModel foto)
        {
            db.Entry(foto).State = EntityState.Modified;
        }

        public bool DeleteFoto(int id)
        {
            FotoModel foto = db.Fotos.Find(id);
            db.Fotos.Remove(foto);
            try
            {
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public void AddFoto(FotoModel foto)
        {
            db.Fotos.Add(foto);
            db.SaveChanges();
        }
    }
}