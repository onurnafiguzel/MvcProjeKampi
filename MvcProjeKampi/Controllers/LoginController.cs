using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        AdminManager adminManager = new AdminManager(new EfAdminDal());

        public ActionResult Index()
        {
            return View();
        }
    }
}