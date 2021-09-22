using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AuthorizationController : Controller
    {
        // GET: Authorization
        AdminManager adminManager = new AdminManager(new EfAdminDal());

        public ActionResult Index()
        {
            var result = adminManager.GetAll();
            return View(result);
        }
    }
}