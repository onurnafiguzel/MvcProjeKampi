﻿using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelController : Controller
    {
        // GET: WriterPanel
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal
            ());
        Context context = new Context();

        public ActionResult WriterProfile()
        {
            return View();
        }

        public ActionResult MyHeading(string parameter)
        {
            parameter = (string)Session["WriterMail"];
            var writeridinfo = context.Writers.Where(x => x.WriterMail == parameter).Select(y => y.WriterId).FirstOrDefault();
            var result = headingManager.GetAllByWriter(writeridinfo);
            return View(result);
        }

        [HttpGet]
        public ActionResult NewHeading()
        {
            List<SelectListItem> valueCategory = (from x in categoryManager.GetAll()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();

            ViewBag.category = valueCategory;
            return View();
        }

        [HttpPost]
        public ActionResult NewHeading(Heading heading)
        {
            string writermailinfo = (string)Session["WriterMail"];
            var writeridinfo = context.Writers.Where(x => x.WriterMail == writermailinfo).Select(y => y.WriterId).FirstOrDefault();
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            heading.WriterId = writeridinfo;
            heading.HeadingStatus = true;
            headingManager.HeadingAdd(heading);
            return RedirectToAction("MyHeading");
        }

        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valueCategory = (from x in categoryManager.GetAll()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.category = valueCategory;
            var result = headingManager.GetById(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult EditHeading(Heading heading)
        {
            headingManager.HeadingUpdate(heading);
            return RedirectToAction("MyHeading");
        }

        public ActionResult DeleteHeading(int id)
        {
            var result = headingManager.GetById(id);
            result.HeadingStatus = false;
            headingManager.HeadingDelete(result);
            return RedirectToAction("MyHeading");
        }
    }
}