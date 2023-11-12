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
            conn.ConnectionString = @"Data Source=DESKTOP-Q68USUA;Initial Catalog=Retail;User Id=sa;Password=sa";
            return conn;
        }
        
    }
}
