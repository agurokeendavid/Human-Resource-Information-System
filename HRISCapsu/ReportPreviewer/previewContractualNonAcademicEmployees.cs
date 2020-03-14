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
    public partial class previewContractualNonAcademicEmployees : Form
    {
        public previewContractualNonAcademicEmployees()
        {
            InitializeComponent();
        }

        private void previewContractualNonAcademicEmployees_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hRISDataSource.ContractualNonAcademicEmployees' table. You can move, or remove it, as needed.
            this.contractualNonAcademicEmployeesTableAdapter.Fill(this.hRISDataSource.ContractualNonAcademicEmployees);

            this.reportViewer1.RefreshReport();
        }
    }
}
