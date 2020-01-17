using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace HRISCapsu
{
    public partial class frmListofEmployees : Form
    {
        public frmListofEmployees()
        {
            InitializeComponent();
            frmLogin.SendMessage(txtSearch.Handle, 0x1501, 1, "Employee name.");
            displayRecords(dtgRecords, txtSearch.Text);
        }

        private void displayRecords(DataGridView gridView, string keyword)
        {
            try
            {
                using (var conn = new MySqlConnection(Classes.DBConnection.conString))
                {
                    conn.Open();
                    string query = @"SELECT emp.employee_no, emp.first_name, emp.middle_name, emp.last_name, emp.address, emp.gender, date_format(emp.date_of_birth, '%M %d, %Y') AS 'Date of Birth', emp.place_of_birth, emp.contact_no, emp.civil_status, pos.position_name, dept.department_name, emp.work_status, date_format(emp.hired_date, '%M %d, %Y') AS 'Hired Date', date_format(emp.end_of_contract, '%M %d, %Y') AS 'End of Contract' FROM employees emp INNER JOIN positions pos ON emp.position_id = pos.position_id INNER JOIN departments dept ON emp.department_id = dept.department_id WHERE (emp.first_name LIKE @keyword OR emp.middle_name LIKE @keyword OR emp.last_name LIKE @keyword) AND (emp.work_status = 'Regular') AND (emp.status = 'Active')";
                    var cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("keyword", '%' + keyword + '%');
                    var da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;
                    var dt = new DataTable();
                    da.Fill(dt);

                    gridView.DataSource = dt;

                    gridView.Columns[0].HeaderText = "Employee No.";
                    gridView.Columns[1].HeaderText = "First Name";
                    gridView.Columns[2].HeaderText = "Middle Name";
                    gridView.Columns[3].HeaderText = "Last Name";
                    gridView.Columns[4].HeaderText = "Address";
                    gridView.Columns[5].HeaderText = "Gender";
                    gridView.Columns[6].Visible = true;
                    gridView.Columns[7].Visible = false;
                    gridView.Columns[8].Visible = false;
                    gridView.Columns[9].Visible = false;
                    gridView.Columns[10].HeaderText = "Position";
                    gridView.Columns[11].HeaderText = "Department";
                    gridView.Columns[12].HeaderText = "Work Status";
                    gridView.Columns[13].HeaderText = "Hired Date";
                    gridView.Columns[14].Visible = false;

                    if (dt.Rows.Count == 0)
                        MessageBox.Show("No data found!", "Not found",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtgRecords_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            displayRecords(dtgRecords, txtSearch.Text);
        }

        private void frmListofEmployees_Load(object sender, EventArgs e)
        {
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            var frm = new ReportViewer.frmRegularEmployeesReport();
            frm.ShowDialog();
        }
    }
}