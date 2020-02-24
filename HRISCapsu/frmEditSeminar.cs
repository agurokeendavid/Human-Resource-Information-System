using System;
using System.Configuration;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace HRISCapsu
{
    public partial class frmEditSeminar : Form
    {
        private readonly string seminar_id;

        public frmEditSeminar(string seminar_id, string seminar_name, string seminar_location, string seminar_date,
            string seminar_status)
        {
            InitializeComponent();
            frmLogin.SendMessage(txtSeminarName.Handle, 0x1501, 1, "Seminar name.");
            frmLogin.SendMessage(txtLocation.Handle, 0x1501, 1, "Location.");
            this.seminar_id = seminar_id;
            txtSeminarName.Text = seminar_name;
            txtLocation.Text = seminar_location;
            dtpDateofActivity.Text = seminar_date;
            cmbStatus.SelectedItem = seminar_status;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtSeminarName.Text != string.Empty && txtLocation.Text != string.Empty &&
                cmbStatus.SelectedItem.ToString() != string.Empty)
                try
                {
                    using (var conn =
                        new MySqlConnection(ConfigurationManager.ConnectionStrings["HRISConnection"].ConnectionString))
                    {
                        conn.Open();
                        var query =
                            "UPDATE seminars SET seminar_name = @seminar_name, seminar_location = @seminar_location, seminar_date = @seminar_date, seminar_status = @seminar_status WHERE seminar_id = @seminar_id";
                        var cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("seminar_name", txtSeminarName.Text);
                        cmd.Parameters.AddWithValue("seminar_location", txtLocation.Text);
                        cmd.Parameters.AddWithValue("seminar_date", dtpDateofActivity.Value.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("seminar_status", cmbStatus.SelectedItem);
                        cmd.Parameters.AddWithValue("seminar_id", seminar_id);
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        MessageBox.Show("Information successfully updated!", "Success", MessageBoxButtons.OK,
                            MessageBoxIcon.None);
                        Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Seminar exist!", "Record exist.",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            else
                MessageBox.Show("Required fields.", "Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}