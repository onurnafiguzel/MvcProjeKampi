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
    }
}