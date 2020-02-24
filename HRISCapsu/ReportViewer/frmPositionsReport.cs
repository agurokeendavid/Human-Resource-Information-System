using System;
using System.Windows.Forms;

namespace HRISCapsu.ReportViewer
{
    public partial class frmPositionsReport : Form
    {
        public frmPositionsReport()
        {
            InitializeComponent();
        }

        private void frmPositionsReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hRISDataSource.positions' table. You can move, or remove it, as needed.
            positionsTableAdapter.Fill(hRISDataSource.positions);

            reportViewer1.RefreshReport();
        }
    }
}