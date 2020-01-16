using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            this.view_regular_employeesTableAdapter.Fill(this.hRISDataSource.view_regular_employees);

            this.reportViewer1.RefreshReport();
        }
    }
}
