using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Repozytorium.Models;
using Repozytorium.Models.IRepo;
using Repozytorium.Models.Repo;

namespace TociZadaniaDomowe.Controllers
{
    public class ZadanieController : Controller
    {
       // private ZadanieRepo repo = new ZadanieRepo();
        private  readonly IZadanieRepo _repo;
        public ZadanieController(IZadanieRepo repo)
        {
            _repo = repo;
        }

        // GET: Zadanie
        public ActionResult Index()
        {
            var zadania = _repo.PobierzZadania();
            return View(zadania);
        }

        // GET: Zadanie/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zadanie zadanie = _repo.GetZadanieById((int)id);
            if (zadanie == null)
            {
                return HttpNotFound();
            }
            return View(zadanie);
        }

        // GET: Zadanie/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Zadanie/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
       [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
      /*  public ActionResult Create([Bind(Include = "Id,TematZadania,TrescZadania,RejestratorZadania,DataDodaniaZadania,ModyfikatorZadania,DataModyfikacjiZadania,UzytkownikId")] Zadanie zadanie)*/

           public ActionResult Create([Bind(Include = "TematZadania,TrescZadania")] Zadanie zadanie)
       {

            if (ModelState.IsValid)
            {
                zadanie.Uzytkownik_Id = User.Identity.GetUserId();
                zadanie.RejestratorZadania = User.Identity.GetUserName();
                zadanie.ModyfikatorZadania = User.Identity.GetUserName();
                zadanie.DataDodaniaZadania = DateTime.Now;
                zadanie.DataModyfikacjiZadania = DateTime.Now;
                try
                {
                    _repo.Dodaj(zadanie);
                    _repo.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch 
                {

                    return View(zadanie);
                }
   
            }

            return View(zadanie);
        }

        //// GET: Zadanie/Edit/5
       public ActionResult Edit(int? id)
       {
           if (id == null)
           {
               return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
           }
           Zadanie zadanie = _repo.GetZadanieById((int)(id));
           if (zadanie == null)
           {
               return HttpNotFound();
           }
           return View(zadanie);
       }

       // POST: Zadanie/Edit/5
       // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
       // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
       //[HttpPost]
       //[ValidateAntiForgeryToken]
       //public ActionResult Edit([Bind(Include = "Id,TematZadania,TrescZadania,RejestratorZadania,DataDodaniaZadania,ModyfikatorZadania,DataModyfikacjiZadania,UzytkownikId")] Zadanie zadanie)
       //{
       //    if (ModelState.IsValid)
       //    {
       //        db.Entry(zadanie).State = EntityState.Modified;
       //        db.SaveChanges();
       //        return RedirectToAction("Index");
       //    }
       //    return View(zadanie);
       //}

        // GET: Zadanie/Delete/5
        public ActionResult Delete(int? id, bool? blad)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zadanie zadanie = _repo.GetZadanieById((int) id);
            if (zadanie == null)
            {
                return HttpNotFound();
            }
            if (blad != null)
            {
                ViewBag.Blad = true;
            }
            return View(zadanie);
        }

        // POST: Zadanie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _repo.UsunZadanie(id);
            try
            {
                _repo.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Delete", new {id=id, blad=true});
            }

            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}


