using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Dynamic;
using System.Collections.ObjectModel;
using NLog;
using MailFeed.Models;

namespace MailFeed.Controllers
{
    public class MailController : Controller
    {
        //
        // GET: /Mail/

        static MailController()
        {
        }

        private static Logger log = LogManager.GetCurrentClassLogger();



        public ActionResult Index()
        {
            dynamic model = new ExpandoObject();
            model.Inbox = MvcApplication.Inbox;

            return View(model);
        }


        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Mail mail)
        {
            // TODO: Add to DB
            MvcApplication.Inbox.Add(mail);

            return new RedirectResult("/Mail");
        }

        [HttpPost, ValidateInput(false)]
        public void ReceiveMail(string sender, string receiver, string subject)
        {
            try
            {
                var bodyHtml = HttpContext.Request["body-html"]; // MVC don't support hyphens in variables so we have to get the html this way

                var mail = new Mail { From = sender, To = receiver, Body = bodyHtml, Subject = subject };

                MvcApplication.Inbox.Insert(0, mail);
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }



    }
}
