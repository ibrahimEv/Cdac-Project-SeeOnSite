using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using SeeOnSite.Models;

namespace SeeOnSite.DALS
{
    public class RagisterDal
    {
        public static string constr = ConfigurationManager.ConnectionStrings["mysqlcon"].ToString();
        public static MySqlConnection con = new MySqlConnection(constr);

        public RagisterDal()
        {

        }

        public int RagisterCust(Customer cust)
        {
            con.Open();
            MySqlTransaction transaction = con.BeginTransaction();
            try {
                
                string queryformat = "insert into login(email,password,role) values('{0}','{1}','C')";
                string Query = string.Format(queryformat, cust.email, cust.password);
                MySqlCommand cmd = new MySqlCommand(Query, con, transaction);
                int RowAffected = cmd.ExecuteNonQuery();

                
                
                    string queryformat2 = "INSERT INTO customer(fname,lname,gender,mobno,city,profession,attempt,prime,vid) ";
                    queryformat2 += "VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}',(SELECT vid FROM login WHERE email='{8}'))";

                    string Query2 = string.Format(queryformat2, cust.fname, cust.lname, cust.gender, cust.mobno,
                                           cust.city, cust.profession,cust.attempt, cust.prime, cust.email);
                    MySqlCommand cmd2 = new MySqlCommand(Query2, con, transaction);
                    int RowAffected2 = cmd2.ExecuteNonQuery();
                    transaction.Commit();
                    
                    
                
                con.Close();
               
                return RowAffected;
            }
            catch
            {
                transaction.Rollback();
                con.Close();
                return 0;
            }
        }


        public int RagisterLandlord(Landlord lord)
        {
            con.Open();
            MySqlTransaction transaction = con.BeginTransaction();
            try
            {
                
                string queryformat = "insert into login(email,password,role) values('{0}','{1}','L')";
                string Query = string.Format(queryformat, lord.email, lord.password);
                MySqlCommand cmd = new MySqlCommand(Query, con, transaction);
                int RowAffected = cmd.ExecuteNonQuery();

                
                
                    string queryformat2 = "INSERT INTO landlord(fname,lname,gender,mobno1,mobno2,city,vid) ";
                    queryformat2 += "VALUES('{0}','{1}','{2}','{3}','{4}','{5}', (SELECT vid FROM login WHERE email='{6}'))";

                    string Query2 = string.Format(queryformat2, lord.fname, lord.lname, lord.gender, lord.mobno1, lord.mobno2,
                                           lord.city, lord.email);
                    MySqlCommand cmd2 = new MySqlCommand(Query2, con, transaction);
                    int RowAffected2 = cmd2.ExecuteNonQuery();
                    transaction.Commit();
                    con.Close();
                    return RowAffected;

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
