﻿using System;
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
            for (int i = 0; i < 100; i++)
            {
                IssuedCodes.Add(new Qr { Url = String.Format("http://chart.apis.google.com/chart?cht=qr&chs=100x100&chl=http%3A//mailfeed-1.apphb.com/qr/{0}&chld=H|0", i), Scanned = false });
            }
        }

        public ActionResult Index()
        {
            dynamic model = new ExpandoObject();
            model.Codes = IssuedCodes;
            return View(model);
        }

        [HandleError]
        public ActionResult Scanned(int id)
        {
            if (!IssuedCodes[id].Scanned)
                IssuedCodes[id].Scanned = true;
            else
                throw new Exception("This code is already scanned");
            
            return View();
        }

    }
}
