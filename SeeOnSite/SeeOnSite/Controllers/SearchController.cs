using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SeeOnSite.DALS;
using SeeOnSite.Models;
using SeeOnSite.Util;

namespace SeeOnSite.Controllers
{
   
    public class SearchController : ApiController
    {
        SearchDal sdal = new SearchDal();
        [HttpPost]
        public object getresult([FromBody] FullFlatInfo fullinfo)
        {
            List<FullFlatInfo> proplist = new List<FullFlatInfo>();
            proplist = sdal.SearchResult(fullinfo.landmark, fullinfo.cityname, fullinfo.property);
            string status = (proplist != null) ? Utils.success : Utils.failure;
             return (Utils.createResponce(status, proplist));
        }
    }
}
