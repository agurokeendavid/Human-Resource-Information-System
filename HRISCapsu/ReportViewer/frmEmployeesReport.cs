using System;
using System.Windows.Forms;

namespace HRISCapsu.ReportViewer
{
    public partial class frmEmployeesReport : Form
    {
        public frmEmployeesReport()
        {
            InitializeComponent();
        }

        private void frmEmployeesReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hRISDataSource.view_employees' table. You can move, or remove it, as needed.
            view_employeesTableAdapter.Fill(hRISDataSource.view_employees);
            // TODO: This line of code loads data into the 'hRISDataSource.view_employees' table. You can move, or remove it, as needed.
            view_employeesTableAdapter.Fill(hRISDataSource.view_employees);

            reportViewer1.RefreshReport();
        }
    }
}