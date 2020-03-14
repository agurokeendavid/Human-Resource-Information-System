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
    public partial class frmSeminarRegional : Form
    {
        public frmSeminarRegional()
        {
            InitializeComponent();
        }

        public static string RegionalSeminar;
        public static string RegionalSeminarType;
        public static DateTime? RegionalSeminarFrom;
        public static DateTime? RegionalSeminarTo;

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtSeminarName.Text != string.Empty && cmbSeminarType.Text != string.Empty)
            {
                RegionalSeminar = txtSeminarName.Text;
                RegionalSeminarType = cmbSeminarType.Text;
                RegionalSeminarFrom = dtpFrom.Value;
                RegionalSeminarTo = dtpTo.Value;
                MessageBox.Show("Seminar Successfully Added!", "Success", MessageBoxButtons.OK,
                    MessageBoxIcon.None);
                Close();
            }
            else
            {
                MessageBox.Show("Please fill all required fields.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
