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
    public partial class frmViewEmployeesReport : Form
    {
        public frmViewEmployeesReport()
        {
            InitializeComponent();
        }

        private void frmViewEmployeesReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hriscapsuDataSet.view_employees' table. You can move, or remove it, as needed.
            this.view_employeesTableAdapter.Fill(this.hriscapsuDataSet.view_employees);
            this.reportViewer1.RefreshReport();
        }
    }
}
