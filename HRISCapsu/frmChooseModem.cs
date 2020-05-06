using System;
using System.Configuration;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace HRISCapsu
{
    public partial class frmChooseModem : Form
    {
        public frmChooseModem()
        {
            InitializeComponent();
        }

        private bool isModemExist()
        {
            try
            {
                using (var conn =
                    new MySqlConnection(ConfigurationManager.ConnectionStrings["HRISConnection"].ConnectionString))
                {
                    conn.Open();
                    var query = "SELECT * FROM ports WHERE port_name LIKE @port_name";
                    var cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("port_name", '%' + "COM" + '%');
                    var reader = cmd.ExecuteReader();
                    if (reader.HasRows)
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
            if (isModemExist())
                try
                {
                    using (var conn =
                        new MySqlConnection(ConfigurationManager.ConnectionStrings["HRISConnection"].ConnectionString))
                    {
                        conn.Open();
                        var query = "UPDATE ports SET port_name = @port_name";
                        var cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("port_name", cmbChooseModem.SelectedItem.ToString());
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        MessageBox.Show("Successfully changed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.None);
                        Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error changing modem port: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            else
                try
                {
                    using (var conn =
                        new MySqlConnection(ConfigurationManager.ConnectionStrings["HRISConnection"].ConnectionString))
                    {
                        conn.Open();
                        var query = "INSERT INTO ports (port_name) VALUES (@port_name)";
                        var cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("port_name", cmbChooseModem.SelectedItem.ToString());
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        MessageBox.Show("Successfully changed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.None);
                        Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error changing modem port: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }
    }
}