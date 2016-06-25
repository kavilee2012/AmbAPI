using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmbAPI.Models
{
    public class Schedule
    {
        public int ScheduleID { get; set; }

        public string UserCode { get; set; }

        public DateTime ScheduleDate { get; set; }

        public string Remark { get; set; }


    }
}