using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace DoneDoneDone
{
    class DataConnection
    {

        public string GetConnectionString()
        {
            //variable to hold our return value
            string conn = string.Empty;

            conn = ConfigurationManager.ConnectionStrings[""].ConnectionString.ToString();

            //return the value
            return conn;
        }

        //public SqlDataReader establishConn(string cmdText)
        //{
        //    //GetConnectionString();
        //    using (SqlConnection connection = new SqlConnection(GetConnectionString()))
        //    {
        //        SqlDataReader dr;
        //        connection.Open();

        //        using (SqlCommand cmd = new SqlCommand(cmdText, connection))
        //        {
        //            dr = cmd.ExecuteReader();
        //            connection.Close();

        //            return dr;
        //        }
        //    }
        //}
        string conn;
        public DataConnection()
        {            
            conn = "Data Source=NGUYENGIANG-IS;Initial Catalog=CSDL_QuanLyTTTA;Integrated Security=True";
        }
        public SqlConnection GetConnection()
        {
            return new SqlConnection(conn);
        }

    }
    }
