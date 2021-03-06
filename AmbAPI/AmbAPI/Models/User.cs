﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AmbAPI.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }

        public string UserCode { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Mobile { get; set; }

        public bool Sex { get; set; }

        public DateTime? BirthDay { get; set; }

        public virtual SBU Sbu{ get; set; }

        public virtual Photo Photo { get; set; }

    }
}