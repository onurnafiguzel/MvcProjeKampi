using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
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

        public ActionResult WriterProfile()
        {
            return View();
        }

        public ActionResult MyHeading(int id)
        {
            var result = headingManager.GetAll(id);
            return View(result);
        }
    }
}