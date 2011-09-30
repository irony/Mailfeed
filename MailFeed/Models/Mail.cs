using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MailFeed.Models
{
    public class Mail
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        /*public [] Attachments { get; set; }*/
    }
}
