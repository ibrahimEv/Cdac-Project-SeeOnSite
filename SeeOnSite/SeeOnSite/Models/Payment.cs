using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeeOnSite.Models
{
    public class Payment :Offers
    {
        public int trid { get; set; }
        public int vid { get; set; }
        public string nameoncard { get; set; }
        public string accountno { get; set; }
        public DateTime date { get; set; }
    }
}