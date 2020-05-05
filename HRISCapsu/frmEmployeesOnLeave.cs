using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HRISCapsu.Repository.EmployeeRepository;


namespace HRISCapsu
{
    public partial class frmEmployeesOnLeave : Form
    {
        private string _employeeType;
        public frmEmployeesOnLeave(string employeeType)
        {
            InitializeComponent();
            _employeeType = employeeType;
            if (_employeeType == "Academic")
            {
                BindAcademicEmployeesOnLeaveInGridView();
                dtgRecords.Columns[0].HeaderText = "Name";
                dtgRecords.Columns[1].HeaderText = "Leave Credits";
                dtgRecords.Columns[2].HeaderText = "Remaining Leave Credits";
            }
            else if (_employeeType == "Non - Academic")
            {
                BindNonAcademicEmployeesOnLeaveInGridView();
                dtgRecords.Columns[0].HeaderText = "Name";
                dtgRecords.Columns[1].HeaderText = "Leave Started";
                dtgRecords.Columns[2].HeaderText = "Leave End";
            }
        }
        private void BindAcademicEmployeesOnLeaveInGridView()
        {
            using (var dt = new DataTable())
            {
                GetAcademicEmployeesOnLeave(txtEmployeeName.Text, 0, dt);
                dtgRecords.DataSource = dt;
            }

        }

        private void BindNonAcademicEmployeesOnLeaveInGridView()
        {
            using (var dt = new DataTable())
            {
                GetNonAcademicEmployeesOnLeave(txtEmployeeName.Text, 0, dt);
                dtgRecords.DataSource = dt;
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmEmployeesOnLeave_Load(object sender, EventArgs e)
        {

        }

        private void txtEmployeeName_TextChanged(object sender, EventArgs e)
        {
            if (_employeeType == "Academic")
            {
                BindAcademicEmployeesOnLeaveInGridView();
            }
            else if (_employeeType == "Non - Academic")
            {
                BindNonAcademicEmployeesOnLeaveInGridView();
            }
        }
    }
}
