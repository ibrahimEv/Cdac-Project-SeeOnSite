using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using SeeOnSite.Models;

namespace SeeOnSite.DALS
{
    public class SearchDal
    {
        public static string constr = ConfigurationManager.ConnectionStrings["mysqlcon"].ToString();
        public static MySqlConnection con = new MySqlConnection(constr);
        MySqlDataReader reader;
        
        public List<FullFlatInfo> SearchResult(string landmark, string cityname, string propertfor)
        {
            con.Open();

            MySqlTransaction transaction = con.BeginTransaction();


            try
            {
               
                MySqlCommand cmd = new MySqlCommand("spSearchFull", con, transaction);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("sp_landmark", "%"+landmark+"%");
                cmd.Parameters.AddWithValue("sp_cityname", cityname);
                cmd.Parameters.AddWithValue("sp_propertyfor", propertfor);
                reader = cmd.ExecuteReader();

                List<FullFlatInfo> proplist = new List<FullFlatInfo>();
                while (reader.Read())
                {
                    FullFlatInfo fullinfo = new FullFlatInfo();
                    fullinfo.Cid = Convert.ToInt32(reader["Lid"]);
                    fullinfo.Fid = Convert.ToInt32(reader["Fid"]);

                    fullinfo.furnished = reader["furnished"].ToString();
                    fullinfo.flattype = reader["flattype"].ToString();
                    fullinfo.flatno = Convert.ToInt32(reader["flatno"]);
                    fullinfo.property = reader["propertyfor"].ToString();
                    fullinfo.price = Convert.ToDouble(reader["price"]);
                    fullinfo.img1 = reader["img1"].ToString();
                    fullinfo.img2 = reader["img2"].ToString();
                    fullinfo.img3 = reader["img3"].ToString();
                    fullinfo.housearea = reader["housearea"].ToString();
                    fullinfo.description = reader["description"].ToString();
                    fullinfo.cityname = reader["cityname"].ToString();
                    fullinfo.landmark = reader["landmark"].ToString();
                    fullinfo.fulladd = reader["fulladd"].ToString();
                    fullinfo.premium = reader["premium"].ToString();
                    fullinfo.flatfor = reader["flatfor"].ToString();

                    proplist.Add(fullinfo);
                }
                reader.Close();
                transaction.Commit();
                con.Close();
                return proplist;
            }
             catch
            {
               
                transaction.Rollback();
                con.Close();
                 return null;
            }
        }

    }
}