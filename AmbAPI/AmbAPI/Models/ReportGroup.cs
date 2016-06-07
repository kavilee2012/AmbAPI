using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AmbAPI.Models
{
    public class ReportGroup
    {
        [Key]
        public string Code { get; set; }

        public string Name { get; set; }
    }
}