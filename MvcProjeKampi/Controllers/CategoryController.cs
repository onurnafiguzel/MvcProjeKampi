using BusinessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category

        CategoryManager categoryManager = new CategoryManager();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetList()
        {
            var result = categoryManager.GetAll();
            return View(result);
        }
    }
}