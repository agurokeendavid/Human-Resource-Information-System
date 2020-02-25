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
    public partial class test1 : Form
    {
        public test1()
        {
            InitializeComponent();
        }

        private void test1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'HRISDataSource.view_academic_employees' table. You can move, or remove it, as needed.
            this.view_academic_employeesTableAdapter.Fill(this.HRISDataSource.view_academic_employees);

            this.reportViewer1.RefreshReport();
        }
    }
}
