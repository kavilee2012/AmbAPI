using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmbAPI.Models
{
    public class Schedule
    {
        public int ID { get; set; }

        public String UserCode { get; set; }

        public DateTime ScheduleTime { get; set; }

        public string Content { get; set; }

        public DateTime? CreateTime { get; set; }
    }
}