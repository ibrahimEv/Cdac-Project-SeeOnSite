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
    public class RagisterController : ApiController
    {
        RagisterDal rd = new RagisterDal();
        // GET: api/Ragister
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Ragister/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Ragister
        
        public IHttpActionResult RagisterCust([FromBody]Customer cust)
        {
           int rows = rd.RagisterCust(cust);
            string status = (rows > 0) ? Utils.success : Utils.failure;
            return Ok(Utils.createResponce(status, rows));

        }

        public IHttpActionResult RagisterLord([FromBody]Landlord lord)
        {
            int rows = rd.RagisterLandlord(lord);
            string status = (rows > 0) ? Utils.success : Utils.failure;
            return Ok(Utils.createResponce(status, rows));

        }

        // PUT: api/Ragister/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Ragister/5
        public void Delete(int id)
        {
        }
    }
}
