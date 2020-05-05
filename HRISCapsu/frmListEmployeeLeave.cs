using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace HRISCapsu
{
    public partial class frmListEmployeeLeave : Form
    {
        public static string employeeNo;
        public static string leaveCredits;
        private string _employeeType;
        public frmListEmployeeLeave(string employeeType)
        {
            InitializeComponent();
            _employeeType = employeeType;
        }

        void DisplayEmployees()
        {
            try
            {
                using (MySqlConnection conn =
                    new MySqlConnection(ConfigurationManager.ConnectionStrings["HRISConnection"].ConnectionString))
                {
                    conn.Open();
                    string query =
                        "SELECT employees.employee_no, CONCAT(last_name, ', ', first_name, ' ', UPPER(SUBSTRING(middle_name, 1, 1)), '.') AS fullname, tbl_leave_credits.remaining_leave_credit FROM employees INNER JOIN tbl_leave_credits ON employees.employee_no = tbl_leave_credits.employee_no WHERE (first_name LIKE @fn OR middle_name LIKE @mn OR last_name LIKE @ln) AND (employee_type = @employee_type) AND (employees.is_deleted = @is_deleted);";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("fn", '%' + txtEmployeeName.Text + '%');
                    cmd.Parameters.AddWithValue("mn", '%' + txtEmployeeName.Text + '%');
                    cmd.Parameters.AddWithValue("ln", '%' + txtEmployeeName.Text + '%');
                    cmd.Parameters.AddWithValue("employee_type", _employeeType);
                    cmd.Parameters.AddWithValue("is_deleted", 0);
                    var da = new MySqlDataAdapter(cmd);
                    var dt = new DataTable();
                    da.Fill(dt);


                    dtgRecords.DataSource = dt;

                    dtgRecords.Columns[0].HeaderText = "Employee No.";
                    dtgRecords.Columns[1].HeaderText = "Employee Name";
                    dtgRecords.Columns[2].Visible = false;

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("No data found.", "Not found",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmListEmployeeLeave_Load(object sender, EventArgs e)
        {
            DisplayEmployees();
        }

        private void txtEmployeeName_TextChanged(object sender, EventArgs e)
        {
            DisplayEmployees();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
            
        }

        private void dtgRecords_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            employeeNo = dtgRecords.CurrentRow.Cells[0].Value.ToString();
            leaveCredits = dtgRecords.CurrentRow.Cells[2].Value.ToString();
            this.Close();
        }
    }
}
