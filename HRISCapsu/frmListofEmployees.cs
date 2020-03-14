using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using HRISCapsu.ReportPreviewer;

namespace HRISCapsu
{
    public partial class frmListofEmployees : Form
    {
        private string employeeType;
        public frmListofEmployees(string employeeType)
        {
            InitializeComponent();
            this.employeeType = employeeType;
            frmLogin.SendMessage(txtSearch.Handle, 0x1501, 1, "Employee name.");
            displayRecords(dtgRecords, txtSearch.Text);
        }


        private void displayRecords(DataGridView gridView, string keyword)
        {
            try
            {
                using (MySqlConnection conn =
                    new MySqlConnection(ConfigurationManager.ConnectionStrings["HRISConnection"].ConnectionString))
                {
                    conn.Open();
                    string query = @"SELECT emp.employee_no, emp.first_name, emp.middle_name, emp.last_name, emp.address, emp.gender, date_format(emp.date_of_birth, '%M %d, %Y') AS DateOfBirth, emp.place_of_birth, emp.contact_no, emp.civil_status, emp.highest_degree, emp.bs_course, emp.bs_year_graduated, emp.bs_school, emp.masteral_course, emp.masteral_year_graduated, emp.masteral_school, emp.doctoral_course, emp.doctoral_year_graduated, emp.doctoral_school, emp.eligibility, emp.employee_type, emp.position, emp.department, emp.work_status, employee_photo, emp.documentpath, date_format(emp.hired_date, '%M %d, %Y') AS HiredDate, date_format(emp.end_of_contract, '%M %d, %Y') AS EndOfContract FROM employees emp WHERE emp.last_name LIKE @keyword AND emp.work_status = @work_status AND emp.is_deleted = @is_deleted AND emp.employee_type = @employee_type ORDER BY emp.last_name ASC;";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("keyword", '%' + keyword + '%');
                    cmd.Parameters.AddWithValue("work_status", "Regular");
                    cmd.Parameters.AddWithValue("is_deleted", 0);
                    cmd.Parameters.AddWithValue("employee_type", employeeType);
                    MySqlDataAdapter da = new MySqlDataAdapter
                    {
                        SelectCommand = cmd
                    };
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    gridView.DataSource = dt;

                    gridView.Columns[0].HeaderText = "Employee No.";
                    gridView.Columns[1].HeaderText = "First Name";
                    gridView.Columns[2].HeaderText = "Middle Name";
                    gridView.Columns[3].HeaderText = "Last Name";
                    gridView.Columns[4].HeaderText = "Address";
                    gridView.Columns[5].HeaderText = "Gender";
                    gridView.Columns[6].Visible = false;
                    gridView.Columns[7].Visible = false;
                    gridView.Columns[8].Visible = false;
                    gridView.Columns[9].Visible = false;
                    gridView.Columns[10].HeaderText = "Highest Degree";
                    gridView.Columns[11].Visible = false;
                    gridView.Columns[12].Visible = false;
                    gridView.Columns[13].Visible = false;
                    gridView.Columns[14].Visible = false;
                    gridView.Columns[15].Visible = false;
                    gridView.Columns[16].Visible = false;
                    gridView.Columns[17].Visible = false;
                    gridView.Columns[18].Visible = false;
                    gridView.Columns[19].Visible = false;
                    gridView.Columns[20].Visible = false;
                    gridView.Columns[21].HeaderText = "Employee Type";
                    gridView.Columns[22].HeaderText = "Position";
                    gridView.Columns[23].HeaderText = "Department";
                    gridView.Columns[24].HeaderText = "Employee Status";
                    gridView.Columns[25].Visible = false;
                    gridView.Columns[26].Visible = false;
                    gridView.Columns[27].Visible = false;
                    gridView.Columns[28].Visible = false;

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("No data found!", "Not found",
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
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
            if (employeeType == "Academic")
            {
                var frm = new previewAcademicRegularEmployees();
                frm.ShowDialog();
            }
            else if (employeeType == "Non - Academic")
            {
                var frm = new previewNonAcademicRegularEmployees();
                frm.ShowDialog();
            }
        }
    }
}