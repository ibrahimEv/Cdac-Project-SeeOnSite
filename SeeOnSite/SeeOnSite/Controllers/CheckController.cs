using SeeOnSite.DALS;
using SeeOnSite.Models;
using SeeOnSite.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;
using System.Web;

namespace SeeOnSite.Controllers
{
    public class CheckController : ApiController
    {
        AttemptDal Adal = new AttemptDal();
        // GET: api/Check
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Check/5
        public IHttpActionResult Get(int id)
        {
           

        
            Customer cust = Adal.checkAttempt(id);
            string status = cust != null ? Utils.success : Utils.failure;
            return Ok(Utils.createResponce(status, cust));
        }
    

        // POST: api/Check
        [HttpPost]
        public object Post([FromBody]Customer cust)
        {
          int result =  Adal.updateAttempt(cust.vid, cust.attempt);
            string status = result > 0 ? Utils.success : Utils.failure;
            return Utils.createResponce(status, result);
        }

        // PUT: api/Check/5
        public void Put(int id, [FromBody]int attempt)
        {
            int x = id;
        }

        // DELETE: api/Check/5
        public void Delete(int id)
        {
        }
    }
}
