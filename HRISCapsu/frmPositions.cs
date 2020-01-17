﻿using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace HRISCapsu
{
    public partial class frmPositions : Form
    {
        public frmPositions()
        {
            InitializeComponent();
            frmLogin.SendMessage(txtSearch.Handle, 0x1501, 1, "Search position.");
            frmLogin.SendMessage(txtPosition.Handle, 0x1501, 1, "Position name.");
            displayRecords(dtgRecords);
        }

        private void displayRecords(DataGridView gridView)
        {
            try
            {
                using (var conn = new MySqlConnection(Classes.DBConnection.conString))
                {
                    conn.Open();
                    string query = @"SELECT * FROM positions";
                    var cmd = new MySqlCommand(query, conn);
                    var da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;
                    var dt = new DataTable();
                    da.Fill(dt);

                    gridView.DataSource = dt;

                    if (dt.Rows.Count > 0)
                    {
                        gridView.Columns[0].HeaderText = "ID";
                        gridView.Columns[1].HeaderText = "Position";
                    }
                    else
                        MessageBox.Show("No data found!", "Not found",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            grpFilter.Enabled = false;
            grpAddPosition.Enabled = true;
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnPrint.Enabled = false;
            txtPosition.Clear();
            txtSearch.Clear();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            grpFilter.Enabled = true;
            grpAddPosition.Enabled = false;
            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnPrint.Enabled = true;
            txtSearch.Clear();
            txtPosition.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "Sav&e")
            {
                if (txtPosition.Text != string.Empty)
                {
                    try
                    {
                        using (var conn = new MySqlConnection(Classes.DBConnection.conString))
                        {
                            conn.Open();
                            string query = @"INSERT INTO positions (position_name) VALUES (@position_name)";
                            var cmd = new MySqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("position_name", txtPosition.Text);
                            cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                            MessageBox.Show("Successfully added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.None);
                            displayRecords(dtgRecords);

                            grpFilter.Enabled = true;
                            grpAddPosition.Enabled = false;
                            btnAdd.Enabled = true;
                            btnEdit.Enabled = true;
                            btnPrint.Enabled = true;
                            txtSearch.Clear();
                            txtPosition.Clear();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error inserting position: " + ex.Message, "Error",
        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Required fields.", "Required",
        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPosition.Focus();
                }
            }
            else
            {
                try
                {
                    using (var conn = new MySqlConnection(Classes.DBConnection.conString))
                    {
                        conn.Open();
                        string query = @"UPDATE positions SET position_name = @position_name WHERE position_id = @position_id";
                        var cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("position_name", txtPosition.Text);
                        cmd.Parameters.AddWithValue("position_id", dtgRecords.CurrentRow.Cells[0].Value.ToString());
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        MessageBox.Show("Successfully added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.None);
                        displayRecords(dtgRecords);
                        grpFilter.Enabled = true;
                        grpAddPosition.Enabled = false;
                        btnAdd.Enabled = true;
                        btnEdit.Enabled = true;
                        btnPrint.Enabled = true;
                        txtSearch.Clear();
                        txtPosition.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating position: " + ex.Message, "Error",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            grpFilter.Enabled = false;
            grpAddPosition.Enabled = true;
            btnSave.Text = "&Update";
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnPrint.Enabled = false;
            txtPosition.Text = dtgRecords.CurrentRow.Cells[1].Value.ToString();
            txtSearch.Clear();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn = new MySqlConnection(Classes.DBConnection.conString))
                {
                    conn.Open();
                    string query = @"SELECT * FROM positions WHERE position_name LIKE @position_name";
                    var cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("position_name", '%' + txtSearch.Text + '%');
                    var da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;
                    var dt = new DataTable();
                    da.Fill(dt);

                    dtgRecords.DataSource = dt;

                    if (dt.Rows.Count > 0)
                    {
                        dtgRecords.Columns[0].HeaderText = "ID";
                        dtgRecords.Columns[1].HeaderText = "Position";
                    }
                    else
                        MessageBox.Show("No data found!", "Not found",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            var frm = new ReportViewer.frmPositionsReport();
            frm.ShowDialog();
        }
    }
}