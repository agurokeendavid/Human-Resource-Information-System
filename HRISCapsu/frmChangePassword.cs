using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
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
                    HashAlgorithm sha1 = new SHA1CryptoServiceProvider();
                    Byte[] password = UTF8Encoding.Default.GetBytes(txtCurrentPassword.Text);
                    Byte[] txtHash = sha1.ComputeHash(password);
                    string convertedPassword = BitConverter.ToString(txtHash).ToLower().Replace("-", "");
                    conn.Open();
                    string query = "SELECT password FROM users WHERE password = @password";
                    var cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("password", convertedPassword);
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
                            HashAlgorithm sha1 = new SHA1CryptoServiceProvider();
                            Byte[] password = UTF8Encoding.Default.GetBytes(txtNewPassword.Text);
                            Byte[] txtHash = sha1.ComputeHash(password);
                            string convertedPassword = BitConverter.ToString(txtHash).ToLower().Replace("-", "");
                            conn.Open();
                            string query = "UPDATE users SET password = @password WHERE userID = @userID";
                            var cmd = new MySqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("password", convertedPassword);
                            cmd.Parameters.AddWithValue("userID", frmLogin.id);
                            cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                            MessageBox.Show("Password successfully updated!");
                            this.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("New Password does not match.", "Incorrect",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Incorrect password!", "Incorrect",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
