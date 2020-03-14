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
    public partial class frmSeminarInternational : Form
    {
        public frmSeminarInternational()
        {
            InitializeComponent();
        }

        public static string InternationalSeminar;
        public static string InternationalSeminarType;
        public static DateTime? InternationalSeminarFrom;
        public static DateTime? InternationalSeminarTo;

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtSeminarName.Text != string.Empty && cmbSeminarType.Text != string.Empty)
            {
                InternationalSeminar = txtSeminarName.Text;
                InternationalSeminarType = cmbSeminarType.Text;
                InternationalSeminarFrom = dtpFrom.Value;
                InternationalSeminarTo = dtpTo.Value;
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
