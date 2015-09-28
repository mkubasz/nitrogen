using System.Linq;

namespace Repozytorium.Models.IRepo
{
    public interface IZadanieRepo
    {
       IQueryable<Zadanie> PobierzZadania();
        Zadanie GetZadanieById(int id);
        void UsunZadanie(int id);
        void SaveChanges();
        void Dodaj(Zadanie zadanie);
    }
}