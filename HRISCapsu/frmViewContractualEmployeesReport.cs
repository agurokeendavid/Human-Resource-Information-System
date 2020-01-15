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
    public partial class frmViewContractualEmployeesReport : Form
    {
        public frmViewContractualEmployeesReport()
        {
            InitializeComponent();
        }

        private void frmViewContractualEmployeesReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hriscapsuDataSet.view_contractual_employees' table. You can move, or remove it, as needed.
            this.view_contractual_employeesTableAdapter.Fill(this.hriscapsuDataSet.view_contractual_employees);

            this.reportViewer1.RefreshReport();
        }
    }
}
