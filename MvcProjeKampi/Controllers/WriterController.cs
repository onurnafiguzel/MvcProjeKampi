﻿using BusinessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterController : Controller
    {
        // GET: Writer
        WriterManager writerManager=new WriterManager(new EfWriterDal())
        public ActionResult Index()
        {
            return View();
        }
    }
}