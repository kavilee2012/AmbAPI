using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AmbAPI.Models
{
    public class User
    {
        public int ID { get; set; }

        [Key]
        public string UserCode { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        [DefaultValue(1900-1-1)]
        public DateTime Birthday { get; set; }

        public bool Sex { get; set; }

        public string Mobile { get; set; }

        public string SBU { get; set; }
    }
}