using MySql.Data.MySqlClient;
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
    public partial class frmChangePassword : Form
    {
        public frmChangePassword()
        {
            InitializeComponent();
            frmLogin.SendMessage(txtCurrentPassword.Handle, 0x1501, 1, "Current password.");
            frmLogin.SendMessage(txtNewPassword.Handle, 0x1501, 1, "New password.");
            frmLogin.SendMessage(txtVerifyNewPassword.Handle, 0x1501, 1, "Verify new password.");
        }

        bool isPasswordExist()
        {
            try
            {
                using (var conn = new MySqlConnection(Classes.DBConnection.conString))
                {
                    conn.Open();
                    string query = "SELECT password FROM users WHERE password = @password";
                    var cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("password", txtCurrentPassword.Text);
                    var da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;
                    var dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (isPasswordExist() == true)
            {
                if (txtNewPassword.Text == txtVerifyNewPassword.Text)
                {
                    try
                    {
                        using (var conn = new MySqlConnection(Classes.DBConnection.conString))
                        {
                            conn.Open();
                            string query = "UPDATE users SET password = @password WHERE userID = @userID";
                            var cmd = new MySqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("password", txtNewPassword.Text);
                            cmd.Parameters.AddWithValue("userID", frmLogin.id);
                            cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                            MessageBox.Show("Password successfully updated!");
                            this.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("New password does not match!");
                }
            }
            else
                MessageBox.Show("Wrong password!");
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
