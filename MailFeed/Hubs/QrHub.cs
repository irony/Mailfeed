using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SignalR.Hubs;
using MailFeed.Controllers;
using System.Collections.Specialized;

using System.Collections.ObjectModel;namespace MailFeed.Hubs
{
    public class QrHub : Hub
    {

        /// <summary>
        /// We wire up the subscription to the Inbox ObservableCollection
        /// </summary>
        public QrHub(){
            MvcApplication.IssuedCodes.CollectionChanged += new NotifyCollectionChangedEventHandler(codeScanned);
        }

        /// <summary>
        /// When an item is changed in the IssuedCodes Collection we will get a notification here which we will distribute to the listening clients
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void codeScanned(object sender, NotifyCollectionChangedEventArgs e)
        {
            Clients.updateCodes(MvcApplication.IssuedCodes);
        }

    }
}