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
using System.Text.RegularExpressions;
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
            if (ValidateChildren(ValidationConstraints.Enabled))
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

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            var regex = new Regex("^[a-zA-Z]+$");
            var regexNumber = new Regex(@"\d+");
            Match letterMatch = regex.Match(txtPassword.Text);
            Match numberMatch = regexNumber.Match(txtPassword.Text);

            string letters = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz";
            string numbers = "1234567890";
            if (string.IsNullOrWhiteSpace(txtPassword.Text) || CountLetters(txtPassword.Text) == 0 || CountDigits(txtPassword.Text) == 0)
            {
                e.Cancel = true;
                txtPassword.Focus();
                errorProvider1.SetError(txtPassword, "Password should contains numbers and letters!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtPassword, "");
            }
        }

        public static int CountLetters(string s)
        {
            int count = 0;
            foreach (char c in s)
            {
                if (Char.IsLetter(c))
                    count++;
            }
            return count;
        }

        public static int CountDigits(string s)
        {
            int count = 0;
            foreach (char c in s)
            {
                if (Char.IsDigit(c))
                    count++;
            }
            return count;
        }

        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                e.Cancel = true;
                txtUsername.Focus();
                errorProvider1.SetError(txtUsername, "Username should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtUsername, "");
            }
        }
    }
}
