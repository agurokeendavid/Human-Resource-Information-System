using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRISCapsu
{
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
            frmLogin.SendMessage(txtUsername.Handle, 0x1501, 1, "Username.");
            frmLogin.SendMessage(txtPassword.Handle, 0x1501, 1, "Password.");
        }

        private bool CheckUserExist()
        {
            try
            {
                using (var connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["HRISConnection"].ConnectionString))
                {
                    connection.Open();
                    string query = @"SELECT username FROM users WHERE username = @username";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("username", txtUsername.Text);
                        MySqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (!CheckUserExist())
            {
                HashAlgorithm sha1 = new SHA1CryptoServiceProvider();
                var password = Encoding.Default.GetBytes(txtPassword.Text);
                var txtHash = sha1.ComputeHash(password);
                var convertedPassword = BitConverter.ToString(txtHash).ToLower().Replace("-", "");
                try
                {
                    using (var connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["HRISConnection"].ConnectionString))
                    {
                        connection.Open();
                        string query = @"INSERT INTO users (username, password) VALUES (@username, @password)";
                        using (var command = new MySqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("username", txtUsername.Text);
                            command.Parameters.AddWithValue("password", convertedPassword);
                            command.ExecuteNonQuery();
                            MessageBox.Show("Successfully registered!", "Success", MessageBoxButtons.OK, MessageBoxIcon.None);
                            this.Close();
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Please try again later!", "Failed!",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Username already exist!", "Failed!",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
