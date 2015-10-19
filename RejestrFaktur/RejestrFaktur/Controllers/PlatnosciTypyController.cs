using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RejestrFaktur.DAL;
using RejestrFaktur.Models;

namespace RejestrFaktur.Controllers
{
    public class PlatnosciTypyController : Controller
    {
        private RejestrFakturContext db = new RejestrFakturContext();

        // GET: PlatnosciTypy
        public ActionResult Index()
        {
            return View(db.PlatnosciTypy.ToList());
        }

        // GET: PlatnosciTypy/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlatnoscTyp platnoscTyp = db.PlatnosciTypy.Find(id);
            if (platnoscTyp == null)
            {
                return HttpNotFound();
            }
            return View(platnoscTyp);
        }

        // GET: PlatnosciTypy/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlatnosciTypy/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nazwa,Opis")] PlatnoscTyp platnoscTyp)
        {
            if (ModelState.IsValid)
            {
                db.PlatnosciTypy.Add(platnoscTyp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(platnoscTyp);
        }

        // GET: PlatnosciTypy/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlatnoscTyp platnoscTyp = db.PlatnosciTypy.Find(id);
            if (platnoscTyp == null)
            {
                return HttpNotFound();
            }
            return View(platnoscTyp);
        }

        // POST: PlatnosciTypy/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nazwa,Opis")] PlatnoscTyp platnoscTyp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(platnoscTyp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(platnoscTyp);
        }

        // GET: PlatnosciTypy/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlatnoscTyp platnoscTyp = db.PlatnosciTypy.Find(id);
            if (platnoscTyp == null)
            {
                return HttpNotFound();
            }
            return View(platnoscTyp);
        }

        // POST: PlatnosciTypy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlatnoscTyp platnoscTyp = db.PlatnosciTypy.Find(id);
            db.PlatnosciTypy.Remove(platnoscTyp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
