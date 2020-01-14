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
    public partial class frmListofContractualEmployees : Form
    {
        public frmListofContractualEmployees()
        {
            InitializeComponent();
            
        }

        void displayRecords(DataGridView gridView, string keyword)
        {
            try
            {
                using (var conn = new MySqlConnection(Classes.DBConnection.conString))
                {
                    conn.Open();
                    string query = @"SELECT emp.employee_no, emp.first_name, emp.middle_name, emp.last_name, emp.address, emp.gender, date_format(emp.date_of_birth, '%M %d, %Y') AS 'Date of Birth', emp.place_of_birth, emp.contact_no, emp.civil_status, pos.position_name, dept.department_name, emp.work_status, date_format(emp.hired_date, '%M %d, %Y') AS 'Hired Date', date_format(emp.end_of_contract, '%M %d, %Y') AS 'End of Contract' FROM employees emp INNER JOIN positions pos ON emp.position_id = pos.position_id INNER JOIN departments dept ON emp.department_id = dept.department_id WHERE (emp.first_name LIKE @keyword OR emp.middle_name LIKE @keyword OR emp.last_name LIKE @keyword) AND (emp.work_status = 'Contractual') AND (emp.status = 'Active')";
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
                    gridView.Columns[14].HeaderText = "End of Contract";

                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataGridViewRow dataGridViewRow in dtgRecords.Rows)
                        {
                            DateTime hiredDate = Convert.ToDateTime(dataGridViewRow.Cells[13].Value);
                            DateTime endOfContract = Convert.ToDateTime(dataGridViewRow.Cells[14].Value);
                            double expiredContract = (endOfContract - DateTime.Now.Date).TotalDays;
                            if (expiredContract >= 1 && expiredContract <= 30)
                            {
                                dataGridViewRow.DefaultCellStyle.BackColor = Color.Red;
                                dataGridViewRow.DefaultCellStyle.ForeColor = Color.White;
                                
                            }
                        }
                    }
                    else
                        MessageBox.Show("No data found!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            displayRecords(dtgRecords, txtSearch.Text);

        }

        private void frmListofContractualEmployees_Load(object sender, EventArgs e)
        {
            displayRecords(dtgRecords, txtSearch.Text);
        }
    }
}
