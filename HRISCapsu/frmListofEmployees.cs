using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using HRISCapsu.ReportPreviewer;
using static HRISCapsu.Repository.EmployeeRepository;

namespace HRISCapsu
{
    public partial class frmListofEmployees : Form
    {
        private string employeeType;
        private void BindRecordsInGridView()
        {
            using (var dt = new DataTable())
            {
                GetAllListOfEmployees(txtSearch.Text, employeeType, "Regular", 0, dt);
                dtgRecords.AutoGenerateColumns = false;
                dtgRecords.DataSource = dt;
            }
        }
        public frmListofEmployees(string employeeType)
        {
            InitializeComponent();
            this.employeeType = employeeType;
            frmLogin.SendMessage(txtSearch.Handle, 0x1501, 1, "Employee name.");
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
            BindRecordsInGridView();
        }

        private void frmListofEmployees_Load(object sender, EventArgs e)
        {
            BindRecordsInGridView();
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

        private void btnView_Click(object sender, EventArgs e)
        {
            var frm = new frmViewEmployee(dtgRecords.CurrentRow.Cells[0].Value.ToString(), dtgRecords.CurrentRow.Cells[1].Value.ToString(), dtgRecords.CurrentRow.Cells[2].Value.ToString(), dtgRecords.CurrentRow.Cells[3].Value.ToString(), dtgRecords.CurrentRow.Cells[4].Value.ToString(), dtgRecords.CurrentRow.Cells[5].Value.ToString(), dtgRecords.CurrentRow.Cells[6].Value.ToString(), dtgRecords.CurrentRow.Cells[7].Value.ToString(), dtgRecords.CurrentRow.Cells[8].Value.ToString(), dtgRecords.CurrentRow.Cells[9].Value.ToString(), dtgRecords.CurrentRow.Cells[10].Value.ToString(), dtgRecords.CurrentRow.Cells[11].Value.ToString(), dtgRecords.CurrentRow.Cells[12].Value.ToString(), dtgRecords.CurrentRow.Cells[13].Value.ToString(), dtgRecords.CurrentRow.Cells[14].Value.ToString(), dtgRecords.CurrentRow.Cells[15].Value.ToString(), dtgRecords.CurrentRow.Cells[16].Value.ToString(), dtgRecords.CurrentRow.Cells[17].Value.ToString(), dtgRecords.CurrentRow.Cells[18].Value.ToString(), dtgRecords.CurrentRow.Cells[19].Value.ToString(), dtgRecords.CurrentRow.Cells[20].Value.ToString(), dtgRecords.CurrentRow.Cells[21].Value.ToString(), dtgRecords.CurrentRow.Cells[22].Value.ToString(), dtgRecords.CurrentRow.Cells[23].Value.ToString(), dtgRecords.CurrentRow.Cells[24].Value.ToString(), dtgRecords.CurrentRow.Cells[25].Value.ToString(), dtgRecords.CurrentRow.Cells[26].Value.ToString(), dtgRecords.CurrentRow.Cells[27].Value.ToString(), (byte[])dtgRecords.CurrentRow.Cells[28].Value, dtgRecords.CurrentRow.Cells[29].Value.ToString(), dtgRecords.CurrentRow.Cells[30].Value.ToString(), dtgRecords.CurrentRow.Cells[31].Value.ToString(), dtgRecords.CurrentRow.Cells[32].Value.ToString(), dtgRecords.CurrentRow.Cells[33].Value.ToString(), dtgRecords.CurrentRow.Cells[34].Value.ToString(), dtgRecords.CurrentRow.Cells[35].Value.ToString(), dtgRecords.CurrentRow.Cells[36].Value.ToString(), dtgRecords.CurrentRow.Cells[37].Value.ToString(), dtgRecords.CurrentRow.Cells[38].Value.ToString(), dtgRecords.CurrentRow.Cells[39].Value.ToString(), dtgRecords.CurrentRow.Cells[40].Value.ToString(), dtgRecords.CurrentRow.Cells[41].Value.ToString(), dtgRecords.CurrentRow.Cells[42].Value.ToString(), dtgRecords.CurrentRow.Cells[43].Value.ToString(), dtgRecords.CurrentRow.Cells[44].Value.ToString(), dtgRecords.CurrentRow.Cells[45].Value.ToString(), dtgRecords.CurrentRow.Cells[46].Value.ToString(), dtgRecords.CurrentRow.Cells[47].Value.ToString());
            frm.ShowDialog();
            BindRecordsInGridView();
        }
    }
}