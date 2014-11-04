﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Abstract()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Author()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}