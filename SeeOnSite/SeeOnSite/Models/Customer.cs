using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeeOnSite.Models
{
    public class Customer:Login
    {
        public int cid { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string gender { get; set; }
        public string mobno { get; set; }
        public string city { get; set; }
        public string profession { get; set; }
        public string prime { get; set; }

        private int _attempt =5;

        public int attempt
        {
            get { return _attempt; }
            set { _attempt= value; }
        }

    }
}