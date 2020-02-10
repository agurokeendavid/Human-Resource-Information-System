using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace HRISCapsu
{
    public partial class frmLogin : Form
    {
        public static string id;

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        public frmLogin()
        {
            InitializeComponent();
            SendMessage(txtUsername.Handle, 0x1501, 1, "Username.");
            SendMessage(txtPassword.Handle, 0x1501, 1, "Password.");
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
            HashAlgorithm sha1 = new SHA1CryptoServiceProvider();
            Byte[] password = UTF8Encoding.Default.GetBytes(txtPassword.Text);
            Byte[] txtHash = sha1.ComputeHash(password);
            string convertedPassword = BitConverter.ToString(txtHash).ToLower().Replace("-", "");
            try
            {
                using (var conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["HRISConnection"].ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM Users WHERE username = @username AND password = @password";
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
