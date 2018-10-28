using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SeeOnSite.Models;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace SeeOnSite.DALS
{
    public class AttemptDal
    {
        public static string constr = ConfigurationManager.ConnectionStrings["mysqlcon"].ToString();
        public static MySqlConnection con = new MySqlConnection(constr);

        public Customer checkAttempt(int vid)
        {
            con.Open();
            string queryformat = "SELECT vid,fname,lname,gender,mobno,city,profession,attempt,prime from customer ";
            queryformat += " where vid='{0}'";
           

            string Query = string.Format(queryformat, vid);
            MySqlCommand cmd = new MySqlCommand(Query, con);
            MySqlDataReader reader = cmd.ExecuteReader();
            Customer cust = new Customer();
            if (reader.Read())
            {
                cust.vid = Convert.ToInt32(reader[0]);
                cust.fname = reader[1].ToString();
                cust.lname = reader[2].ToString();
                cust.gender = reader[3].ToString();
                cust.mobno = reader[4].ToString();
                cust.city = reader[5].ToString();
                cust.profession = reader[6].ToString();
                cust.attempt = Convert.ToInt32(reader[7]);
                cust.prime = reader[8].ToString();
                
                con.Close();
                return cust;
            }
            con.Close();
            return null;
        }
        public int updateAttempt(int vid, int attempt)
        {
            con.Open();
            string queryformat = "update customer set attempt = '{0}' where vid = '{1}' ";
           string Query = string.Format(queryformat, attempt,vid);
            MySqlCommand cmd = new MySqlCommand(Query, con);
            int result =cmd.ExecuteNonQuery();
            con.Close();
            return result;

        }
    }

    
}