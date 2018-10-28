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
    public class LandlordController : ApiController
    {

        LandlordDal ldal = new LandlordDal();
        
        // GET: api/Landlord
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Landlord/5
        public IHttpActionResult Get(int id)
        {
           Landlord lord = this.ldal.GetLord(id);
            string status = lord != null ? Utils.success : Utils.failure;
            return Ok(Utils.createResponce(status, lord));
        }

        // POST: api/Landlord
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Landlord/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Landlord/5
        public void Delete(int id)
        {
        }
    }
}
