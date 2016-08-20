using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmbAPI.Models
{
    public class Notice
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime PublishDate { get; set; }

        public string Publisher { get; set; }

        public int ViewCount { get; set; }
    }
}