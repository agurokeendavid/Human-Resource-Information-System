using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRISCapsu
{
    public partial class frmSeminarsTraining : Form
    {
        public frmSeminarsTraining()
        {
            InitializeComponent();
            displaySeminars();
        }

        void displayEmployees()
        {
            try
            {
                using (var conn = new MySqlConnection(Classes.DBConnection.conString))
                {
                    conn.Open();
                    string query = @"SELECT empsem.id, empsem.seminar_id, emp.employee_no, emp.first_name, emp.middle_name, emp.last_name, pos.position_name FROM employee_seminars empsem INNER JOIN employees emp ON empsem.employee_no = emp.employee_no INNER JOIN positions pos ON empsem.employee_position_id = pos.position_id WHERE empsem.seminar_id= @seminar_id";
                    var cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("seminar_id", dtgSeminars.CurrentRow.Cells[0].Value.ToString());
                    var da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;
                    var dt = new DataTable();
                    da.Fill(dt);

                    dtgEmployees.DataSource = dt;

                    dtgEmployees.Columns[0].Visible = false;
                    dtgEmployees.Columns[1].Visible = false;
                    dtgEmployees.Columns[1].HeaderText = "Employee No.";
                    dtgEmployees.Columns[2].HeaderText = "First Name";
                    dtgEmployees.Columns[3].HeaderText = "Middle Name";
                    dtgEmployees.Columns[4].HeaderText = "Last Name";
                    dtgEmployees.Columns[5].HeaderText = "Position";
                    if (dt.Rows.Count == 0)
                        MessageBox.Show("No data found.", "Not found",
    MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void displaySeminars()
        {
            try
            {
                using (var conn = new MySqlConnection(Classes.DBConnection.conString))
                {
                    conn.Open();
                    string query = @"SELECT seminar_id, seminar_name, seminar_location, date_format(seminar_date, '%M %d, %Y') AS 'Date', seminar_status FROM seminars WHERE seminar_status = 'Active'";
                    var cmd = new MySqlCommand(query, conn);
                    var da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;
                    var dt = new DataTable();
                    da.Fill(dt);

                    dtgSeminars.DataSource = dt;

                    dtgSeminars.Columns[0].Visible = false;
                    dtgSeminars.Columns[1].HeaderText = "Seminar";
                    dtgSeminars.Columns[2].HeaderText = "Location";
                    dtgSeminars.Columns[3].HeaderText = "Date of Activity";
                    dtgSeminars.Columns[4].Visible = false;

                    if (dt.Rows.Count == 0)
                        MessageBox.Show("No data found.", "Not found",
    MessageBoxButtons.OK, MessageBoxIcon.Error);


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddSeminar_Click(object sender, EventArgs e)
        {
            var frm = new frmAddSeminar();
            frm.ShowDialog();
            displaySeminars();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var frm = new frmEditSeminar(dtgSeminars.CurrentRow.Cells[0].Value.ToString(), dtgSeminars.CurrentRow.Cells[1].Value.ToString(), dtgSeminars.CurrentRow.Cells[2].Value.ToString(), dtgSeminars.CurrentRow.Cells[3].Value.ToString(), dtgSeminars.CurrentRow.Cells[4].Value.ToString());
            frm.ShowDialog();
            displaySeminars();
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            var frm = new frmAddSeminarEmployee(dtgSeminars.CurrentRow.Cells[0].Value.ToString());
            frm.ShowDialog();
            displayEmployees();
        }


        private void dtgSeminars_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            displayEmployees();
        }

        private void frmSeminarsTraining_Load(object sender, EventArgs e)
        {
            displayEmployees();
        }
    }
}
