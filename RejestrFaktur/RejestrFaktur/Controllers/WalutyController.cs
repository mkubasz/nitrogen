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
    public class WalutyController : Controller
    {
        private RejestrFakturContext db = new RejestrFakturContext();

        // GET: Waluty
        public ActionResult Index()
        {
            return View(db.Waluty.ToList());
        }

        // GET: Waluty/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Waluta waluta = db.Waluty.Find(id);
            if (waluta == null)
            {
                return HttpNotFound();
            }
            return View(waluta);
        }

        // GET: Waluty/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Waluty/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nazwa,Symbol,SciezkaDoIkony")] Waluta waluta)
        {
            if (ModelState.IsValid)
            {
                db.Waluty.Add(waluta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(waluta);
        }

        // GET: Waluty/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Waluta waluta = db.Waluty.Find(id);
            if (waluta == null)
            {
                return HttpNotFound();
            }
            return View(waluta);
        }

        // POST: Waluty/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nazwa,Symbol,SciezkaDoIkony")] Waluta waluta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(waluta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(waluta);
        }

        // GET: Waluty/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Waluta waluta = db.Waluty.Find(id);
            if (waluta == null)
            {
                return HttpNotFound();
            }
            return View(waluta);
        }

        // POST: Waluty/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Waluta waluta = db.Waluty.Find(id);
            db.Waluty.Remove(waluta);
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
