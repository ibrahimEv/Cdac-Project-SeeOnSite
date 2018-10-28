using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeeOnSite.Models
{
    public class Flatinfo:Address
    {
        public int Fid { get; set; }
        public int Cid { get; set; }
        public int flatno { get; set; }
        public string flatfor { get; set; }
        public string furnished { get; set; }
        public string flattype { get; set; }
        public string img1 { get; set; }
        public string property { get; set; }
        public double price { get; set; }
        public string availability { get; set; }
        public string premium { get; set; }
    }
}