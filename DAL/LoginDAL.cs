using C_App.MODEL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_App.DAL
{
    internal class LoginDAL
    {
        public bool AuthenticateUser(LoginBEL log)
        {
            string connectionString = "Data Source=DESKTOP-85KHDPE\\MISASME2021;Initial Catalog=Retail;Integrated Security=true";
            string query = "SELECT COUNT(*) FROM Users WHERE username = @txtUsername AND password = @txtPassword";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@txtUsername", log.Username);
                    command.Parameters.AddWithValue("@txtPassword", log.Password);

                    int count = (int)command.ExecuteScalar();

                    return count > 0;
                  
                }
            }
        }
    }
}