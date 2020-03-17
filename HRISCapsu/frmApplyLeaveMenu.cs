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
    public partial class frmApplyLeaveMenu : Form
    {
        public frmApplyLeaveMenu()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNonAcademic_Click(object sender, EventArgs e)
        {
            var frm = new frmApplyLeave();
            frm.ShowDialog();
        }

        private void btnAcademic_Click(object sender, EventArgs e)
        {
            var frm = new frmAcademicApplyLeave();
            frm.ShowDialog();
        }
    }
}
