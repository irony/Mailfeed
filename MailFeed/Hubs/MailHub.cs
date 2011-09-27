using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SignalR.Hubs;
using MailFeed.Controllers;
using System.Collections.Specialized;

using System.Collections.ObjectModel;namespace MailFeed.Hubs
{
    public class MailHub : Hub
    {
        public MailHub(){
            MailController.Inbox.CollectionChanged += new NotifyCollectionChangedEventHandler(inboxReader_CollectionChanged);
        }

        void  inboxReader_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
 	        Clients.updateInbox(MailController.Inbox);
            
            Clients.alert("You've got mail!");
        }

        public void Add(Mail mail)
        {
            MailController.Inbox.Add(mail);
            Caller.alert("Mail sent!");
        }
    }
}