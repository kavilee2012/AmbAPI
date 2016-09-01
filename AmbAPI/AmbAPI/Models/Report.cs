using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AmbAPI.Models
{

    public class Report
    {
        int id;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public String Code
        {
            get;
            set;
        }


        public String FatherCode
        {
            get;
            set;
        }


        int level;

        public int Level
        {
            get { return level; }
            set { level = value; }
        }


        int order;

        public int Order
        {
            get { return order; }
            set { order = value; }
        }


        String name;

        public String Name
        {
            get { return name; }
            set { name = value; }
        }


        String remark;

        public String Remark
        {
            get { return remark; }
            set { remark = value; }
        }

        float money;

        public float Money
        {
            get { return money; }
            set { money = value; }
        }
    }
}