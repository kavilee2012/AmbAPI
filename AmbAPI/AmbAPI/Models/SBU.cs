﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AmbAPI.Models
{
    public class SBU
    {
        [Key]
        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime AddTime { get; set; }

        public string Leader { get; set; }

        [NotMapped]
        public virtual ICollection<User> Members { get; set; }


    }
}