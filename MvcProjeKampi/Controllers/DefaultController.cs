using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        public ActionResult Headings()
        {
            var result = headingManager.GetAll();
            return View(result);
        }

        public PartialViewResult Index()
        {
            return PartialView();
        }
    }
}