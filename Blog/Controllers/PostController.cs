﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Blog.Models;

namespace Blog.Controllers
{
    public class PostController : Controller
    {
        private CSBlogEntities db = new CSBlogEntities();

        [HttpGet]
        public JsonResult AutocompleteTitle(string title)
        {
            var postTitles = db.Posts
                .Where(p => p.title.ToLower().Contains(title.ToLower()))
                .Select(p => p.title)
                .ToList();
            return Json(postTitles, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult CheckForDuplication(Guid? id, string title)
        {
            var post = db.Posts
                .Where(p => p.title.Equals(title, StringComparison.CurrentCultureIgnoreCase))
                .FirstOrDefault();
            if (post != null && (id == null || !post.id.Equals(id)))
            {
                return Json("Il titolo è già presente.", JsonRequestBehavior.AllowGet);
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        // GET: /Post/
        public ActionResult Index(string title)
        {
            //var posts = db.Posts.Include(p => p.Author);
            IQueryable<Post> posts = null;
            if (title != null)
            {
                posts = db.Posts.Where(p => p.title.Equals(title));
                if (posts.Count() == 0)
                {
                    posts = db.Posts.Where(p => p.title.ToLower().Contains(title.ToLower()));
                }
            }
            else
            {
                posts = db.Posts;
            }
            return View(posts.OrderByDescending(p => p.updatedAt).ToList());
        }

        // GET: /Post/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: /Post/Create
        public ActionResult Create()
        {
            if (!isAuthorized())
                return redirectToLoginPage();
            ViewBag.authorId = new SelectList(db.Authors, "id", "email");
            return View();
        }

        // POST: /Post/Create
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,authorId,title,body,createdAt,updatedAt")] Post post)
        {
            if (!isAuthorized())
                return redirectToLoginPage();
            if (ModelState.IsValid)
            {
                post.id = Guid.NewGuid();
                post.createdAt = post.updatedAt = DateTime.Now;
                post.authorId = db.Authors.First<Author>().id;

                db.Posts.Add(post);
                db.SaveChanges();
                TempData["notice"] = String.Format("Il post '{0}' è stato creato con successo.", post.title);
                return RedirectToAction("Details", new { post.id });
            }

            ViewBag.authorId = new SelectList(db.Authors, "id", "email", post.authorId);
            return View(post);
        }

        // GET: /Post/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (!isAuthorized())
                return redirectToLoginPage();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            ViewBag.authorId = new SelectList(db.Authors, "id", "email", post.authorId);
            return View(post);
        }

        // POST: /Post/Edit/5
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,authorId,title,body,createdAt,updatedAt")] Post post)
        //public ActionResult Edit([Bind(Include = "title,body")] Post post)
        {
            if (!isAuthorized())
                return redirectToLoginPage();
            if (ModelState.IsValid)
            {
                var previousVersion = db.Posts.Find(post.id);
                previousVersion.updatedAt = DateTime.Now;
                previousVersion.title = post.title;
                previousVersion.body = post.body;
                db.Entry(previousVersion).State = EntityState.Modified;
                db.SaveChanges();
                TempData["notice"] = String.Format("Il post '{0}' è stato modificato con successo.", post.title);
                return RedirectToAction("Details", new { post.id });
            }
            ViewBag.authorId = new SelectList(db.Authors, "id", "email", post.authorId);
            return View(post);
        }

        // GET: /Post/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (!isAuthorized())
                return redirectToLoginPage();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: /Post/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            if (!isAuthorized())
                return redirectToLoginPage();
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
            db.SaveChanges();
            TempData["notice"] = String.Format("Il post '{0}' è stato cancellato con successo.", post.title);
            return RedirectToAction("Index");
        }

        protected bool isAuthorized()
        {
            return Session["author_id"] != null;
        }

        protected ActionResult redirectToLoginPage() {
            TempData["notice"] = "Devi prima effettuare l'accesso.";
            return Redirect("~/Author/Login");        
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
