using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HRISCapsu.Repository.LeaveCreditRepository;

namespace HRISCapsu
{
    public partial class frmAcademicApplyLeave : Form
    {
        public frmAcademicApplyLeave()
        {
            InitializeComponent();
            frmLogin.SendMessage(txtEmployeeNo.Handle, 0x1501, 1, "Employee no.");
            frmLogin.SendMessage(lblLeaveCredits.Handle, 0x1501, 1, "0");
        }

        private void ApplyLeave()
        {
            int remainingLeave = Convert.ToInt32(lblLeaveCredits.Text) - Convert.ToInt32((dtpLeaveTo.Value - dtpLeaveFrom.Value).TotalDays);
            try
            {
                using (var conn =
                    new MySqlConnection(ConfigurationManager.ConnectionStrings["HRISConnection"].ConnectionString))
                {
                    conn.Open();
                    string query =
                        "INSERT INTO tbl_leave (employee_no, leave_credits, remaining_leave, from_date, to_date, reason) VALUES (@employee_no, @leave_credits, @remaining_leave, @from_date, @to_date, @reason);";
                    var cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("employee_no", txtEmployeeNo.Text);
                    cmd.Parameters.AddWithValue("leave_credits", lblLeaveCredits.Text);
                    cmd.Parameters.AddWithValue("remaining_leave", remainingLeave);
                    cmd.Parameters.AddWithValue("from_date", dtpLeaveFrom.Value);
                    cmd.Parameters.AddWithValue("to_date", dtpLeaveTo.Value);
                    cmd.Parameters.AddWithValue("reason", txtReason.Text);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    MessageBox.Show("Application successfully added.!", "Success", MessageBoxButtons.OK,
                        MessageBoxIcon.None);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error: " + exception.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsEmployeeExist()
        {
            try
            {
                using (var conn =
                    new MySqlConnection(ConfigurationManager.ConnectionStrings["HRISConnection"].ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT employee_no FROM employees WHERE employee_no = @employee_no;";
                    var cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("employee_no", txtEmployeeNo.Text);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                        return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }


        private void txtLeaveCredits_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            var frm = new frmListEmployeeLeave("Academic");
            frm.ShowDialog();
            txtEmployeeNo.Text = frmListEmployeeLeave.employeeNo;
            lblLeaveCredits.Text = frmListEmployeeLeave.leaveCredits;
            frmListEmployeeLeave.employeeNo = null;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtEmployeeNo.Text != string.Empty && lblLeaveCredits.Text != string.Empty)
            {
                if (IsEmployeeExist())
                {
                    if (dtpLeaveFrom.Value.Date >= DateTime.Now.Date)
                    {
                        if (dtpLeaveFrom.Value < dtpLeaveTo.Value)
                        {
                            int totalLeaveDays = Convert.ToInt32((dtpLeaveTo.Value - dtpLeaveFrom.Value).TotalDays);
                            if (totalLeaveDays <= Convert.ToInt32(lblLeaveCredits.Text))
                            {
                                ApplyLeave();
                                UpdateRemainingLeaveCredit(Convert.ToInt32((dtpLeaveTo.Value - dtpLeaveFrom.Value).TotalDays), txtEmployeeNo.Text);
                                lblLeaveCredits.Text = "0";
                                Classes.Methods.ClearItems(panelEmployeeInformation);
                            }
                            else
                            {
                                MessageBox.Show("Leave days must not exceed in leave credits", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please select a valid leave date.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please select a valid leave date.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                    
                }
                else
                {
                    MessageBox.Show("No employee found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please input required fields.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
