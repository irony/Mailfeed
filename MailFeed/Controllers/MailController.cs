using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Dynamic;
using System.Collections.ObjectModel;

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

    }
}
