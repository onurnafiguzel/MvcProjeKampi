using BusinessLayer.Concrete;
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
    public class WriterPanelContentController : Controller
    {
        // GET: WriterPanelContent
        ContentManager contentManager = new ContentManager(new EfContentDal());

        Context context = new Context();
        public ActionResult MyContent(string parameter)
        {
            parameter = (string)Session["WriterMail"];
            var writeridinfo = context.Writers.Where(x => x.WriterMail == parameter).Select(y => y.WriterId).FirstOrDefault();
            var result = contentManager.GetAllByWriter(writeridinfo);
            return View(result);
        }

        [HttpGet]
        public ActionResult AddContent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddContent(Content content)
        {
            string mail = (string)Session["WriterMail"];
            var writeridinfo = context.Writers.Where(x => x.WriterMail == mail).Select(y => y.WriterId).FirstOrDefault();
            content.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            content.WriterId = writeridinfo;
            content.ContentStatus = true;
            contentManager.ContentAdd(content);
            return RedirectToAction("MyContent");
        }
    }
}