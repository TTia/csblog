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
