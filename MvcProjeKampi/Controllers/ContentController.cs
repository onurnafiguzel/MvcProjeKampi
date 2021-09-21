using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content
        ContentManager contentManager = new ContentManager(new EfContentDal());
        Context context = new Context();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ContentByHeading(int id)
        {
            var result = contentManager.GetAllByHeadingId(id);
            return View(result);
        }

        public ActionResult GetAllContent(string word)
        {           
            var result = from x in context.Contents select x;
            if (!string.IsNullOrEmpty(word))
            {
                result = result.Where(y => y.ContentValue.Contains(word));
            }
            return View(result.ToList());
        }
    }
}