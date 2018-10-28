using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeeOnSite.Util
{
    public class Utils
    {
        public static string success = "success";
        public static string failure = "failure";


        public static Dictionary<string, dynamic> createResponce(string status, dynamic data)
        {
            Dictionary<string, dynamic> d1 = new Dictionary<string, dynamic>();
            d1.Add("status", status);
            d1.Add("data", data);

            return d1;
        }

    }
}