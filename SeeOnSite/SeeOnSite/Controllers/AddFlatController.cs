using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SeeOnSite.DALS;
using SeeOnSite.Models;
using SeeOnSite.Util;
using System.Web;
using System.IO;

namespace SeeOnSite.Controllers
{
    public class AddFlatController : ApiController
    {
        FlatsDal fdal = new FlatsDal();
        [HttpPost]
        public IHttpActionResult add()
        {
            try {
                FullFlatInfo info = new FullFlatInfo();
                Address add = new Address();
                string imgname1 = "";
                string imgname2 = "";
                string imgname3 = "";

                var httpRequest = HttpContext.Current.Request;
                var postedfile1 = httpRequest.Files["img1"];
                var postedfile2 = httpRequest.Files["img2"];
                var postedfile3 = httpRequest.Files["img3"];

                info.img1 = encrypter(postedfile1);
                info.img2 = encrypter(postedfile2);
                info.img3 = encrypter(postedfile3);


                var filepath1 = HttpContext.Current.Server.MapPath("~/images/" + info.img1 + Path.GetExtension(postedfile1.FileName));
                postedfile1.SaveAs(filepath1);
                var filepath2 = HttpContext.Current.Server.MapPath("~/images/" + info.img2 + Path.GetExtension(postedfile1.FileName));
                postedfile2.SaveAs(filepath2);
                var filepath3 = HttpContext.Current.Server.MapPath("~/images/" + info.img3 + Path.GetExtension(postedfile1.FileName));
                postedfile3.SaveAs(filepath3);


                int loginid = Convert.ToInt32(httpRequest.Form["loginid"]);
                info.flatno = Convert.ToInt32(httpRequest.Form["flatno"]);
                info.furnished = httpRequest.Form["furnished"];
                info.flattype = httpRequest.Form["flattype"];
                info.flatfor = httpRequest.Form["flatfor"];
                info.housearea = httpRequest.Form["housearea"];
                info.description = httpRequest.Form["description"];
                info.property= httpRequest.Form["property"];
                info.price = Convert.ToDouble( httpRequest.Form["price"]);
                add.landmark = httpRequest.Form["landmark"];
                add.cityname = httpRequest.Form["cityname"];
                add.fulladd = httpRequest.Form["fulladd"];

                int inseted = fdal.addproperty(info, add, loginid);
                string status = inseted == 1 ? Utils.success : Utils.failure;

                return Ok(Utils.createResponce(status, inseted));
            }
            catch
            {
                return Ok(Utils.createResponce(Utils.failure, 0));
            }
        }

        public string encrypter(HttpPostedFile postedfile)
        {
          string imgname = new string(Path.GetFileNameWithoutExtension(postedfile.FileName).Take(10).ToArray()).Replace(" ", "-");
            imgname = imgname + DateTime.Now.ToString("yymmssfff");

            return imgname;
        }
    }
}
