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

namespace HRISCapsu
{
    public partial class MDIMain : Form
    {

        public MDIMain()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmLogin();
            frm.ShowDialog(this);
        }

        void testConnection()
        {
            using (var conn = new MySqlConnection(Classes.DBConnection.conString))
            {
                try
                {
                    conn.Open();
                    if (conn.State == ConnectionState.Open)
                    {
                        tsslConnection.Text = "Connection: Connected.";
                        tsslConnection.ForeColor = Color.Green;

                    }
                    else
                    {
                        tsslConnection.Text = "Connection: Disconnected.";
                        tsslConnection.ForeColor = Color.Red;
                    }
                }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                {
                    tsslConnection.Text = "Connection: Disconnected";
                    tsslConnection.ForeColor = Color.Red;
                }

            }
        }
        private void MDIMain_Load(object sender, EventArgs e)
        {
            testConnection();
            var frm = new frmLogin();
            frm.ShowDialog(this);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            this.tsslCurrentDateAndTime.Text = dateTime.ToString("MMMM dd, yyyy hh:mm:ss");
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmLogin();
            frm.ShowDialog();
        }


        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmChangePassword();
            frm.ShowDialog();
        }



        private void viewEmployeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmEmployeesRecord();
            frm.ShowDialog(this);
        }

        private void viewRegularEmployeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmListofEmployees();
            frm.ShowDialog();
        }

        private void viewContractualEmployeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmListofContractualEmployees();
            frm.ShowDialog();
        }

        private void viewPositionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmPositions();
            frm.ShowDialog(this);
        }

        private void viewDepartmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmDepartments();
            frm.ShowDialog();
        }

        private void viewSeminarsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmSeminarsTraining();
            frm.ShowDialog();
        }

        private void allEmployeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmViewEmployeesReport();
            frm.ShowDialog();
        }

        private void regularEmployeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmViewRegularEmployeesReport();
            frm.ShowDialog();
        }

        private void contractualEmployeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmViewContractualEmployeesReport();
            frm.ShowDialog();
        }
    }
}
