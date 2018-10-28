using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeeOnSite.Models
{
    public class Login
    {
        public int vid { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string role { get; set; }
        public int attempt { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
    }
}