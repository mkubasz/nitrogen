﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Repozytorium.Models;
using Repozytorium.Repo;
using Repozytorium.Repo.Abstract;

namespace SphynxWeb.Controllers
{
    public class BlogModelsController : Controller
    {
        private IBlogRepo repo;
        private ApplicationDbContext db = new ApplicationDbContext();

        public BlogModelsController()
        {
            repo = new BlogRepo();
        }

        // GET: BlogModels
        public ActionResult Index()
        {
            return PartialView(repo.GetAllBlogs().ToList());
        }

        // GET: BlogModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogModel blogModel = repo.GetBlogById(id);
            if (blogModel == null)
            {
                return HttpNotFound();
            }
            return View(blogModel);
        }

        // GET: BlogModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BlogModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PostId,Post,Category,ShowOnStartPage,AddDate")] BlogModel blogModel)
        {
            if (ModelState.IsValid)
            {
                repo.AddBlog(blogModel);
                return RedirectToAction("Index");
            }

            return View(blogModel);
        }

        // GET: BlogModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogModel blogModel = repo.GetBlogById(id);
            if (blogModel == null)
            {
                return HttpNotFound();
            }
            return View(blogModel);
        }

        // POST: BlogModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PostId,Post,Category,ShowOnStartPage,AddDate")] BlogModel blogModel)
        {
            if (ModelState.IsValid)
            {
                repo.EditBlog(blogModel);
                return RedirectToAction("Index");
            }
            return View(blogModel);
        }

        // GET: BlogModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogModel blogModel = repo.DeleteBlog(id);
            if (blogModel == null)
            {
                return HttpNotFound();
            }
            return View(blogModel);
        }

        // POST: BlogModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            repo.DeleteBlog(id);
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
