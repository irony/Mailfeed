using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Dynamic;

namespace MailFeed.Controllers
{
    public class MailController : Controller
    {
        //
        // GET: /Mail/

        static MailController()
        {
            Inbox = new Mail[0];
        }

        public static Mail[] Inbox
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
            List<Mail> mails = new List<Mail>();
            mails.Add(mail);
            mails.AddRange(Inbox);
            Inbox = mails.ToArray();


            return new RedirectResult("/Mail");
        }

    }
}
