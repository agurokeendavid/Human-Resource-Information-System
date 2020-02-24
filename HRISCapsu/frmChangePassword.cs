using System;
using System.Configuration;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

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

        private bool isPasswordExist()
        {
            try
            {
                using (var conn =
                    new MySqlConnection(ConfigurationManager.ConnectionStrings["HRISConnection"].ConnectionString))
                {
                    HashAlgorithm sha1 = new SHA1CryptoServiceProvider();
                    var password = Encoding.Default.GetBytes(txtCurrentPassword.Text);
                    var txtHash = sha1.ComputeHash(password);
                    var convertedPassword = BitConverter.ToString(txtHash).ToLower().Replace("-", "");
                    conn.Open();
                    var query = "SELECT password FROM users WHERE password = @password";
                    var cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("password", convertedPassword);
                    var da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;
                    var dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                        return true;
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
            if (isPasswordExist())
            {
                if (txtNewPassword.Text == txtVerifyNewPassword.Text)
                    try
                    {
                        using (var conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["HRISConnection"]
                            .ConnectionString))
                        {
                            HashAlgorithm sha1 = new SHA1CryptoServiceProvider();
                            var password = Encoding.Default.GetBytes(txtNewPassword.Text);
                            var txtHash = sha1.ComputeHash(password);
                            var convertedPassword = BitConverter.ToString(txtHash).ToLower().Replace("-", "");
                            conn.Open();
                            var query = "UPDATE users SET password = @password WHERE userID = @userID";
                            var cmd = new MySqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("password", convertedPassword);
                            cmd.Parameters.AddWithValue("userID", frmLogin.id);
                            cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                            MessageBox.Show("Password successfully updated!");
                            Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                else
                    MessageBox.Show("New Password does not match.", "Incorrect",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
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