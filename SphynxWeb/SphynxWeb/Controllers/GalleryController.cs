using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Repozytorium.Models;
using Repozytorium.Repo;

namespace SphynxWeb.Controllers
{
    public class GalleryController : Controller
    {
        //private ApplicationDbContext db = new ApplicationDbContext();
        FotoRepo repo = new FotoRepo();
        // GET: Gallery
        public ActionResult Index()
        {
            var fotos = repo.GetAllFotos();
           // return System.Web.UI.WebControls.View(db.FotoModels.ToList());
            return View(fotos);

            //templatka do projektu galerii  http://startbootstrap.com/template-overviews/3-col-portfolio/
        }

        //// GET: Gallery/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    FotoModel fotoModel = db.FotoModels.Find(id);
        //    if (fotoModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(fotoModel);
        //}

        //// GET: Gallery/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Gallery/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "FotoId,FotoSize,Description,FileName,FotoData,FotoMiniatureData")] FotoModel fotoModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.FotoModels.Add(fotoModel);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(fotoModel);
        //}

        //// GET: Gallery/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    FotoModel fotoModel = db.FotoModels.Find(id);
        //    if (fotoModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(fotoModel);
        //}

        //// POST: Gallery/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "FotoId,FotoSize,Description,FileName,FotoData,FotoMiniatureData")] FotoModel fotoModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(fotoModel).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(fotoModel);
        //}

        //// GET: Gallery/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    FotoModel fotoModel = db.FotoModels.Find(id);
        //    if (fotoModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(fotoModel);
        //}

        //// POST: Gallery/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    FotoModel fotoModel = db.FotoModels.Find(id);
        //    db.FotoModels.Remove(fotoModel);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
