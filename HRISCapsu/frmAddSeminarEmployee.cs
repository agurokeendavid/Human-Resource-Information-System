﻿using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace HRISCapsu
{
    public partial class frmAddSeminarEmployee : Form
    {
        private readonly string seminar_id;

        public frmAddSeminarEmployee(string seminar_id)
        {
            InitializeComponent();
            displayPositions();
            cmbPosition.SelectedIndex = 0;
            displayRecords(cmbPosition.SelectedItem.ToString());
            this.seminar_id = seminar_id;
        }

        private void displayPositions()
        {
            try
            {
                using (var conn =
                    new MySqlConnection(ConfigurationManager.ConnectionStrings["HRISConnection"].ConnectionString))
                {
                    conn.Open();
                    var query = "SELECT position_name FROM positions";
                    var cmd = new MySqlCommand(query, conn);
                    var dr = cmd.ExecuteReader();
                    cmbPosition.Items.Clear();
                    cmbPosition.Items.Add("All");
                    while (dr.Read()) cmbPosition.Items.Add(dr["position_name"].ToString());
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No data found!", "Not found.",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void displayRecords(string keyword)
        {
            if (cmbPosition.SelectedItem.ToString() == "All")
                keyword = "";

            try
            {
                using (var conn =
                    new MySqlConnection(ConfigurationManager.ConnectionStrings["HRISConnection"].ConnectionString))
                {
                    conn.Open();
                    var query =
                        @"SELECT emp.employee_no, emp.first_name, emp.middle_name, emp.last_name, emp.address, emp.gender, date_format(emp.date_of_birth, '%M %d, %Y') AS 'Date of Birth', emp.place_of_birth, emp.contact_no, emp.civil_status, pos.position_name, emp.work_status, date_format(emp.hired_date, '%M %d, %Y') AS 'Hired Date', date_format(emp.end_of_contract, '%M %d, %Y') AS 'End of Contract', emp.position_item_no FROM employees emp INNER JOIN positions pos ON emp.position_item_no = pos.position_item_no WHERE emp.is_deleted = @is_deleted AND pos.position_name LIKE @keyword";
                    var cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("is_deleted", 0);
                    cmd.Parameters.AddWithValue("keyword", '%' + keyword + '%');
                    var da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;
                    var dt = new DataTable();
                    da.Fill(dt);

                    dtgRecords.DataSource = dt;

                    dtgRecords.Columns[0].HeaderText = "Employee No.";
                    dtgRecords.Columns[1].HeaderText = "First Name";
                    dtgRecords.Columns[2].HeaderText = "Middle Name";
                    dtgRecords.Columns[3].HeaderText = "Last Name";
                    dtgRecords.Columns[4].HeaderText = "Address";
                    dtgRecords.Columns[5].HeaderText = "Gender";
                    dtgRecords.Columns[6].Visible = true;
                    dtgRecords.Columns[7].Visible = false;
                    dtgRecords.Columns[8].Visible = false;
                    dtgRecords.Columns[9].Visible = false;
                    dtgRecords.Columns[10].HeaderText = "Position";
                    dtgRecords.Columns[11].HeaderText = "Work Status";
                    dtgRecords.Columns[12].Visible = false;
                    dtgRecords.Columns[13].Visible = false;
                    dtgRecords.Columns[14].Visible = false;

                    if (dt.Rows.Count == 0)
                        MessageBox.Show("No data found!", "Not found.",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmAddSeminarEmployee_Load(object sender, EventArgs e)
        {
        }

        private void cmbPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            displayRecords(cmbPosition.SelectedItem.ToString());
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            
        }

        private void dtgRecords_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                using (var conn =
                    new MySqlConnection(ConfigurationManager.ConnectionStrings["HRISConnection"].ConnectionString))
                {
                    conn.Open();
                    var query =
                        "INSERT INTO employee_seminars (seminar_id, employee_no) VALUES (@seminar_id, @employee_no)";
                    var cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("seminar_id", seminar_id);
                    cmd.Parameters.AddWithValue("employee_no", dtgRecords.CurrentRow.Cells[0].Value.ToString());
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    MessageBox.Show("Successfully added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.None);
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Employee exist! {ex.Message}", "Record exist.",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}