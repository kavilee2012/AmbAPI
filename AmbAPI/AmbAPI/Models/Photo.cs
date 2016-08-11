using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmbAPI.Models
{
    public class Photo
    {
        public int ID { get; set; }

        public string Sort { get; set; }

        public int BelongID { get; set; }

        public string Url { get; set; }

        public string ImgInfo { get; set; }

        public DateTime AddTime { get; set; }

        public string AddUser { get; set; }




    }
}