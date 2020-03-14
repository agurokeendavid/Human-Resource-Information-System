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
    public partial class previewSeminarEmployeeList : Form
    {
        public previewSeminarEmployeeList()
        {
            InitializeComponent();
        }

        private void previewSeminarEmployeeList_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hRISDataSource.EmployeeSeminarList' table. You can move, or remove it, as needed.
            this.employeeSeminarListTableAdapter.Fill(this.hRISDataSource.EmployeeSeminarList);

            this.reportViewer1.RefreshReport();
        }
    }
}
