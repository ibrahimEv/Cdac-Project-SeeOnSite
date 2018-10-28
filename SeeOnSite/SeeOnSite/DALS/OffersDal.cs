using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using SeeOnSite.Models;

namespace SeeOnSite.DALS
{
    public class OffersDal
    {
        public static string constr = ConfigurationManager.ConnectionStrings["mysqlcon"].ToString();
        public static MySqlConnection con = new MySqlConnection(constr);
        List<Offers> offlist = new List<Offers>();
        MySqlDataReader reader;


       public List<Offers> GetOffers()
        {
            con.Open();
            MySqlTransaction transaction = con.BeginTransaction();
            try
            {
                string Query = "select offid,benefit,ammount from offers";
                MySqlCommand cmd = new MySqlCommand(Query,con,transaction);
                 reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Offers offer = new Offers();
                    offer.offid = Convert.ToInt32(reader["offid"]);
                    offer.benefit = Convert.ToInt32(reader["benefit"]);
                    offer.ammount = Convert.ToDouble(reader["ammount"]);
                    offlist.Add(offer);

                }
                reader.Close();
                transaction.Commit();
                con.Close();
                return offlist;
                

            }
            catch
            {
                reader.Close();
                transaction.Rollback();
                con.Close();
                return null;
            }


            return null;
         }
        public int Recharge(Payment pay)
        {
            con.Open();
            MySqlTransaction transaction = con.BeginTransaction();
            try
            {
                string stringformat = "insert into payment(Cid,ammount,accountno,nameoncard,date) ";
                stringformat += "values('{0}','{1}','{2}','{3}','{4}')";
                string date = DateTime.Now.ToString("yymmssfff");

                string Query = string.Format(stringformat, pay.vid, pay.ammount, pay.accountno, pay.nameoncard, date);
                MySqlCommand cmd = new MySqlCommand(Query, con, transaction);
                int result = cmd.ExecuteNonQuery();
                string queryformat = "update customer set attempt = '{0}' where vid = '{1}' ";
                string Query2 = string.Format(queryformat, pay.benefit, pay.vid);
                MySqlCommand cmd2 = new MySqlCommand(Query2, con, transaction);
                int result2 = cmd2.ExecuteNonQuery();
                transaction.Commit();
                con.Close();
                return result2;
                
            }
            catch
            {
                transaction.Rollback();
                con.Close();
                return 0;
            }

        }
    }   
}