﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Headings()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}