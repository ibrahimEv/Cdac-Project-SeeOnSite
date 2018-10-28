using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SeeOnSite.Models;
using SeeOnSite.DALS;
using SeeOnSite.Util;
using System.Web.Http.Cors;


namespace SeeOnSite.Controllers
{
    
    public class ValuesController : ApiController
    {
        private DalLogin lg = new DalLogin();
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public IHttpActionResult Post([FromBody]Login cred)
        {
            Login lg = this.lg.validation( cred);
            string status = (lg == null) ? Utils.failure : Utils.success;
            return Ok(Utils.createResponce(status, lg));
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
