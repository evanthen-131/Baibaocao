using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_App.DAL
{
    internal class DBConnection
    {
        private string connectionString;
        private SqlConnection connection;

        public DBConnection()
        {
        }
        public SqlConnection CreateConnection()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=DESKTOP-85KHDPE\MISASME2021;Initial Catalog=Retail;Integrated Security=true";
            return conn;
        }
        
    }
}
