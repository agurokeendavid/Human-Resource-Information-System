using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using HRISCapsu.ReportViewer;
using MySql.Data.MySqlClient;

namespace HRISCapsu
{
    public partial class frmPositions : Form
    {
        public frmPositions()
        {
            InitializeComponent();
            frmLogin.SendMessage(txtSearch.Handle, 0x1501, 1, "Search position.");
            displayRecords(dtgRecords);
        }


        private void displayRecords(DataGridView gridView)
        {
            try
            {
                using (var conn =
                    new MySqlConnection(ConfigurationManager.ConnectionStrings["HRISConnection"].ConnectionString))
                {
                    conn.Open();
                    var query = @"SELECT position_id, position_item_no, position_name, position_sg, position_step, position_type FROM positions ORDER BY position_name ASC;";
                    var cmd = new MySqlCommand(query, conn);
                    var da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;
                    var dt = new DataTable();
                    da.Fill(dt);

                    gridView.DataSource = dt;

                    if (dt.Rows.Count > 0)
                    {
                        gridView.Columns[0].Visible = false;
                        gridView.Columns[1].HeaderText = "Position Item No.";
                        gridView.Columns[2].HeaderText = "Position";
                        gridView.Columns[3].HeaderText = "SG";
                        gridView.Columns[4].HeaderText = "Step";
                        gridView.Columns[5].HeaderText = "Position Type";
                    }
                    else
                    {
                        MessageBox.Show("No data found!", "Not found",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            var frm = new frmAddPosition("Add", null, null, null, null, null, null);
            frm.ShowDialog();
            displayRecords(dtgRecords);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {

            var frm = new frmAddPosition("Edit", dtgRecords.CurrentRow.Cells[0].Value.ToString(), dtgRecords.CurrentRow.Cells[2].Value.ToString(), dtgRecords.CurrentRow.Cells[5].Value.ToString(), dtgRecords.CurrentRow.Cells[3].Value.ToString(), dtgRecords.CurrentRow.Cells[4].Value.ToString(), dtgRecords.CurrentRow.Cells[1].Value.ToString());
            frm.ShowDialog();
            displayRecords(dtgRecords);

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn =
                    new MySqlConnection(ConfigurationManager.ConnectionStrings["HRISConnection"].ConnectionString))
                {
                    conn.Open();
                    var query = @"SELECT position_id, position_item_no, position_name, position_sg, position_step, position_type FROM positions WHERE position_name LIKE @position_name ORDER BY position_name ASC;";
                    var cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("position_name", '%' + txtSearch.Text + '%');
                    var da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;
                    var dt = new DataTable();
                    da.Fill(dt);

                    dtgRecords.DataSource = dt;

                    if (dt.Rows.Count > 0)
                    {
                        dtgRecords.Columns[0].Visible = false;
                        dtgRecords.Columns[1].HeaderText = "Position Item No.";
                        dtgRecords.Columns[2].HeaderText = "Position";
                        dtgRecords.Columns[3].HeaderText = "SG";
                        dtgRecords.Columns[4].HeaderText = "Step";
                        dtgRecords.Columns[5].HeaderText = "Position Type";
                    }
                    else
                    {
                        MessageBox.Show("No data found!", "Not found",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            var frm = new frmPositionsReport();
            frm.ShowDialog();
        }
    }
}