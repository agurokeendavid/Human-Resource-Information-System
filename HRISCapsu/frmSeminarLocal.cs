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
    public partial class frmSeminarLocal : Form
    {
        public frmSeminarLocal()
        {
            InitializeComponent();
        }

        public static string LocalSeminar;
        public static string LocalSeminarType;
        public static DateTime? LocalSeminarFrom;
        public static DateTime? LocalSeminarTo;

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtSeminarName.Text != string.Empty && cmbSeminarType.Text != string.Empty)
            {
                LocalSeminar = txtSeminarName.Text;
                LocalSeminarType = cmbSeminarType.Text;
                LocalSeminarFrom = dtpFrom.Value;
                LocalSeminarTo = dtpTo.Value;
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
