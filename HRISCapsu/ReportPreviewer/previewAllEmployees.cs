using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRISCapsu.ReportPreviewer
{
    public partial class previewAllEmployees : Form
    {
        public previewAllEmployees()
        {
            InitializeComponent();
        }

        private void previewAllEmployees_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hRISDataSource.AllEmployees' table. You can move, or remove it, as needed.
            this.allEmployeesTableAdapter.Fill(this.hRISDataSource.AllEmployees);

            this.reportViewer1.RefreshReport();
        }
    }
}
