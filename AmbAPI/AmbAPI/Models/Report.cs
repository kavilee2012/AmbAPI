using System;
using System.Collections.Generic;
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


        int fatherId;

        public int FatherID
        {
            get { return fatherId; }
            set { fatherId = value; }
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
    }
}