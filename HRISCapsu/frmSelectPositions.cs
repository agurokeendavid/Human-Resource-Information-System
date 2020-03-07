using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace HRISCapsu
{
    public partial class frmSelectPositions : Form
    {
        public static string item_no = null;
        public frmSelectPositions()
        {
            InitializeComponent();
        }

        void DisplayPositions()
        {
            try
            {
                using (var connection =
                    new MySqlConnection(ConfigurationManager.ConnectionStrings["HRISConnection"].ConnectionString))
                {
                    connection.Open();
                    string query = "SELECT position_id, position_name, position_item_no FROM positions WHERE position_name LIKE @position_name";
                    var cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("position_name", '%' + txtPositionName.Text + '%');
                    var da = new MySqlDataAdapter(cmd);
                    var dt = new DataTable();
                    da.Fill(dt);

                    dtgRecords.DataSource = dt;

                    dtgRecords.Columns[0].Visible = false;
                    dtgRecords.Columns[2].HeaderText = "Item No.";
                    dtgRecords.Columns[1].HeaderText = "Position";

                    if (dtgRecords.Rows.Count == 0)
                        MessageBox.Show("No data found.", "Not found",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPositionName_TextChanged(object sender, EventArgs e)
        {
            DisplayPositions();
        }

        private void frmSelectPositions_Load(object sender, EventArgs e)
        {
            DisplayPositions();
        }


        private void dtgRecords_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            item_no = dtgRecords.CurrentRow.Cells[2].Value.ToString();
            Close();
        }
    }
}
