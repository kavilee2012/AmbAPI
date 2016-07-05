using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmbAPI.Models
{
    public class News
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime AddTime { get; set; }

        public string Author { get; set; }

        public string Url { get; set; }

        public bool IsTop { get; set; }

        public string ImgUrl { get; set; }
    }
}
