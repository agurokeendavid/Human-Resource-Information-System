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
    public partial class frmChooseModem : Form
    {
        public frmChooseModem()
        {
            InitializeComponent();
        }

        bool isModemExist()
        {
            try
            {
                using (var conn = new MySqlConnection(Classes.DBConnection.conString))
                {
                    conn.Open();
                    string query = "SELECT * FROM ports WHERE port_name LIKE @port_name";
                    var cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("port_name", '%' + "COM" + '%');
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                        return true;
                    else
                        return false;
                }
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                return false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (isModemExist() == true)
            {
                try
                {
                    using (var conn = new MySqlConnection(Classes.DBConnection.conString))
                    {
                        conn.Open();
                        string query = "UPDATE ports SET port_name = @port_name";
                        var cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("port_name", cmbChooseModem.SelectedItem.ToString());
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        MessageBox.Show("Successfully changed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.None);
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error changing modem port: " + ex.Message, "Error",
        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    using (var conn = new MySqlConnection(Classes.DBConnection.conString))
                    {
                        conn.Open();
                        string query = "INSERT INTO ports (port_name) VALUES (@port_name)";
                        var cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("port_name", cmbChooseModem.SelectedItem.ToString());
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        MessageBox.Show("Successfully changed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.None);
                        this.Close();
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
}
