using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SignalR.Hubs;
using MailFeed.Controllers;
using System.Collections.Specialized;

using System.Collections.ObjectModel;
using MailFeed.Models;
using Microsoft.CSharp.RuntimeBinder;
namespace MailFeed.Hubs
{
    public class MailHub : Hub
    {

        /// <summary>
        /// We wire up the subscription to the Inbox ObservableCollection
        /// </summary>
        public MailHub(){
            MvcApplication.Inbox.CollectionChanged += new NotifyCollectionChangedEventHandler(newMail);
        }

        /// <summary>
        /// When a new item is added to the Inbox Collection we will get a notification here which we will distribute to the listening clients
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void newMail(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (Clients != null)
                Clients.updateInbox(MvcApplication.Inbox);
            
            // Clients.alert("You've got mail!");
        }

        /// <summary>
        /// Use this method to add emails to the collection from the client. When a new item is added we will call the caller client 
        /// function alert(message) with a message notifying the client that all went well that the email was "sent" successfully.
        /// </summary>
        /// <param name="mail"></param>
        public void Add(Mail mail)
        {
            MvcApplication.Inbox.Add(mail);
            Caller.alert("Mail sent!");
        }

    }
}