using C_App.MODEL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace C_App.DAL
{
    internal class EmployeeDAL : DBConnection
    {
        public List<EmployeeBEL> ReadCustomer()
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from Human", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            List<EmployeeBEL> lstCus = new List<EmployeeBEL>();
            while (reader.Read())
            {
                EmployeeBEL cus = new EmployeeBEL();
                cus.id = int.Parse(reader["id"].ToString());
                cus.Name = reader["name"].ToString();
                cus.age = int.Parse(reader["age"].ToString());
                cus.country = reader["country"].ToString();
                cus.status = reader["status"].ToString();
                cus.salary = int.Parse(reader["salary"].ToString());
                lstCus.Add(cus);
            }
            conn.Close();
            return lstCus;
        }
        public void EditEmployee(EmployeeBEL Em)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
           
            SqlCommand cmd = new SqlCommand("update Human set name=@name,age=@age,country=@country,status=@status,salary=@salary where id=@id", conn);
            
            cmd.Parameters.Add(new SqlParameter("@id", Em.id));
            cmd.Parameters.Add(new SqlParameter("@name", Em.Name));
            cmd.Parameters.Add(new SqlParameter("@age", Em.age));
            cmd.Parameters.Add(new SqlParameter("@country", Em.country));
            cmd.Parameters.Add(new SqlParameter("@status", Em.status));
            cmd.Parameters.Add(new SqlParameter("@salary", Em.salary));
            cmd.ExecuteNonQuery();
            conn.Close();
        }
 public void DeleteEmployee(EmployeeBEL cus)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete from Human where id=@id", conn);
            cmd.Parameters.Add(new SqlParameter("@id", cus.id));
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public bool NewEmployee(EmployeeBEL Em)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            string query = "SELECT COUNT(*) FROM Human WHERE id  = @id";
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@id",Em.id );
                int count = (int)command.ExecuteScalar();

                if (count > 0)
                {
                    return false;
                }
            }

            // Thêm nhân viên vào cơ sở dữ liệu
            query = "INSERT INTO NhanVien (ID) VALUES (@ID)";
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@id", Em.id);
                command.Parameters.AddWithValue("@Name", Em.Name);
                command.Parameters.AddWithValue("@age", Em.age);
                command.Parameters.AddWithValue("@country", Em.country);
                command.Parameters.AddWithValue("@status", Em.status);
                command.Parameters.AddWithValue("@salary", Em.salary);

                command.ExecuteNonQuery();
            }

            return true; // Thêm thành công
        }
    }
}
