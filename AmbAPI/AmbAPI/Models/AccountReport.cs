using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AmbAPI.Models
{
    public class AccountReport    {
        [Key]
        public int ID { get; set; }

        public string KmName { get; set; }

        public int FatherID { get; set; }

        public int Level { get; set; }

    }
}