using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager contactManager = new ContactManager(new EfContactDal());
        ContactValidator contactValidator = new ContactValidator();

        public ActionResult Index()
        {
            var result = contactManager.GetAll();
            return View(result);
        }

        public ActionResult GetContactDetails(int id)
        {
            var result = contactManager.GetById(id);
            return View(result);
        }
    }
}