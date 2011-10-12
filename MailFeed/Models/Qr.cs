using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace MailFeed.Models
{
    public class Qr
    {
        public bool Scanned
        {
            get;
            set;
        }
        
        public string Url { get; set; }
    }
}