using C_App.BAL;
using C_App.DAL;
using C_App.MODEL;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C_App.GUI
{
    using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
    using Excel = Microsoft.Office.Interop.Excel;


    public partial class Admin : Form
    {
        private bool isFileOpened = false;
        EmployeeBAL EmBal = new EmployeeBAL();
        private string originalId;
        public Admin()
        {
            InitializeComponent();
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            this.button7.Click += new System.EventHandler(this.button7_Click);
        }

     
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                Export(dgvNV, filePath);
                MessageBox.Show("Xuất thành công.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void Export(DataGridView dgvNV, string filePath)
        {
            if (dgvNV.Rows.Count == 0 || dgvNV.Columns.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Excel.Application excel = new Excel.Application();
            Excel.Workbook workbook = excel.Workbooks.Add();
            Excel.Worksheet worksheet = workbook.ActiveSheet;

            // Export column headers
            for (int i = 0; i < dgvNV.Columns.Count; i++)
            {
                worksheet.Cells[1, i + 1] = dgvNV.Columns[i].HeaderText;
            }

            // Export data rows
            object[,] data = new object[dgvNV.Rows.Count, dgvNV.Columns.Count];
            for (int i = 0; i < dgvNV.Rows.Count; i++)
            {
                for (int j = 0; j < dgvNV.Columns.Count; j++)
                {
                    if (dgvNV.Rows[i].Cells[j].Value != null)
                    {
                        data[i, j] = dgvNV.Rows[i].Cells[j].Value.ToString();
                    }
                    else
                    {
                        data[i, j] = string.Empty;
                    }
                }
            }
            Excel.Range range = worksheet.Range[worksheet.Cells[2, 1], worksheet.Cells[dgvNV.Rows.Count + 1, dgvNV.Columns.Count]];
            range.Value = data;

            // Save workbook
            workbook.SaveAs(filePath, Excel.XlFileFormat.xlOpenXMLWorkbook);
            workbook.Close();
            excel.Quit();
        }

        private void ImportFromExcel(string filePath)
        {
            string connectionString = "Data Source=DESKTOP-85KHDPE\\MISASME2021;Initial Catalog=Retail;Integrated Security=true";


            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {

                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];


                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();


                    for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                    {

                        string id = worksheet.Cells[row, 1].Value.ToString();
                        string Name = worksheet.Cells[row, 2].Value.ToString();
                        string age = worksheet.Cells[row, 3].Value.ToString();
                        string country = worksheet.Cells[row, 4].Value.ToString();
                        string status = worksheet.Cells[row, 5].Value.ToString();
                        int salary = int.Parse(worksheet.Cells[row, 6].Value.ToString());


                        string checkQuery = "SELECT COUNT(*) FROM Human WHERE id = @id";
                        SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                        checkCommand.Parameters.AddWithValue("@id", id);
                        int existingCount = (int)checkCommand.ExecuteScalar();

                        if (existingCount == 0)
                        {

                            string insertQuery = "INSERT INTO Human (id, Name, age, country, status, salary) VALUES (@id, @Name, @age, @country, @status, @salary)";
                            SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                            insertCommand.Parameters.AddWithValue("@id", id);
                            insertCommand.Parameters.AddWithValue("@Name", Name);
                            insertCommand.Parameters.AddWithValue("@age", age);
                            insertCommand.Parameters.AddWithValue("@country", country);
                            insertCommand.Parameters.AddWithValue("@status", status);
                            insertCommand.Parameters.AddWithValue("@salary", salary);
                            insertCommand.ExecuteNonQuery();
                        }
                    }

                    connection.Close();
                }
            }

        }

        private void Admin_Load(object sender, EventArgs e)
        {
            List<EmployeeBEL> lstCus = EmBal.ReadCustomer();
           
            foreach (EmployeeBEL cus in lstCus)
            {
                dgvNV.Rows.Add(cus.id, cus.Name, cus.age, cus.country, cus.status, cus.salary);
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Excel Files|*.xlsx;*.xls";
                openFileDialog.Title = "Chọn tệp Excel";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    ImportFromExcel(filePath);
                    UpdateGUI(filePath);
                }
        }
        private void UpdateGUI(string filePath)
        {

            dgvNV.Rows.Clear();
            dgvNV.Columns.Clear();


            List<EmployeeBEL> data = GetDataFromExcel(filePath);


            dgvNV.Columns.Add("id", "id");
            dgvNV.Columns.Add("Name", "Name");
            dgvNV.Columns.Add("age", "age");
            dgvNV.Columns.Add("country", "country");
            dgvNV.Columns.Add("status", "status");
            dgvNV.Columns.Add("salary", "salary");


            foreach (EmployeeBEL item in data)
            {
                dgvNV.Rows.Add(item.id, item.Name, item.age, item.country, item.status, item.salary);
            }
        }

        private List<EmployeeBEL> GetDataFromExcel(string filePath)
        {
            List<EmployeeBEL> data = new List<EmployeeBEL>();

            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                int rowCount = worksheet.Dimension.Rows;

                for (int row = 2; row <= rowCount; row++)
                {
                    EmployeeBEL item = new EmployeeBEL();
                    item.id = int.Parse(worksheet.Cells[row, 1].Value.ToString());
                    item.Name = worksheet.Cells[row, 2].Value.ToString();
                    item.age = int.Parse(worksheet.Cells[row, 3].Value.ToString());
                    item.country = worksheet.Cells[row, 4].Value.ToString();
                    item.status = worksheet.Cells[row, 5].Value.ToString();
                    item.salary = int.Parse(worksheet.Cells[row, 6].Value.ToString());

                    data.Add(item);
                }
            }

            return data;
        }




        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void dgvNV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvNV_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int indx = e.RowIndex;
            DataGridViewRow row = dgvNV.Rows[indx];
            if (row.Cells[0].Value != null)
            {
                tbId.Text = row.Cells[0].Value.ToString();
                tbName.Text = row.Cells[1].Value.ToString();
                tbAge.Text = row.Cells[2].Value.ToString();
                tbCountry.Text = row.Cells[3].Value.ToString();
                tbStatus.Text = row.Cells[4].Value.ToString();
                tbSalary.Text = row.Cells[5].Value.ToString();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            EmployeeBEL Em = new EmployeeBEL();
            if (tbId.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã học sinh cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbId.Focus();
            }
            else
            {

                Em.id = int.Parse(tbId.Text);
                EmBal.DeleteEmployee(Em);

                MessageBox.Show("Đã xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbId.Focus();
                DataGridViewRow row = dgvNV.CurrentRow;

                this.dgvNV.Rows.Clear();



                List<EmployeeBEL> lstCus = EmBal.ReadCustomer();

                foreach (EmployeeBEL it in lstCus)
                {
                    dgvNV.Rows.Add(it.id, it.Name, it.age, it.country, it.status, it.salary);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvNV.CurrentRow;
            if (row != null)
            {

                EmployeeBEL Em = new EmployeeBEL();
                Em.Name = tbName.Text;
                Em.age = int.Parse(tbAge.Text);
                Em.country = tbCountry.Text;
                Em.status = tbStatus.Text;
                Em.salary = int.Parse(tbSalary.Text);



                EmBal.EditEmployee(Em);
                row.Cells[1].Value = Em.Name;
                row.Cells[2].Value = Em.age;
                row.Cells[3].Value = Em.country;
                row.Cells[4].Value = Em.status;
                row.Cells[5].Value = Em.salary;
            }
            MessageBox.Show("Đã Sửa thành công!");
        }

        private void tbId_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-85KHDPE\\MISASME2021;Initial Catalog=Retail;User ID=sa;Password=sa";
            string searchQuery = "SELECT * FROM Human WHERE Name LIKE @searchText";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(searchQuery, connection))
                {
                    command.Parameters.AddWithValue("@searchText", "%" + tbSearch.Text + "%");

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        dgvNV.Rows.Clear();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                string columnValue = reader.GetString(reader.GetOrdinal("Name"));
                                dgvNV.Rows.Add(Name);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy kết quả.");
                        }
                    }

                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            EmployeeBEL Em = new EmployeeBEL();
            Em.id = int.Parse(tbId.Text);
            Em.Name = tbName.Text;
            Em.age = int.Parse(tbAge.Text);
            Em.country = tbAge.Text;
            Em.status = tbStatus.Text;
            Em.country = tbSalary.Text;
            dgvNV.Rows.Add(Em.id, Em.Name, Em.age, Em.country, Em.status, Em.country);
            MessageBox.Show("Đã thêm thành công!");
        }
    }
}

