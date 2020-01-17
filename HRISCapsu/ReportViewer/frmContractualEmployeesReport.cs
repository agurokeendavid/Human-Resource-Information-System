using System;
using System.Windows.Forms;

namespace HRISCapsu.ReportViewer
{
    public partial class frmContractualEmployeesReport : Form
    {
        public frmContractualEmployeesReport()
        {
            InitializeComponent();
        }

        private void frmContractualEmployeesReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hRISDataSource.view_contractual_employees' table. You can move, or remove it, as needed.
            this.view_contractual_employeesTableAdapter.Fill(this.hRISDataSource.view_contractual_employees);

            this.reportViewer1.RefreshReport();
        }
    }
}