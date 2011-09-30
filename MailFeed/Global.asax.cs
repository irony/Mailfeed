using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using NLog;
using MailFeed.Models;
using System.Collections.ObjectModel;

namespace MailFeed
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static ObservableCollection<Qr> IssuedCodes { get; set; }


        /// <summary>
        /// By setting this collection to Observable we can subscribe to the events when adding and removing items in this collection. 
        /// We will use this to signal changes to the clients via the SignalR Hub.
        /// </summary>
        public static ObservableCollection<Mail> Inbox
        {
            get;
            set;
        }


        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            MvcApplication.IssuedCodes = new ObservableCollection<Qr>();
            MvcApplication.Inbox = new ObservableCollection<Mail>();


            this.Error += new EventHandler(MvcApplication_Error);
        }

        void MvcApplication_Error(object sender, EventArgs e)
        {
            Logger log = LogManager.GetCurrentClassLogger();

            log.Error("Error : " + e.ToString());
        }

        
    }
}