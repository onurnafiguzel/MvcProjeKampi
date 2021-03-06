using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        ContentManager contentManager = new ContentManager(new EfContentDal());
        public ActionResult Headings()
        {
            var result = headingManager.GetAll();
            return View(result);
        }

        public PartialViewResult Index(int id=0) // Boş gelmemesi için
        {
            var result = contentManager.GetAllByHeadingId(id);
            return PartialView(result);
        }
    }
}