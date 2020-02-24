using System;
using System.Configuration;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace HRISCapsu
{
    public partial class frmLogin : Form
    {
        public static string id;

        public frmLogin()
        {
            InitializeComponent();
            SendMessage(txtUsername.Handle, 0x1501, 1, "Username.");
            SendMessage(txtPassword.Handle, 0x1501, 1, "Password.");
        }

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam,
            [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            HashAlgorithm sha1 = new SHA1CryptoServiceProvider();
            var password = Encoding.Default.GetBytes(txtPassword.Text);
            var txtHash = sha1.ComputeHash(password);
            var convertedPassword = BitConverter.ToString(txtHash).ToLower().Replace("-", "");
            try
            {
                using (var conn =
                    new MySqlConnection(ConfigurationManager.ConnectionStrings["HRISConnection"].ConnectionString))
                {
                    conn.Open();
                    var query = "SELECT * FROM Users WHERE username = @username AND password = @password";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("username", txtUsername.Text);
                        cmd.Parameters.AddWithValue("password", convertedPassword);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                    id = reader["userID"].ToString();
                                Close();
                            }
                            else
                            {
                                MessageBox.Show("Incorrect username/password!", "Invalid Credentials",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
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