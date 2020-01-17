using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace HRISCapsu
{
    public partial class frmAddSeminar : Form
    {
        public frmAddSeminar()
        {
            InitializeComponent();
            frmLogin.SendMessage(txtSeminarName.Handle, 0x1501, 1, "Seminar name.");
            frmLogin.SendMessage(txtLocation.Handle, 0x1501, 1, "Location.");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtSeminarName.Text != string.Empty && txtLocation.Text != string.Empty && cmbStatus.SelectedItem.ToString() != string.Empty)
            {
                try
                {
                    using (var conn = new MySqlConnection(Classes.DBConnection.conString))
                    {
                        conn.Open();
                        string query = "INSERT INTO seminars (seminar_name, seminar_location, seminar_date, seminar_status) VALUES (@seminar_name, @seminar_location, @seminar_date, @seminar_status)";
                        var cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("seminar_name", txtSeminarName.Text);
                        cmd.Parameters.AddWithValue("seminar_location", txtLocation.Text);
                        cmd.Parameters.AddWithValue("seminar_date", dtpDateofActivity.Value.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("seminar_status", cmbStatus.SelectedItem);
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        MessageBox.Show("Successfully added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.None);
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
                MessageBox.Show("Please input required fields.", "Required",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panelFileInformation_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}