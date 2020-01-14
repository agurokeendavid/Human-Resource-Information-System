﻿using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace HRISCapsu
{
    public partial class frmEmployeesRecord : Form
    {
        public frmEmployeesRecord()
        {
            InitializeComponent();
            displayPositions(cmbPosition);
            displayDepartments(cmbDepartment);
            displayRecords(dtgRecords);
            clearItems(panelFileInformation);
        }

        private void displayRecords(DataGridView gridView)
        {
            try
            {
                using (var conn = new MySqlConnection(Classes.DBConnection.conString))
                {
                    conn.Open();
                    string query = @"SELECT emp.employee_no, emp.first_name, emp.middle_name, emp.last_name, emp.address, emp.gender, date_format(emp.date_of_birth, '%M %d, %Y') AS 'Date of Birth', emp.place_of_birth, emp.contact_no, emp.civil_status, pos.position_name, dept.department_name, emp.work_status, date_format(emp.hired_date, '%M %d, %Y') AS 'Hired Date', date_format(emp.end_of_contract, '%M %d, %Y') AS 'End of Contract', emp.status FROM employees emp INNER JOIN positions pos ON emp.position_id = pos.position_id INNER JOIN departments dept ON emp.department_id = dept.department_id WHERE emp.status = 'Active'";
                    var cmd = new MySqlCommand(query, conn);
                    var da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;
                    var dt = new DataTable();
                    da.Fill(dt);

                    gridView.DataSource = dt;

                    gridView.Columns[0].HeaderText = "Employee No.";
                    gridView.Columns[1].HeaderText = "First Name";
                    gridView.Columns[2].HeaderText = "Middle Name";
                    gridView.Columns[3].HeaderText = "Last Name";
                    gridView.Columns[4].HeaderText = "Address";
                    gridView.Columns[5].HeaderText = "Gender";
                    gridView.Columns[6].Visible = true;
                    gridView.Columns[7].Visible = false;
                    gridView.Columns[8].Visible = false;
                    gridView.Columns[9].Visible = false;
                    gridView.Columns[10].HeaderText = "Position";
                    gridView.Columns[11].HeaderText = "Department";
                    gridView.Columns[12].HeaderText = "Work Status";
                    gridView.Columns[13].Visible = false;
                    gridView.Columns[14].Visible = false;
                    gridView.Columns[15].Visible = false;

                    if (dt.Rows.Count == 0)
                        MessageBox.Show("No data found!");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void displayDepartments(ComboBox cmbDepartments)
        {
            try
            {
                using (var conn = new MySqlConnection(Classes.DBConnection.conString))
                {
                    conn.Open();
                    string query = "SELECT department_name FROM departments";
                    var cmd = new MySqlCommand(query, conn);
                    MySqlDataReader dr = cmd.ExecuteReader();
                    cmbDepartments.Items.Clear();
                    while (dr.Read())
                    {
                        cmbDepartments.Items.Add(dr["department_name"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void displayPositions(ComboBox cmbPositions)
        {
            try
            {
                using (var conn = new MySqlConnection(Classes.DBConnection.conString))
                {
                    conn.Open();
                    string query = "SELECT position_name FROM positions";
                    var cmd = new MySqlCommand(query, conn);
                    MySqlDataReader dr = cmd.ExecuteReader();
                    cmbPositions.Items.Clear();
                    while (dr.Read())
                    {
                        cmbPositions.Items.Add(dr["position_name"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void clearItems(Panel panel)
        {
            foreach (Control control in panel.Controls)
            {
                if (control is TextBox)
                    control.ResetText();
                else if (control is ComboBox)
                    ((ComboBox)control).SelectedIndex = 0;
                else if (control is DateTimePicker)
                    ((DateTimePicker)control).ResetText();
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            clearItems(panelFileInformation);
            txtEmployeeNo.ReadOnly = false;
            label14.Visible = false;
            dtpEndofContract.Visible = false;
            panelFileInformation.Enabled = false;
            btnCancel.Enabled = false;
            btnSave.Text = "&Save";
            btnSave.Enabled = false;
            btnNew.Enabled = true;
            btnDelete.Enabled = true;
            btnUpdate.Enabled = true;
            btnView.Enabled = true;


        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            clearItems(panelFileInformation);
            panelFileInformation.Enabled = true;
            btnNew.Enabled = false;
            btnSave.Enabled = true;
            btnSave.Text = "&Save";
            btnCancel.Enabled = true;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            btnView.Enabled = false;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtEmployeeNo.Text != "" && txtFirstName.Text != "" && txtMiddleName.Text != "" && txtLastName.Text != "" && txtAddress.Text != "" && cmbGender.Text != "" && txtPlaceofBirth.Text != "" && txtContactNo.Text != "" && cmbCivilStatus.Text != "" && cmbPosition.Text != "" && cmbDepartment.Text != "" && cmbWorkStatus.Text != "")
            {
                if (btnSave.Text == "&Save")
                {
                    try
                    {
                        using (var conn = new MySqlConnection(Classes.DBConnection.conString))
                        {
                            conn.Open();
                            string query = "INSERT INTO employees (employee_no, first_name, middle_name, last_name, address, gender, date_of_birth, place_of_birth, contact_no, civil_status, position_id, department_id, work_status, hired_date, end_of_contract, status) VALUES (@employee_no, @first_name, @middle_name, @last_name, @address, @gender, @date_of_birth, @place_of_birth, @contact_no, @civil_status, @position_id, @department_id, @work_status, @hired_date, @end_of_contract, @status)";
                            var cmd = new MySqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("employee_no", txtEmployeeNo.Text);
                            cmd.Parameters.AddWithValue("first_name", txtFirstName.Text);
                            cmd.Parameters.AddWithValue("middle_name", txtMiddleName.Text);
                            cmd.Parameters.AddWithValue("last_name", txtLastName.Text);
                            cmd.Parameters.AddWithValue("address", txtAddress.Text);
                            cmd.Parameters.AddWithValue("gender", cmbGender.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("date_of_birth", dtpDateofBirth.Value.ToString("yyyy-MM-dd"));
                            cmd.Parameters.AddWithValue("place_of_birth", txtPlaceofBirth.Text);
                            cmd.Parameters.AddWithValue("contact_no", txtContactNo.Text);
                            cmd.Parameters.AddWithValue("civil_status", cmbCivilStatus.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("position_id", cmbPosition.SelectedIndex + 1);
                            cmd.Parameters.AddWithValue("department_id", cmbDepartment.SelectedIndex + 1);
                            cmd.Parameters.AddWithValue("work_status", cmbWorkStatus.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("hired_date", dtpHiredDate.Value.ToString("yyyy-MM-dd"));

                            // if work status is selected to contractual end contract field will set to null.
                            cmd.Parameters.AddWithValue("end_of_contract", (cmbWorkStatus.SelectedItem.ToString() == "Contractual") ? dtpEndofContract.Value.ToString("yyyy-MM-dd") : null);
                            cmd.Parameters.AddWithValue("status", cmbStatus.SelectedItem.ToString());
                            cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                            MessageBox.Show("Employee Information Added!");
                            clearItems(panelFileInformation);
                            panelFileInformation.Enabled = false;
                            displayRecords(dtgRecords);

                            txtEmployeeNo.ReadOnly = false;
                            label14.Visible = false;
                            dtpEndofContract.Visible = false;
                            panelFileInformation.Enabled = false;
                            btnCancel.Enabled = false;
                            btnSave.Text = "&Save";
                            btnSave.Enabled = false;
                            btnNew.Enabled = true;
                            btnDelete.Enabled = true;
                            btnUpdate.Enabled = true;
                            btnView.Enabled = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to add employee information. " + ex.Message);
                    }
                }
                else if (btnSave.Text == "&Update")
                {
                    try
                    {
                        using (var conn = new MySqlConnection(Classes.DBConnection.conString))
                        {
                            conn.Open();
                            string query = @"UPDATE employees SET first_name = @first_name, middle_name = @middle_name, last_name = @last_name, address = @address, gender = @gender, date_of_birth = @date_of_birth, place_of_birth = @place_of_birth, contact_no = @contact_no, civil_status = @civil_status, position_id = @position_id, department_id = @department_id, work_status = @work_status, hired_date = @hired_date, end_of_contract = @end_of_contract, status = @status WHERE employee_no = @employee_no";
                            var cmd = new MySqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("first_name", txtFirstName.Text);
                            cmd.Parameters.AddWithValue("middle_name", txtMiddleName.Text);
                            cmd.Parameters.AddWithValue("last_name", txtLastName.Text);
                            cmd.Parameters.AddWithValue("address", txtAddress.Text);
                            cmd.Parameters.AddWithValue("gender", cmbGender.SelectedItem);
                            cmd.Parameters.AddWithValue("date_of_birth", dtpDateofBirth.Value.ToString("yyyy-MM-dd"));
                            cmd.Parameters.AddWithValue("place_of_birth", txtPlaceofBirth.Text);
                            cmd.Parameters.AddWithValue("contact_no", txtContactNo.Text);
                            cmd.Parameters.AddWithValue("civil_status", cmbCivilStatus.SelectedItem);
                            cmd.Parameters.AddWithValue("position_id", cmbPosition.SelectedIndex + 1);
                            cmd.Parameters.AddWithValue("department_id", cmbDepartment.SelectedIndex + 1);
                            cmd.Parameters.AddWithValue("work_status", cmbWorkStatus.SelectedItem);
                            cmd.Parameters.AddWithValue("hired_date", dtpHiredDate.Value.ToString("yyyy-MM-dd"));
                            cmd.Parameters.AddWithValue("end_of_contract", (cmbWorkStatus.SelectedItem.ToString() == "Contractual") ? dtpEndofContract.Value.ToString("yyyy-MM-dd") : null);
                            cmd.Parameters.AddWithValue("status", cmbStatus.SelectedItem);
                            cmd.Parameters.AddWithValue("employee_no", txtEmployeeNo.Text);
                            cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                            MessageBox.Show("Employee Information Updated!");
                            clearItems(panelFileInformation);
                            panelFileInformation.Enabled = false;
                            displayRecords(dtgRecords);
                            txtEmployeeNo.ReadOnly = false;
                            label14.Visible = false;
                            dtpEndofContract.Visible = false;
                            panelFileInformation.Enabled = false;
                            btnCancel.Enabled = false;
                            btnSave.Text = "&Save";
                            btnSave.Enabled = false;
                            btnNew.Enabled = true;
                            btnDelete.Enabled = true;
                            btnUpdate.Enabled = true;
                            btnView.Enabled = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please input required fields.");
            }

        }

        private void cmbWorkStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbWorkStatus.SelectedIndex)
            {
                case 0:
                    dtpEndofContract.ResetText();
                    label14.Visible = false;
                    dtpEndofContract.Visible = false;
                    break;
                case 1:
                    dtpEndofContract.ResetText();
                    label14.Visible = true;
                    dtpEndofContract.Visible = true;
                    break;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int selectedRowIndex = dtgRecords.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dtgRecords.Rows[selectedRowIndex];
            try
            {
                DialogResult dialogResult = MessageBox.Show($"Delete {selectedRow.Cells["last_name"].Value.ToString()}, {selectedRow.Cells["first_name"].Value.ToString()} {selectedRow.Cells["middle_name"].Value.ToString()} data ?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    using (var conn = new MySqlConnection(Classes.DBConnection.conString))
                    {
                        conn.Open();
                        string query = "DELETE FROM employees WHERE employee_no = @employee_no";
                        var cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@employee_no", selectedRow.Cells["employee_no"].Value);
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        MessageBox.Show("Successfully Deleted!");
                        displayRecords(dtgRecords);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            var frm = new frmViewEmployee(dtgRecords.CurrentRow.Cells[0].Value.ToString(), dtgRecords.CurrentRow.Cells[1].Value.ToString(), dtgRecords.CurrentRow.Cells[2].Value.ToString(), dtgRecords.CurrentRow.Cells[3].Value.ToString(), dtgRecords.CurrentRow.Cells[4].Value.ToString(), dtgRecords.CurrentRow.Cells[5].Value.ToString(), dtgRecords.CurrentRow.Cells[6].Value.ToString(), dtgRecords.CurrentRow.Cells[7].Value.ToString(), dtgRecords.CurrentRow.Cells[8].Value.ToString(), dtgRecords.CurrentRow.Cells[9].Value.ToString(), dtgRecords.CurrentRow.Cells[10].Value.ToString(), dtgRecords.CurrentRow.Cells[11].Value.ToString(), dtgRecords.CurrentRow.Cells[12].Value.ToString(), dtgRecords.CurrentRow.Cells[13].Value.ToString(), dtgRecords.CurrentRow.Cells[14].Value.ToString(), dtgRecords.CurrentRow.Cells[15].Value.ToString());
            frm.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            panelFileInformation.Enabled = true;
            btnNew.Enabled = false;
            btnSave.Text = "&Update";
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            btnView.Enabled = false;
            txtEmployeeNo.ReadOnly = true;
            txtEmployeeNo.Text = dtgRecords.CurrentRow.Cells[0].Value.ToString();
            txtFirstName.Text = dtgRecords.CurrentRow.Cells[1].Value.ToString();
            txtMiddleName.Text = dtgRecords.CurrentRow.Cells[2].Value.ToString();
            txtLastName.Text = dtgRecords.CurrentRow.Cells[3].Value.ToString();
            txtAddress.Text = dtgRecords.CurrentRow.Cells[4].Value.ToString();
            cmbGender.SelectedItem = dtgRecords.CurrentRow.Cells[5].Value;
            dtpDateofBirth.Text = dtgRecords.CurrentRow.Cells[6].Value.ToString();
            txtPlaceofBirth.Text = dtgRecords.CurrentRow.Cells[7].Value.ToString();
            txtContactNo.Text = dtgRecords.CurrentRow.Cells[8].Value.ToString();
            cmbCivilStatus.SelectedItem = dtgRecords.CurrentRow.Cells[9].Value;
            cmbPosition.SelectedItem = dtgRecords.CurrentRow.Cells[10].Value;
            cmbDepartment.SelectedItem = dtgRecords.CurrentRow.Cells[11].Value;
            cmbWorkStatus.SelectedItem = dtgRecords.CurrentRow.Cells[12].Value;
            dtpHiredDate.Text = dtgRecords.CurrentRow.Cells[13].Value.ToString();
            if (cmbWorkStatus.SelectedItem.ToString() == "Regular")
            {
                label14.Visible = false;
                dtpEndofContract.Visible = false;
            }
            else
            {
                label14.Visible = true;
                dtpEndofContract.Visible = true;
                dtpEndofContract.Text = dtgRecords.CurrentRow.Cells[14].Value.ToString();
            }
            cmbStatus.SelectedItem = dtgRecords.CurrentRow.Cells[15].Value;

        }
        private void txtContactNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void dtgRecords_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var frm = new frmViewEmployee(dtgRecords.CurrentRow.Cells[0].Value.ToString(), dtgRecords.CurrentRow.Cells[1].Value.ToString(), dtgRecords.CurrentRow.Cells[2].Value.ToString(), dtgRecords.CurrentRow.Cells[3].Value.ToString(), dtgRecords.CurrentRow.Cells[4].Value.ToString(), dtgRecords.CurrentRow.Cells[5].Value.ToString(), dtgRecords.CurrentRow.Cells[6].Value.ToString(), dtgRecords.CurrentRow.Cells[7].Value.ToString(), dtgRecords.CurrentRow.Cells[8].Value.ToString(), dtgRecords.CurrentRow.Cells[9].Value.ToString(), dtgRecords.CurrentRow.Cells[10].Value.ToString(), dtgRecords.CurrentRow.Cells[11].Value.ToString(), dtgRecords.CurrentRow.Cells[12].Value.ToString(), dtgRecords.CurrentRow.Cells[13].Value.ToString(), dtgRecords.CurrentRow.Cells[14].Value.ToString(), dtgRecords.CurrentRow.Cells[15].Value.ToString());
            frm.ShowDialog();
        }

        private void frmEmployeesRecord_Load(object sender, EventArgs e)
        {
            
        }
    }
}
