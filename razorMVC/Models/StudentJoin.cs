using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace razorMVC.Models
{
    public class StudentJoin
    {
        public int sid { get; set; }
        public string name { get; set; }
        public Nullable<int> age { get; set; }
        public Nullable<int> country { get; set; }
        public string ctr_name { get; set; }
        public Nullable<int> state { get; set; }

        public string state_name { get; set; }

    }
}