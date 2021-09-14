using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();

        public ActionResult Inbox()
        {
            var result = messageManager.GetAllInBox();
            return View(result);
        }

        public ActionResult SendBox()
        {
            var result = messageManager.GetAllSentBox();
            return View(result);
        }

        public ActionResult GetInBoxMessageDetails(int id)
        {
            var result = messageManager.GetById(id);
            return View(result);
        }

        public ActionResult GetSendBoxMessageDetails(int id)
        {
            var result = messageManager.GetById(id);
            return View(result);
        }

        [HttpGet]
        public ActionResult NewMessage(Message message)
        {
            ValidationResult validationResult = messageValidator.Validate(message);
            if (validationResult.IsValid)
            {
                messageManager.MessageAdd(message);
                return RedirectToAction("SendBox");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}