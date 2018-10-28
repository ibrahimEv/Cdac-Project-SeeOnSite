using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using SeeOnSite.Models;

namespace SeeOnSite.DALS
{
    public class LandlordDal
    {
        public static string constr = ConfigurationManager.ConnectionStrings["mysqlcon"].ToString();
        public static MySqlConnection con = new MySqlConnection(constr);

        public Landlord GetLord(int Lid)
        {
            con.Open();
            MySqlDataReader reader;
            MySqlTransaction transaction = con.BeginTransaction();
            try
            {
                string queryformat = "SELECT landlord.vid,fname,lname,gender,mobno1,mobno2,city,email from landlord,login ";
                queryformat += " where landlord.vid = login.vid and Lid='{0}'";


                string Query = string.Format(queryformat, Lid);
                MySqlCommand cmd = new MySqlCommand(Query, con,transaction);
                 reader = cmd.ExecuteReader();
                Landlord lord = new Landlord();
                if (reader.Read())
                {
                    lord.vid = Convert.ToInt32(reader[0]);
                    lord.fname = reader[1].ToString();
                    lord.lname = reader[2].ToString();
                    lord.gender = reader[3].ToString();
                    lord.mobno1 = reader[4].ToString();
                    lord.mobno2 = reader[5].ToString();
                    lord.city = reader[6].ToString();
                    lord.email = reader[7].ToString();

                    reader.Dispose();
                    transaction.Commit();
                    con.Close();
                    return lord;
                }
                else
                {
                    reader.Dispose();
                    con.Close();
                    return null;
                }
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