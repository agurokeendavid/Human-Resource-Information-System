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
    public partial class frmSeminarNational : Form
    {
        public frmSeminarNational()
        {
            InitializeComponent();
        }

        public static string NationalSeminar;
        public static string NationalSeminarType;
        public static DateTime? NationalSeminarFrom;
        public static DateTime? NationalSeminarTo;

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtSeminarName.Text != string.Empty && cmbSeminarType.Text != string.Empty)
            {
                NationalSeminar = txtSeminarName.Text;
                NationalSeminarType = cmbSeminarType.Text;
                NationalSeminarFrom = dtpFrom.Value;
                NationalSeminarTo = dtpTo.Value;
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
