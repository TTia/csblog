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
    public class AuthorController : Controller
    {
        private CSBlogEntities db = new CSBlogEntities();
        // GET: /Author/Login
        public ActionResult Login()
        {
            return View("Login");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "email,hpassword")] Author author)
        {
            author = db.Authors
                .Where(a => a.email.Equals(author.email))
                .Where(a => a.hpassword.Equals(author.hpassword))
                .FirstOrDefault();
            if (author != null)
            {
                var authorId = Session["author_id"] as Guid?;
                if (authorId != null)
                {
                    //Already Logged
                    TempData["notice"] = "Hai già effettuato l'accesso.";
                }
                else
                {
                    Session["author_id"] = author.id;
                    Session["author_email"] = author.email;
                    TempData["notice"] = "Login effettuato, benvenuto!";
                }
                return Redirect("~/");
            }

            TempData["notice"] = "Credenziali invalide.";
            return RedirectToAction("Login");
        }
        // GET: /Author/Logout
        public ActionResult Logout()
        {
            //Arrivederci!
            var authorId = Session["author_id"] as Guid?;
            if (authorId != null)
            {
                Session.Clear();
                TempData["notice"] = "Arrivederci!";
                return Redirect("~/");
            }
            TempData["notice"] = "Login non effettuato.";
            return RedirectToAction("Login");
        }

        /*
        // GET: /Author/
        public ActionResult Index()
        {
            return View(db.Authors.ToList());
        }

        // GET: /Author/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = db.Authors.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // GET: /Author/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Author/Create
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,email,hpassword,hsalt,createdAt")] Author author)
        {
            if (ModelState.IsValid)
            {
                author.id = Guid.NewGuid();
                db.Authors.Add(author);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(author);
        }

        // GET: /Author/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = db.Authors.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // POST: /Author/Edit/5
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,email,hpassword,hsalt,createdAt")] Author author)
        {
            if (ModelState.IsValid)
            {
                db.Entry(author).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(author);
        }

        // GET: /Author/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = db.Authors.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // POST: /Author/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Author author = db.Authors.Find(id);
            db.Authors.Remove(author);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
         */

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
