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
    public class StawkiPodatkuController : Controller
    {
        private RejestrFakturContext db = new RejestrFakturContext();

        // GET: StawkiPodatku
        public ActionResult Index()
        {
            return View(db.StawkiPodatku.ToList());
        }

        // GET: StawkiPodatku/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StawkaPodatku stawkaPodatku = db.StawkiPodatku.Find(id);
            if (stawkaPodatku == null)
            {
                return HttpNotFound();
            }
            return View(stawkaPodatku);
        }

        // GET: StawkiPodatku/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StawkiPodatku/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NazwaStawki,WysokoscStawki")] StawkaPodatku stawkaPodatku)
        {
            if (ModelState.IsValid)
            {
                db.StawkiPodatku.Add(stawkaPodatku);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stawkaPodatku);
        }

        // GET: StawkiPodatku/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StawkaPodatku stawkaPodatku = db.StawkiPodatku.Find(id);
            if (stawkaPodatku == null)
            {
                return HttpNotFound();
            }
            return View(stawkaPodatku);
        }

        // POST: StawkiPodatku/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NazwaStawki,WysokoscStawki")] StawkaPodatku stawkaPodatku)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stawkaPodatku).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stawkaPodatku);
        }

        // GET: StawkiPodatku/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StawkaPodatku stawkaPodatku = db.StawkiPodatku.Find(id);
            if (stawkaPodatku == null)
            {
                return HttpNotFound();
            }
            return View(stawkaPodatku);
        }

        // POST: StawkiPodatku/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StawkaPodatku stawkaPodatku = db.StawkiPodatku.Find(id);
            db.StawkiPodatku.Remove(stawkaPodatku);
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
