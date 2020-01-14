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

        private void MDIMain_Load(object sender, EventArgs e)
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
                catch (Exception ex)
                {
                    tsslConnection.Text = "Connection: Disconnected";
                    tsslConnection.ForeColor = Color.Red;
                }
                
            }
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

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmEmployeesRecord();
            frm.ShowDialog(this);
        }

        private void viewToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var frm = new frmPositions();
            frm.ShowDialog(this);
        }

        private void viewToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var frm = new frmDepartments();
            frm.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmChangePassword();
            frm.ShowDialog();
        }

        private void listOfEmployeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmListofEmployees();
            frm.ShowDialog();
        }

        private void listOfContractualEmployeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmListofContractualEmployees();
            frm.ShowDialog();
        }

        private void manageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmSeminarsTraining();
            frm.ShowDialog();
        }

        private void allEmployeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmEmployeesReport();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
