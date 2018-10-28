using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using SeeOnSite.Models;
using MySql.Data.MySqlClient;
using System.Configuration;
using SeeOnSite.Models;



namespace SeeOnSite.DALS
{
    public class FlatsDal
    {
        public static string constr = ConfigurationManager.ConnectionStrings["mysqlcon"].ToString();
        public static MySqlConnection con = new MySqlConnection(constr);


        public int addproperty(FullFlatInfo info,Address add,int loginid)
        {
            con.Open();
            MySqlTransaction transaction = con.BeginTransaction();
            try
            {
                // this Query insert data in address table
                string queryformat = "insert into address(cityname,landmark,fulladd) values('{0}','{1}','{2}')";
                string Query = string.Format(queryformat,add.cityname, add.landmark, add.fulladd);
                MySqlCommand cmd = new MySqlCommand(Query, con, transaction);
                int RowAffected = cmd.ExecuteNonQuery();

                //this will give you auto increment id of address table
                long cityid = cmd.LastInsertedId;


               
                //below sql Query give Actual Lordid using Loginid
                string queryformat5 = "select Lid from landlord where vid ='{0}'";
                string Query5 = string.Format(queryformat5, loginid);
                MySqlCommand cmd5 = new MySqlCommand(Query5, con, transaction);
                int Lid = Convert.ToInt32( (cmd5.ExecuteScalar()).ToString());


                //below mysql query insert sort property information
                string queryformat2 = "INSERT INTO flatinfo(Lid,Cityid,flatno,flatfor,furnished,flattype,img1,propertyfor,price,availability,Auth) ";
                queryformat2 += "VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','yes','yes')";
                string Query2 = string.Format(queryformat2, Lid, cityid, info.flatno,info.flatfor, info.furnished,info.flattype,info.img1,info.property,info.price);
                 MySqlCommand cmd2 = new MySqlCommand(Query2, con, transaction);
                int RowAffected2 = cmd2.ExecuteNonQuery();

                //this below one line of code return auto incremented id
                long Fid = cmd2.LastInsertedId;

               

                //this mysql Query insert full property data in table fullflat info
                string queryformat3 = "INSERT INTO fullflatinfo(Fid,img2,img3,housearea,description) ";
                queryformat3 += "VALUES({0},'{1}','{2}','{3}','{4}')";
                string Query3 = string.Format(queryformat3, Fid, info.img2, info.img3, info.housearea, info.description);
                MySqlCommand cmd3 = new MySqlCommand(Query3, con, transaction);
                int RowAffected3 = cmd3.ExecuteNonQuery();
                


                transaction.Commit();



                con.Close();

                return RowAffected3;
                
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