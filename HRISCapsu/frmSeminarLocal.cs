using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static HRISCapsu.Repository.ListOfSeminarRepository;

namespace HRISCapsu
{
    public partial class frmSeminarLocal : Form
    {
        private string _employeeNo;
        public static string LocalSeminar;
        public static string LocalSeminarType;
        public static DateTime? LocalSeminarFrom;
        public static DateTime? LocalSeminarTo;
        public frmSeminarLocal(string employeeNo = null)
        {
            InitializeComponent();
            _employeeNo = employeeNo;
        }
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

        private void frmSeminarLocal_Load(object sender, EventArgs e)
        {
            try
            {
                var seminar = GetSingleSeminar(_employeeNo);
                if (_employeeNo != null && seminar.LocalFrom.HasValue && seminar.LocalTo.HasValue)
                {
                    txtSeminarName.Text = seminar.LocalSeminarName;
                    cmbSeminarType.Text = seminar.LocalSeminarType;
                    dtpFrom.Value = seminar.LocalFrom.Value;
                    dtpTo.Value = seminar.LocalTo.Value;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
