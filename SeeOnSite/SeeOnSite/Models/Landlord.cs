using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeeOnSite.Models
{
    public class Landlord:Login
    {
        public int Lid { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string gender { get; set; }
        public string mobno1 { get; set; }
        public string mobno2 { get; set; }
        public string city { get; set; }
    }
}