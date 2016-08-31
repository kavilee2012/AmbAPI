using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AmbAPI.Models
{
    public class SBU
    { 
        public int ID { get; set; }

        public String Code{get;set;}

        public String FatherCode{get;set;}

        public int Level { get; set; }

        public int Order { get; set; }

        public string Name { get; set; }

        public string Remark { get; set; }

        public string Header { get; set; }

        public int MemberCount { get; set; }

        public virtual Photo Photo { get; set; }

        //public virtual ICollection<User> Users { get; set; }

    }
}