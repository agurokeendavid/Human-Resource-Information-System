using System;
using System.Windows.Forms;

namespace HRISCapsu.ReportViewer
{
    public partial class frmDepartmentsReport : Form
    {
        public frmDepartmentsReport()
        {
            InitializeComponent();
        }

        private void frmDepartmentsReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hRISDataSource.departments' table. You can move, or remove it, as needed.
            this.departmentsTableAdapter.Fill(this.hRISDataSource.departments);

            this.reportViewer1.RefreshReport();
        }
    }
}