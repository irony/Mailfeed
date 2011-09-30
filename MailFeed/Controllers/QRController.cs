using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MailFeed.Models;
using System.Collections.ObjectModel;
using System.Dynamic;

namespace MailFeed.Controllers
{
    public class QRController : Controller
    {
        //
        // GET: /QR/

        public static ObservableCollection<Qr> IssuedCodes { get; set; }

        public QRController()
        {
            IssuedCodes = new ObservableCollection<Qr>();
        }

        public ActionResult Index()
        {
            if (!IssuedCodes.Where(c => c.Scanned == true).Any())
            {
                IssuedCodes.Clear();
                for (int i = 0; i < 100; i++)
                {
                    IssuedCodes.Add(new Qr { Url = String.Format("http://chart.apis.google.com/chart?cht=qr&chs=100x100&chl=http%3A//{0}/qr/scan/{1}&chld=H|0", Request.Url.Authority, i), Scanned = false });
                }
            }

            dynamic model = new ExpandoObject();
            model.Codes = IssuedCodes;
            return View(model);
        }

        [HandleError]
        public ActionResult Scan(int id)
        {
            if (!IssuedCodes[id].Scanned)
                IssuedCodes[id].Scanned = true;
            else
                throw new Exception("This code is already scanned");
            
            return View();
        }

    }
}
