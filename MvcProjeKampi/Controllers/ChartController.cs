using MvcProjeKampi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoryChart()
        {
            return Json(BlogList(), JsonRequestBehavior.AllowGet);
        }

        public List<Category> BlogList()
        {
            List<Category> categories = new List<Category>();
            categories.Add(new Category()
            {
                CategoryName = "yazılım",
                CategoryCount = 1
            });
            categories.Add(new Category()
            {
                CategoryName = "seyahat",
                CategoryCount = 2
            });
            categories.Add(new Category()
            {
                CategoryName = "teknoloji",
                CategoryCount = 3
            });
            categories.Add(new Category()
            {
                CategoryName = "spor",
                CategoryCount = 4
            });
            return categories;
        }
    }
}