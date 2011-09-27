using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Dynamic;
using System.Collections.ObjectModel;
using NLog;

namespace MailFeed.Controllers
{
    public class MailController : Controller
    {
        //
        // GET: /Mail/

        static MailController()
        {
            Inbox = new ObservableCollection<Mail>();
        }

        private static Logger log = LogManager.GetCurrentClassLogger();


        public static ObservableCollection<Mail> Inbox
        {
            get;
            set;
        }

        public ActionResult Index()
        {
            dynamic model = new ExpandoObject();
            model.Inbox = Inbox;

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
            Inbox.Add(mail);


            return new RedirectResult("/Mail");
        }

        public void ReceiveMail(string sender, string receiver, string subject, string body)
        {
            try
            {
                var bodyHtml = HttpContext.Request["body-html"]; // MVC don't support hyphens in variables so we have to get the html this way

                var mail = new Mail { From = sender, To = receiver, Body = bodyHtml, Subject = subject };

                Inbox.Add(mail);
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }



    }
}
