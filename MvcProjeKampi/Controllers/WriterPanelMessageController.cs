﻿using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        // GET: WriterPanelMessage
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

        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }
    }
}