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
using MySql.Data.MySqlClient;

namespace HRISCapsu
{
    public partial class frmApplyLeave : Form
    {
        public frmApplyLeave()
        {
            InitializeComponent();
            frmLogin.SendMessage(txtEmployeeNo.Handle, 0x1501, 1, "Employee no.");
            frmLogin.SendMessage(txtOthers.Handle, 0x1501, 1, "Please specify");
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

        private void btnSelect_Click(object sender, EventArgs e)
        {
            var frm = new frmListEmployeeLeave();
            frm.ShowDialog();
            txtEmployeeNo.Text = frmListEmployeeLeave.employeeNo;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbLeaveType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLeaveType.SelectedItem.ToString() == "Others")
            {
                label4.Visible = true;
                txtOthers.Visible = true;
            }
            else
            {
                label4.Visible = false;
                txtOthers.Visible = false;
            }
        }

        private void clearItems(Panel panel)
        {
            try
            {
                foreach (Control control in panel.Controls)
                {
                    if (control is TextBox)
                    {
                        control.ResetText();
                    }
                    else if (control is ComboBox)
                    {
                        ((ComboBox)control).SelectedIndex = 0;
                    }
                    else if (control is DateTimePicker)
                    {
                        ((DateTimePicker)control).ResetText();
                    }
                    else if (control is ProgressBar)
                    {
                        ((ProgressBar)control).Value = 0;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please add department and position first.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsEmployeeExist())
            {
                if (txtEmployeeNo.Text != "" && txtReason.Text != "")
                {
                    string leaveType;
                    if (cmbLeaveType.SelectedItem.ToString() == "Others")
                    {
                        if (txtOthers.Text != "")
                        {
                            leaveType = txtOthers.Text;
                        }
                        else
                        {
                            leaveType = "";
                        }
                    }
                    else
                    {
                        leaveType = cmbLeaveType.SelectedItem.ToString();
                    }

                    if (leaveType != "")
                    {
                        if (dtpLeaveFrom.Value < dtpLeaveTo.Value)
                        {
                            try
                            {
                                using (var conn =
                                    new MySqlConnection(ConfigurationManager.ConnectionStrings["HRISConnection"].ConnectionString))
                                {
                                    conn.Open();
                                    string query =
                                        "INSERT INTO tbl_leave (employee_no, type, from_date, to_date, reason) VALUES (@employee_no, @type, @from_date, @to_date, @reason);";
                                    var cmd = new MySqlCommand(query, conn);
                                    cmd.Parameters.AddWithValue("employee_no", txtEmployeeNo.Text);
                                    cmd.Parameters.AddWithValue("type", leaveType);
                                    cmd.Parameters.AddWithValue("from_date", dtpLeaveFrom.Value);
                                    cmd.Parameters.AddWithValue("to_date", dtpLeaveTo.Value);
                                    cmd.Parameters.AddWithValue("reason", txtReason.Text);
                                    cmd.ExecuteNonQuery();
                                    cmd.Parameters.Clear();
                                    MessageBox.Show("Application successfully added.!", "Success", MessageBoxButtons.OK,
                                        MessageBoxIcon.None);
                                    clearItems(panelEmployeeInformation);
                                }
                            }
                            catch (Exception exception)
                            {
                                MessageBox.Show("Error: " + exception.Message, "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please select valid leave date.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show("Please input leave type.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                }
                else
                {
                    MessageBox.Show("Please input required fields.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            else
            {
                MessageBox.Show("No employee found.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
