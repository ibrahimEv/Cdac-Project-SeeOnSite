using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using SeeOnSite.Models;

namespace SeeOnSite.DALS
{
    public class DalLogin
    {

        public static string constr = ConfigurationManager.ConnectionStrings["mysqlcon"].ToString();
        public static MySqlConnection con = new MySqlConnection(constr);


        public DalLogin()
        {

        }
        public List<Login> getuser()
        {

            List<Login> list = new List<Login>();
            con.Open();
            MySqlCommand cmd = new MySqlCommand("select * from login", con);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Login lg = new Login();
                lg.vid = Convert.ToInt32(reader[0]);
                lg.email = reader[1].ToString();
                lg.password = reader[2].ToString();
                lg.role = reader[3].ToString();

                list.Add(lg);

            }
            con.Close();
            return list;
        }

       


        public Login validation(Login cred)
        {
            try
            {
                con.Open();
                string queryformat = " SELECT login.vid,email,password,role from login where email='{0}' and password = '{1}'";

                string Query = string.Format(queryformat, cred.email, cred.password);
                MySqlCommand cmd = new MySqlCommand(Query, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                Login lg = new Login();
                if (reader.Read())
                {
                    lg.vid = Convert.ToInt32(reader[0]);
                    lg.email = reader[1].ToString();
                    lg.password = reader[2].ToString();
                    lg.role = reader[3].ToString();
                    con.Close();
                    return lg;

                }

                con.Close();
                return null;
            }
            catch
            {
                con.Close();
                return null;
            }
        }



    }
}
