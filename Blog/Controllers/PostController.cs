using System;
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

        public JsonResult AutocompleteTitle(string title)
        {
            bool duplicated = db.Posts.Where(p => p.title.Equals(title, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault() != null;
            if (duplicated)
            {
                return Json("Il titolo è già presente.", JsonRequestBehavior.AllowGet);
            }
            return Json(true, JsonRequestBehavior.AllowGet);
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
        public ActionResult Index()
        {
            var posts = db.Posts.Include(p => p.Author);
            return View(posts.ToList());
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
            if (ModelState.IsValid)
            {
                post.id = Guid.NewGuid();
                post.createdAt = post.updatedAt = DateTime.Now;
                post.authorId = db.Authors.First<Author>().id;

                db.Posts.Add(post);
                db.SaveChanges();
                ViewBag.notice = String.Format("Il post '%s' è stato creato con successo.", post.title);
                return RedirectToAction("Index");
            }

            ViewBag.authorId = new SelectList(db.Authors, "id", "email", post.authorId);
            return View(post);
        }

        // GET: /Post/Edit/5
        public ActionResult Edit(Guid? id)
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
            if (ModelState.IsValid)
            {
                var previousVersion = db.Posts.Find(post.id);
                previousVersion.updatedAt = DateTime.Now;
                previousVersion.title = post.title;
                previousVersion.body = post.body;
                db.Entry(previousVersion).State = EntityState.Modified;
                db.SaveChanges();
                ViewBag.notice = String.Format("Il post '%s' è stato modificato con successo.", post.title);
                return RedirectToAction("Index");
            }
            ViewBag.authorId = new SelectList(db.Authors, "id", "email", post.authorId);
            return View(post);
        }

        // GET: /Post/Delete/5
        public ActionResult Delete(Guid? id)
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

        // POST: /Post/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
            db.SaveChanges();
            ViewBag.notice = String.Format("Il post '%s' è stato cancellato con successo.", post.title);
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
