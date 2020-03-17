using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using HRISCapsu.ReportPreviewer;

namespace HRISCapsu
{
    public partial class MDIMain : Form
    {
        public MDIMain()
        {
            InitializeComponent();
            timer1.Start();
        }

        private int CountOldEmployees()
        {
            int count = 0;
            try
            {

                using (MySqlConnection conn =
                    new MySqlConnection(ConfigurationManager.ConnectionStrings["HRISConnection"].ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT hired_date FROM employees WHERE work_status = @work_status AND is_deleted = @is_deleted;";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("work_status", "Regular");
                    cmd.Parameters.AddWithValue("is_deleted", 0);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            DateTime hiredDate = Convert.ToDateTime(reader[0]);
                            double computeTodayAndHiredDay = (DateTime.Now.Date - hiredDate).TotalDays;
                            if (computeTodayAndHiredDay >= 3652)
                            {
                                count++;
                            }
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

        private List<string> ListOldEmployees()
        {
            List<string> employeesList = new List<string>();
            try
            {
                using (MySqlConnection conn =
                    new MySqlConnection(ConfigurationManager.ConnectionStrings["HRISConnection"].ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT employee_no, first_name, middle_name, last_name, hired_date FROM employees WHERE work_status = @work_status AND is_deleted = @is_deleted;";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("work_status", "Regular");
                    cmd.Parameters.AddWithValue("is_deleted", 0);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            DateTime hiredDate = Convert.ToDateTime(reader[4]);
                            double computeTodayAndHiredDay = (DateTime.Now.Date - hiredDate).TotalDays;
                            if (computeTodayAndHiredDay >= 3652)
                            {
                                employeesList.Add($"{reader["first_name"]} {reader["middle_name"].ToString().Substring(0, 1)} {reader["last_name"]}");
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                employeesList.Clear();
            }

            return employeesList;
        }

        private List<string> allNearEndLeaveEmployeeList()
        {
            List<string> employeesList = new List<string>();
            try
            {
                using (MySqlConnection conn =
                    new MySqlConnection(ConfigurationManager.ConnectionStrings["HRISConnection"].ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT emp.employee_no, emp.first_name, emp.middle_name, emp.last_name, tbl_leave.from_date, tbl_leave.to_date FROM employees emp INNER JOIN tbl_leave ON emp.employee_no = tbl_leave.employee_no WHERE tbl_leave.type IS NOT NULL && tbl_leave.is_deleted = @is_deleted;";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
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
                            {
                                employeesList.Add($"{reader["first_name"]} {reader["middle_name"].ToString().Substring(0, 1)} {reader["last_name"]} leave will end in {expiredLeave} day/days.");
                            }
                        }
                    }
                }
            }
            catch (Exception)
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

                using (MySqlConnection conn =
                    new MySqlConnection(ConfigurationManager.ConnectionStrings["HRISConnection"].ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT from_date, to_date FROM tbl_leave WHERE tbl_leave.type IS NOT NULL && is_deleted = @is_deleted;";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("is_deleted", 0);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        DateTime endOfLeave;
                        double endLeave;

                        while (reader.Read())
                        {
                            endOfLeave = Convert.ToDateTime(reader[1]);
                            endLeave = (endOfLeave - DateTime.Now.Date).TotalDays;
                            if (endLeave >= 0 && endLeave <= 7)
                            {
                                count++;
                            }
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
                using (MySqlConnection conn =
                    new MySqlConnection(ConfigurationManager.ConnectionStrings["HRISConnection"].ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT employee_no, first_name, middle_name, last_name, end_of_contract FROM employees WHERE work_status = @work_status AND is_deleted = @is_deleted;";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("work_status", "Contractual");
                    cmd.Parameters.AddWithValue("is_deleted", 0);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        DateTime endOfContract;
                        double expiredContract;

                        while (reader.Read())
                        {
                            endOfContract = Convert.ToDateTime(reader[4]);
                            expiredContract = (endOfContract - DateTime.Now.Date).TotalDays;
                            if (expiredContract >= 1 && expiredContract <= 30)
                            {
                                employeesList.Add($"{reader["first_name"]} {reader["middle_name"].ToString().Substring(0, 1)} {reader["last_name"]} contract will end in {expiredContract} day/days.");
                            }
                        }
                    }
                }
            }
            catch (Exception)
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

                using (MySqlConnection conn =
                    new MySqlConnection(ConfigurationManager.ConnectionStrings["HRISConnection"].ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT end_of_contract FROM employees WHERE work_status = @work_status AND is_deleted = @is_deleted;";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("work_status", "Contractual");
                    cmd.Parameters.AddWithValue("is_deleted", 0);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        DateTime endOfContract;
                        double expiredContract;

                        while (reader.Read())
                        {
                            endOfContract = Convert.ToDateTime(reader[0]);
                            expiredContract = (endOfContract - DateTime.Now.Date).TotalDays;
                            if (expiredContract >= 1 && expiredContract <= 30)
                            {
                                count++;
                            }
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

        private void RemoveExpiredLeave()
        {
            string query;
            try
            {
                using (MySqlConnection conn =
                    new MySqlConnection(ConfigurationManager.ConnectionStrings["HRISConnection"].ConnectionString))
                {
                    conn.Open();
                    query = "SELECT id, from_date, to_date FROM tbl_leave WHERE is_deleted = @is_deleted;";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("is_deleted", 0);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    cmd.Parameters.Clear();
                    double countPresentDate;
                    while (reader.Read())
                    {
                        countPresentDate = ((Convert.ToDateTime(reader["to_date"])) - DateTime.Now.Date).TotalDays;
                        if (countPresentDate < 0)
                        {
                            using (MySqlConnection conn1 = new MySqlConnection(ConfigurationManager
                                .ConnectionStrings["HRISConnection"].ConnectionString))
                            {
                                conn1.Open();
                                query = "UPDATE tbl_leave SET is_deleted = @is_deleted WHERE id = @id";
                                cmd = new MySqlCommand(query, conn1);
                                cmd.Parameters.AddWithValue("is_deleted", 1);
                                cmd.Parameters.AddWithValue("id", reader["id"]);
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
            using (MySqlConnection conn =
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
                catch (Exception)
                {
                    tsslConnection.Text = "Connection: Disconnected";
                    tsslConnection.ForeColor = Color.Red;
                }
            }
            frmLogin frm = new frmLogin();
            frm.ShowDialog(this);
            notifications();
        }

        private void notifications()
        {
            if (CountNearEndContractualEmployees() > 0 || CountNearEndLeaveEmployees() > 0 || CountOldEmployees() > 0)
            {
                notificationsToolStripMenuItem.Text = $"{CountNearEndContractualEmployees() + CountNearEndLeaveEmployees() + CountOldEmployees()} Notification";
                notificationsToolStripMenuItem.ForeColor = Color.Red;
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

                if (CountOldEmployees() > 0)
                {
                    oldEmployeesToolStripMenuItem.ForeColor = Color.Green;
                    oldEmployeesToolStripMenuItem.Text = $"{CountOldEmployees()} Old Employees";
                }


                if (allNearEndContractEmployeesList().Count > 0)
                {
                    foreach (string employee in allNearEndContractEmployeesList())
                    {
                        endOfContractToolStripMenuItem.DropDownItems.Add(employee);
                    }
                }

                if (allNearEndLeaveEmployeeList().Count > 0)
                {
                    foreach (string employee in allNearEndLeaveEmployeeList())
                    {
                        endOfLeaveToolStripMenuItem.DropDownItems.Add(employee);
                    }
                }

                if (ListOldEmployees().Count > 0)
                {
                    foreach (string employee in ListOldEmployees())
                    {
                        oldEmployeesToolStripMenuItem.DropDownItems.Add(employee);
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
            DateTime dateTime = DateTime.Now;
            tsslCurrentDateAndTime.Text = dateTime.ToString("MMMM dd, yyyy hh:mm:ss");
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogin frm = new frmLogin();
            frm.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword();
            frm.ShowDialog();
        }

        private void viewRegularEmployeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListofEmployees frm = new frmListofEmployees("Academic");
            frm.ShowDialog();
        }

        private void viewContractualEmployeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListofContractualEmployees frm = new frmListofContractualEmployees("Academic");
            frm.ShowDialog();
        }

        private void viewPositionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPositions frm = new frmPositions();
            frm.ShowDialog(this);
        }

        private void viewDepartmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDepartments frm = new frmDepartments();
            frm.ShowDialog();
        }

        private void viewSeminarsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSeminarsTraining frm = new frmSeminarsTraining();
            frm.ShowDialog();
        }

        private void allEmployeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new previewAllEmployees();
            frm.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout frm = new frmAbout();
            frm.ShowDialog();
        }

        private void applyLeaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmApplyLeaveMenu();
            frm.ShowDialog();
        }

        private void listOfMasteralHolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Graphs.frmMasteralGraph frm = new Graphs.frmMasteralGraph();
            frm.ShowDialog();
        }

        private void listOfDoctoralHolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Graphs.frmDoctoralGraph frm = new Graphs.frmDoctoralGraph();
            frm.ShowDialog();
        }

        private void allEmployeesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmEmployeesRecord frm = new frmEmployeesRecord();
            frm.ShowDialog(this);
        }

        private void regularEmployeesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmListofEmployees frm = new frmListofEmployees("Non - Academic");
            frm.ShowDialog();
        }

        private void contractualEmployeesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmListofContractualEmployees frm = new frmListofContractualEmployees("Non - Academic");
            frm.ShowDialog();
        }

        private void positionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPositions frm = new frmPositions();
            frm.ShowDialog();
        }

        private void seminarsAttendedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new previewSeminarEmployeeList();
            frm.ShowDialog();
        }

        private void addPositionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmAddPosition();
            frm.ShowDialog();
        }

        private void regularToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new previewAcademicRegularEmployees();
            frm.ShowDialog();
        }

        private void contractualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new previewContractualAcademicEmployees();
            frm.ShowDialog();
        }

        private void regularToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var frm = new previewNonAcademicRegularEmployees();
            frm.ShowDialog();
        }

        private void contractualToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var frm = new previewContractualNonAcademicEmployees();
            frm.ShowDialog();
        }
    }
}