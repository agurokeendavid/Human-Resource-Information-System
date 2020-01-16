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
    public partial class frmViewDepartmentsReport : Form
    {
        public frmViewDepartmentsReport()
        {
            InitializeComponent();
        }

        private void frmViewDepartmentsReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hriscapsuDataSet.departments' table. You can move, or remove it, as needed.
            this.departmentsTableAdapter.Fill(this.hriscapsuDataSet.departments);

            this.reportViewer1.RefreshReport();
        }
    }
}
