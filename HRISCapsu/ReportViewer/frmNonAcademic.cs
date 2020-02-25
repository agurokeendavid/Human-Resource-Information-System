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
    public partial class frmNonAcademic : Form
    {
        public frmNonAcademic()
        {
            InitializeComponent();
        }

        private void frmNonAcademic_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hrisDataSource1.view_nonacademic_employees' table. You can move, or remove it, as needed.
            this.view_nonacademic_employeesTableAdapter.Fill(this.hrisDataSource1.view_nonacademic_employees);

            this.reportViewer1.RefreshReport();
        }
    }
}
