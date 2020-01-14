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
    public partial class frmAddSeminar : Form
    {
        public frmAddSeminar()
        {
            InitializeComponent();
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
                        MessageBox.Show("Seminar added!");
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
                MessageBox.Show("Please input required fields.");
            }

        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
