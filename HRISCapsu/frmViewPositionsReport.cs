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
    public partial class frmViewPositionsReport : Form
    {
        public frmViewPositionsReport()
        {
            InitializeComponent();
        }

        private void frmViewPositionsReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hriscapsuDataSet.positions' table. You can move, or remove it, as needed.
            this.positionsTableAdapter.Fill(this.hriscapsuDataSet.positions);

            this.reportViewer1.RefreshReport();
        }
    }
}
