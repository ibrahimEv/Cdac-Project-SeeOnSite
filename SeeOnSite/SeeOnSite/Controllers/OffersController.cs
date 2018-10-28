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
    public class OffersController : ApiController
    {
        OffersDal offdal = new OffersDal();
        // GET: api/Offers
        public IHttpActionResult Get()
        {
            List<Offers> offlist = new List<Offers>();
           offlist= offdal.GetOffers();
            string status = offlist == null ? Utils.failure : Utils.success;
            return Ok(Utils.createResponce(status,offlist));
        }

        // GET: api/Offers/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Offers
        public IHttpActionResult Post([FromBody]Payment pay)
        {
           int Result =  offdal.Recharge(pay);
            string status = Result > 0 ? Utils.success : Utils.failure;
            return Ok(Utils.createResponce(status, Result));
        }

        // PUT: api/Offers/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Offers/5
        public void Delete(int id)
        {
        }
    }
}
