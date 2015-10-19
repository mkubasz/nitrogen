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
    public class JednostkiMiaryController : Controller
    {
        private RejestrFakturContext db = new RejestrFakturContext();

        // GET: JednostkiMiary
        public ActionResult Index()
        {
            return View(db.JednostkiMiar.ToList());
        }

        // GET: JednostkiMiary/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JednostkaMiary jednostkaMiary = db.JednostkiMiar.Find(id);
            if (jednostkaMiary == null)
            {
                return HttpNotFound();
            }
            return View(jednostkaMiary);
        }

        // GET: JednostkiMiary/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JednostkiMiary/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NazwaJednostki,SymbolJednostki")] JednostkaMiary jednostkaMiary)
        {
            if (ModelState.IsValid)
            {
                db.JednostkiMiar.Add(jednostkaMiary);
                db.SaveChanges();
                
            }

            return View(jednostkaMiary);
        }

        // GET: JednostkiMiary/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JednostkaMiary jednostkaMiary = db.JednostkiMiar.Find(id);
            if (jednostkaMiary == null)
            {
                return HttpNotFound();
            }
            return View(jednostkaMiary);
        }

        // POST: JednostkiMiary/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NazwaJednostki,SymbolJednostki")] JednostkaMiary jednostkaMiary)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jednostkaMiary).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jednostkaMiary);
        }

        // GET: JednostkiMiary/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JednostkaMiary jednostkaMiary = db.JednostkiMiar.Find(id);
            if (jednostkaMiary == null)
            {
                return HttpNotFound();
            }
            return View(jednostkaMiary);
        }

        // POST: JednostkiMiary/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JednostkaMiary jednostkaMiary = db.JednostkiMiar.Find(id);
            db.JednostkiMiar.Remove(jednostkaMiary);
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
