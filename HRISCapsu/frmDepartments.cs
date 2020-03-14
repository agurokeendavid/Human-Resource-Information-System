
using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace HRISCapsu
{
    public partial class frmDepartments : Form
    {
        public frmDepartments()
        {
            InitializeComponent();
            displayRecords(dtgRecords);
            frmLogin.SendMessage(txtSearch.Handle, 0x1501, 1, "Search department.");
            frmLogin.SendMessage(txtDepartment.Handle, 0x1501, 1, "Department name.");
        }

        private void displayRecords(DataGridView gridView)
        {
            try
            {
                using (MySqlConnection conn =
                    new MySqlConnection(ConfigurationManager.ConnectionStrings["HRISConnection"].ConnectionString))
                {
                    conn.Open();
                    string query = @"SELECT * FROM departments ORDER BY department_name;";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter da = new MySqlDataAdapter
                    {
                        SelectCommand = cmd
                    };
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    gridView.DataSource = dt;

                    if (dt.Rows.Count > 0)
                    {
                        gridView.Columns[0].Visible = false;
                        gridView.Columns[1].HeaderText = "Department";
                    }
                    else
                    {
                        MessageBox.Show("No data found!", "Not found.",
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection conn =
                    new MySqlConnection(ConfigurationManager.ConnectionStrings["HRISConnection"].ConnectionString))
                {
                    conn.Open();
                    string query = @"SELECT * FROM departments WHERE department_name LIKE @department_name ORDER BY department_name ASC;";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("department_name", '%' + txtSearch.Text + '%');
                    MySqlDataAdapter da = new MySqlDataAdapter
                    {
                        SelectCommand = cmd
                    };
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dtgRecords.DataSource = dt;

                    if (dt.Rows.Count > 0)
                    {
                        dtgRecords.Columns[0].Visible = false;
                        dtgRecords.Columns[1].HeaderText = "Department";
                    }
                    else
                    {
                        MessageBox.Show("No data found!", "Not found.",
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            grpFilter.Enabled = true;
            grpAddDepartment.Enabled = false;
            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnPrint.Enabled = true;
            txtSearch.Clear();
            txtDepartment.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "Sav&e")
            {
                if (txtDepartment.Text != string.Empty)
                {
                    try
                    {
                        using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["HRISConnection"]
                            .ConnectionString))
                        {
                            conn.Open();
                            string query = @"INSERT INTO departments (department_name) VALUES (@department_name)";
                            MySqlCommand cmd = new MySqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("department_name", txtDepartment.Text);
                            cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                            MessageBox.Show("Department Added!");
                            displayRecords(dtgRecords);

                            grpFilter.Enabled = true;
                            grpAddDepartment.Enabled = false;
                            btnAdd.Enabled = true;
                            btnEdit.Enabled = true;
                            btnPrint.Enabled = true;
                            txtSearch.Clear();
                            txtDepartment.Clear();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error inserting department: " + ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Required fields", "Required",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDepartment.Focus();
                }
            }
            else
            {
                try
                {
                    using (MySqlConnection conn =
                        new MySqlConnection(ConfigurationManager.ConnectionStrings["HRISConnection"].ConnectionString))
                    {
                        conn.Open();
                        string query =
                            @"UPDATE departments SET department_name = @department_name WHERE department_id = @department_id";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("department_name", txtDepartment.Text);
                        cmd.Parameters.AddWithValue("department_id", dtgRecords.CurrentRow.Cells[0].Value.ToString());
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        MessageBox.Show("Department Updated!");
                        displayRecords(dtgRecords);
                        grpFilter.Enabled = true;
                        grpAddDepartment.Enabled = false;
                        btnAdd.Enabled = true;
                        btnEdit.Enabled = true;
                        btnPrint.Enabled = true;
                        txtSearch.Clear();
                        txtDepartment.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating department: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            grpFilter.Enabled = false;
            grpAddDepartment.Enabled = true;
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnPrint.Enabled = false;
            txtDepartment.Clear();
            txtSearch.Clear();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            grpFilter.Enabled = false;
            grpAddDepartment.Enabled = true;
            btnSave.Text = "&Update";
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnPrint.Enabled = false;
            txtDepartment.Text = dtgRecords.CurrentRow.Cells[1].Value.ToString();
            txtSearch.Clear();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //var frm = new frmDepartmentsReport();
            //frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}