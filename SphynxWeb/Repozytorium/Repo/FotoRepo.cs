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
    }
}