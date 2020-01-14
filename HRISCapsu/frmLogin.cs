using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace HRISCapsu
{
    public partial class frmLogin : Form
    {
        public static string id;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn = new MySqlConnection(Classes.DBConnection.conString))
                {
                    conn.Open();
                    string query = "SELECT * FROM Users WHERE username = @username AND password = @password";
                    var cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("username", txtUsername.Text);
                    cmd.Parameters.AddWithValue("password", txtPassword.Text);
                    MySqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        id = dr[0].ToString();
                        MessageBox.Show("Login Successfully!");
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Credentials!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
