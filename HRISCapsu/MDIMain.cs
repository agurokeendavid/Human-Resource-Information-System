using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using HRISCapsu.ReportViewer;
using MySql.Data.MySqlClient;
using MySql.Data.Types;

namespace HRISCapsu
{
    public partial class MDIMain : Form
    {
        public MDIMain()
        {
            InitializeComponent();
            timer1.Start();
        }

        private List<string> allNearEndLeaveEmployeeList()
        {
            List<string> employeesList = new List<string>();
            try
            {
                using (var conn =
                    new MySqlConnection(ConfigurationManager.ConnectionStrings["HRISConnection"].ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT emp.employee_no, emp.first_name, emp.middle_name, emp.last_name, tbl_leave.from_date, tbl_leave.to_date FROM employees emp INNER JOIN tbl_leave ON emp.employee_no = tbl_leave.employee_no WHERE tbl_leave.is_deleted = @is_deleted;";
                    var cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("is_deleted", 0);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        DateTime endOfLeave;
                        double expiredLeave;

                        while (reader.Read())
                        {
                            endOfLeave = Convert.ToDateTime(reader[5]);
                            expiredLeave = (endOfLeave - DateTime.Now.Date).TotalDays;
                            if (expiredLeave >= 0 && expiredLeave <= 7)
                                employeesList.Add(reader[0] + " - " + reader[3] + ", " + reader[1] + " " + reader[2].ToString().Substring(0, 1) + ". " + "(" + expiredLeave + " day/days remaining)");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                employeesList.Clear();
            }

            return employeesList;
        }


        private int CountNearEndLeaveEmployees()
        {
            int count = 0;
            try
            {

                using (var conn =
                    new MySqlConnection(ConfigurationManager.ConnectionStrings["HRISConnection"].ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT from_date, to_date FROM tbl_leave WHERE is_deleted = @is_deleted;";
                    var cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("is_deleted", 0);
                    using (var reader = cmd.ExecuteReader())
                    {
                        DateTime endOfLeave;
                        double endLeave;

                        while (reader.Read())
                        {
                            endOfLeave = Convert.ToDateTime(reader[1]);
                            endLeave = (endOfLeave - DateTime.Now.Date).TotalDays;
                            if (endLeave >= 0 && endLeave <= 7)
                                count++;
                            else
                                count = 0;
                        }
                    }
                }
            }
            catch (Exception)
            {
                count = 0;
            }
            return count;
        }

        private List<string> allNearEndContractEmployeesList()
        {
            List<string> employeesList = new List<string>();
            try
            {
                using (var conn =
                    new MySqlConnection(ConfigurationManager.ConnectionStrings["HRISConnection"].ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT employee_no, first_name, middle_name, last_name, end_of_contract FROM employees WHERE work_status = @work_status AND status = @status;";
                    var cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("work_status", "Contractual");
                    cmd.Parameters.AddWithValue("status", "Active");
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        DateTime endOfContract;
                        double expiredContract;

                        while (reader.Read())
                        {
                            endOfContract = Convert.ToDateTime(reader[4]);
                            expiredContract = (endOfContract - DateTime.Now.Date).TotalDays;
                            if (expiredContract >= 1 && expiredContract <= 30)
                                employeesList.Add(reader[0] + " - " + reader[3] + ", " + reader[1] + " " + reader[2].ToString().Substring(0, 1) + ". " + "("+ expiredContract + " day/days remaining)");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                employeesList.Clear();
            }

            return employeesList;
        }

        private int CountNearEndContractualEmployees()
        {
            int count = 0;
            try
            {
                
                using (var conn =
                    new MySqlConnection(ConfigurationManager.ConnectionStrings["HRISConnection"].ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT end_of_contract FROM employees WHERE work_status = @work_status AND status = @status;";
                    var cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("work_status", "Contractual");
                    cmd.Parameters.AddWithValue("status", "Active");
                    using (var reader = cmd.ExecuteReader())
                    {
                        DateTime endOfContract;
                        double expiredContract;

                        while (reader.Read())
                        {
                            endOfContract = Convert.ToDateTime(reader[0]);
                            expiredContract = (endOfContract - DateTime.Now.Date).TotalDays;
                            if (expiredContract >= 1 && expiredContract <= 30)
                                count++;
                            else
                                count = 0;
                        }
                    }
                }
            }
            catch (Exception)
            {
                count = 0;
            }
            return count;
        }

        void RemoveExpiredLeave()
        {
            string query;
            try
            {
                using (var conn =
                    new MySqlConnection(ConfigurationManager.ConnectionStrings["HRISConnection"].ConnectionString))
                {
                    conn.Open();
                    query = "SELECT id, from_date, to_date FROM tbl_leave WHERE is_deleted = @is_deleted;";
                    var cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("is_deleted", 0);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    cmd.Parameters.Clear();
                    double countPresentDate;
                    while (reader.Read())
                    {
                        countPresentDate = ((Convert.ToDateTime(reader[2])) -  DateTime.Now.Date).TotalDays;
                        if (countPresentDate < 0)
                        {
                            using (var conn1 = new MySqlConnection(ConfigurationManager
                                .ConnectionStrings["HRISConnection"].ConnectionString))
                            {
                                conn1.Open();
                                query = "UPDATE tbl_leave SET is_deleted = @is_deleted WHERE id = @id";
                                cmd = new MySqlCommand(query, conn1);
                                cmd.Parameters.AddWithValue("is_deleted", 1);
                                cmd.Parameters.AddWithValue("id", reader[0]);
                                cmd.ExecuteNonQuery();
                                cmd.Parameters.Clear();
                            }
                                
                        }
                            
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private void MDIMain_Load(object sender, EventArgs e)
        {
            using (var conn =
                new MySqlConnection(ConfigurationManager.ConnectionStrings["HRISConnection"].ConnectionString))
            {
                try
                {
                    conn.Open();
                    if (conn.State == ConnectionState.Open)
                    {
                        tsslConnection.Text = "Connection: Connected.";
                        tsslConnection.ForeColor = Color.White;
                        RemoveExpiredLeave();
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
            notifications();
            
        }

        void notifications()
        {
            if (CountNearEndContractualEmployees() > 0 || CountNearEndLeaveEmployees() > 0)
            {
                notificationsToolStripMenuItem.ForeColor = Color.Red;
                notificationsToolStripMenuItem.Text = (CountNearEndContractualEmployees() + CountNearEndLeaveEmployees()) + " Notifications";
                notificationsToolStripMenuItem.Enabled = true;

                if (CountNearEndContractualEmployees() > 0)
                {
                    endOfContractToolStripMenuItem.ForeColor = Color.Red;
                    endOfContractToolStripMenuItem.Text = $"{CountNearEndContractualEmployees()} End of Contract";
                }

                if (CountNearEndLeaveEmployees() > 0)
                {
                    endOfLeaveToolStripMenuItem.ForeColor = Color.Red;
                    endOfLeaveToolStripMenuItem.Text = $"{CountNearEndLeaveEmployees()} End of Leave";
                }


                if (allNearEndContractEmployeesList().Count > 0)
                {
                    foreach (var employee in allNearEndContractEmployeesList())
                    {
                        endOfContractToolStripMenuItem.DropDownItems.Add(employee);
                    }
                }

                if (allNearEndLeaveEmployeeList().Count > 0)
                {
                    foreach (var employee in allNearEndLeaveEmployeeList())
                    {
                        endOfLeaveToolStripMenuItem.DropDownItems.Add(employee);
                    }
                }


            }
            else
            {
                notificationsToolStripMenuItem.Text = "0 Notification";
                notificationsToolStripMenuItem.Enabled = false;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            var dateTime = DateTime.Now;
            tsslCurrentDateAndTime.Text = dateTime.ToString("MMMM dd, yyyy hh:mm:ss");
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notificationsToolStripMenuItem.Enabled = false;
            notificationsToolStripMenuItem.Text = "Notification";
            var frm = new frmLogin();
            frm.ShowDialog();
            notifications();
        }


        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmChangePassword();
            frm.ShowDialog();
        }


        private void viewEmployeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
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
            var frm = new frmEmployeesReport();
            frm.ShowDialog();
        }

        private void regularEmployeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmRegularEmployeesReport();
            frm.ShowDialog();
        }

        private void contractualEmployeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmContractualEmployeesReport();
            frm.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmAbout();
            frm.ShowDialog();
        }

        private void endOfContractToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void endOfContractToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var frm = new frmListofContractualEmployees();
            frm.ShowDialog();
        }

        private void applyLeaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmApplyLeave();
            frm.ShowDialog();
            notifications();
        }

        private void listOfMasteralHolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new Graphs.frmMasteralGraph();
            frm.ShowDialog();
        }

        private void listOfDoctoralHolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new Graphs.frmDoctoralGraph();
            frm.ShowDialog();
        }

        private void allEmployeesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var frm = new frmEmployeesRecord();
            frm.ShowDialog(this);
            notifications();
        }
    }
}