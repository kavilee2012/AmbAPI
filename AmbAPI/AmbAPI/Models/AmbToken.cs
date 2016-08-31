using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace AmbAPI.Models
{
    public class AmbToken
    {
        public int ID { get; set; }

        public string Token { get; set; }

        public string Code { get; set; }

        public DateTime? ExpireTime { get; set; }
    }
}