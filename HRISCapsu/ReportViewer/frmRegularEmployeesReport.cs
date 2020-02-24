using System;
using System.Windows.Forms;

namespace HRISCapsu.ReportViewer
{
    public partial class frmRegularEmployeesReport : Form
    {
        public frmRegularEmployeesReport()
        {
            InitializeComponent();
        }

        private void frmRegularEmployeesReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hRISDataSource.view_regular_employees' table. You can move, or remove it, as needed.
            view_regular_employeesTableAdapter.Fill(hRISDataSource.view_regular_employees);

            reportViewer1.RefreshReport();
        }
    }
}