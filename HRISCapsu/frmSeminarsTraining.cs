using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace HRISCapsu
{
    public partial class frmSeminarsTraining : Form
    {
        public frmSeminarsTraining()
        {
            InitializeComponent();
        }

        private void DisplayEmployees()
        {
            try
            {
                using (var connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["HRISConnection"].ConnectionString))
                {
                    connection.Open();
                    string query = "SELECT emp.employee_no, emp.position_item_no, CONCAT(emp.last_name, '. ', emp.first_name, ' ', emp.middle_name) AS FullName, emp.department, emp.work_status, emp.employee_type FROM employees emp INNER JOIN employee_seminars empsem ON emp.employee_no = empsem.employee_no WHERE (empsem.seminar_id = @seminar_id) AND (emp.is_deleted = @is_deleted);";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("seminar_id", MySqlDbType.Int32).Value = dtgSeminars.CurrentRow.Cells[0].Value;
                        command.Parameters.AddWithValue("is_deleted", MySqlDbType.Int32).Value = 0;
                        var da = new MySqlDataAdapter();
                        da.SelectCommand = command;
                        var dt = new DataTable();
                        da.Fill(dt);
                        dtgEmployees.DataSource = dt;
                        dtgEmployees.Columns[0].HeaderText = "Employee No.";
                        dtgEmployees.Columns[1].HeaderText = "Item No.";
                        dtgEmployees.Columns[2].HeaderText = "Full Name";
                        dtgEmployees.Columns[3].HeaderText = "Department";
                        dtgEmployees.Columns[4].HeaderText = "Work Status";
                        dtgEmployees.Columns[5].HeaderText = "Employee Type";
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No records found!", "Not found",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplaySeminars()
        {
            try
            {
                using (var connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["HRISConnection"].ConnectionString))
                {
                    connection.Open();
                    string query = "SELECT * from seminars WHERE is_deleted = @is_deleted";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("is_deleted", MySqlDbType.Int32).Value = 0;
                        var da = new MySqlDataAdapter();
                        da.SelectCommand = command;

                        var dt = new DataTable();
                        da.Fill(dt);

                        dtgSeminars.DataSource = dt;

                        dtgSeminars.Columns[0].Visible = false;
                        dtgSeminars.Columns[1].HeaderText = "Seminar";
                        dtgSeminars.Columns[2].HeaderText = "Location";
                        dtgSeminars.Columns[3].HeaderText = "Date";
                        dtgSeminars.Columns[4].HeaderText = "Based";
                        dtgSeminars.Columns[5].Visible = false;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No records found!", "Not found",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddSeminar_Click(object sender, EventArgs e)
        {
            var frm = new frmAddSeminar();
            frm.ShowDialog();
            DisplaySeminars();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmAddSeminarEmployee(dtgSeminars.CurrentRow.Cells[0].Value.ToString());
                frm.ShowDialog();
                DisplayEmployees();
            }
            catch (Exception)
            {
                MessageBox.Show("Please select row first in seminar list.!", "Not found",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void frmSeminarsTraining_Load(object sender, EventArgs e)
        {
            DisplaySeminars();
        }

        private void dtgSeminars_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DisplayEmployees();
        }

        private void dtgSeminars_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DisplayEmployees();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            try
            {
                using (var connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["HRISConnection"].ConnectionString))
                {
                    connection.Open();
                    string query = "UPDATE seminars SET is_deleted = @is_deleted WHERE id = @id;";
                    var cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("is_deleted", MySqlDbType.Int32).Value = 1;
                    cmd.Parameters.AddWithValue("id", MySqlDbType.Int32).Value = dtgSeminars.CurrentRow.Cells[0].Value;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Successfully deleted!", "Success", MessageBoxButtons.OK,
                                MessageBoxIcon.None);
                    DisplaySeminars();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please select row first.", "Not found",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}