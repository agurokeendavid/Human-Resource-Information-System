using Microsoft.Reporting.WinForms;
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
    public partial class frmViewRegularEmployeesReport : Form
    {
        public frmViewRegularEmployeesReport()
        {
            InitializeComponent();
        }

        private void frmViewRegularEmployeesReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hriscapsuDataSet.view_regular_employees' table. You can move, or remove it, as needed.
            this.view_regular_employeesTableAdapter.Fill(this.hriscapsuDataSet.view_regular_employees);
            var reportDataSource = new ReportDataSource();
            // Must match the DataSource in the RDLC
            reportDataSource.Name = "DataSet1";
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewer1.RefreshReport();
        }
    }
}
