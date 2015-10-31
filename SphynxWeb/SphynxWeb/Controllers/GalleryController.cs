using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Repozytorium.Models;
using Repozytorium.Repo;

namespace SphynxWeb.Controllers
{
    public class GalleryController : Controller
    {
        //private ApplicationDbContext db = new ApplicationDbContext();
        readonly FotoRepo _repo = new FotoRepo();
        // GET: Gallery
        public ActionResult Index(int? pageNumber)
        {
            int pNumber= pageNumber??1;
            int pSize = 2;
            var fotos = _repo.GetAllFotos();
            var viewFotos = _repo.DisplayFotoModelViews(fotos);
            return View(viewFotos.ToPagedList(pNumber, pSize));
            

        }
            [Authorize]
        public ActionResult Index2()
        {
            var fotosList = _repo.GetAllFotos();
            var viewFotos = _repo.DisplayFotoModelViews(fotosList);
            return View(viewFotos);
        }

        // GET: Gallery/Details/5
            [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FotoModel fotoModel = _repo.GetFotoById((int) id);



            if (fotoModel == null)
            {
                return HttpNotFound();
            }
            return View(fotoModel);
        }

        // GET: Gallery/Create
      //  [Authorize]
            [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        //POST: Gallery/Create
        //To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "FotoId,FotoSize,Description,FileName,FotoData,FotoMiniatureData")] FotoModel fotoModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        repo.AddFoto(fotoModel);
        //        //  db.FotoModels.Add(fotoModel);
        //        //  db.SaveChanges();
        //        //  repo.Save
        //        return RedirectToAction("Index");
        //    }

        //    return View(fotoModel);
        //}
            [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FotoModel fotoModel)
        {
            HttpPostedFileBase file = Request.Files["ImageData"];
            int i = _repo.UploadImageInDataBase(file, fotoModel);
            if (i == 1)
            {
                return RedirectToAction("Index");
            }
            return View(fotoModel);
        }

        //// GET: Gallery/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    FotoModel fotoModel = repo.GetFotoById((int) id);
        //    if (fotoModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(fotoModel);
        //}

        ////// POST: Gallery/Edit/5
        ////// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        ////// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "FotoId,FotoSize,Description,FileName,FotoData,FotoMiniatureData")] FotoModel fotoModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            repo.EditFotoModel(fotoModel);

        //        }
        //        catch 
        //        {
        //            ViewBag.Error = true;
        //            return View(fotoModel);
        //        }

        //     //   db.SaveChanges();
        //     //   return RedirectToAction("Index");
        //    }
        //    ViewBag.Error = false;
        //    return View(fotoModel);
        //}

        // GET: Gallery/Delete/5
            [Authorize]
        public ActionResult Delete(int?id , bool? error)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FotoModel fotoModel = _repo.GetFotoById((int) id);
            if (fotoModel == null)
            {
                return HttpNotFound();
            }
           // if (error != null)
               // ViewBag.Blad = true;
            return View(fotoModel);
        }

        // POST: Gallery/Delete/5
            [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _repo.DeleteFoto(id);
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
