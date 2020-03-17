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
    public partial class previewAllNonAcademicEmployees : Form
    {
        public previewAllNonAcademicEmployees()
        {
            InitializeComponent();
        }

        private void previewAllNonAcademicEmployees_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hRISDataSource.AllNonAcademicEmployees' table. You can move, or remove it, as needed.
            this.allNonAcademicEmployeesTableAdapter.Fill(this.hRISDataSource.AllNonAcademicEmployees);

            this.reportViewer1.RefreshReport();
        }
    }
}
