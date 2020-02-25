using HRISCapsu.Properties;
using HRISCapsu.ReportViewer;
using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace HRISCapsu
{
    public partial class frmEmployeesRecord : Form
    {
        private string destination;
        private bool isAttachmentUpdated;
        private string source;
        private readonly BackgroundWorker worker = new BackgroundWorker();
        private bool isPictureUpdated = false;

        public frmEmployeesRecord()
        {
            InitializeComponent();
            worker.WorkerSupportsCancellation = true;
            worker.WorkerReportsProgress = true;
            worker.ProgressChanged += worker_ProgressChanged;
            worker.DoWork += Worker_DoWork;

            displayDepartments(cmbDepartment);
            frmLogin.SendMessage(txtEmployeeNo.Handle, 0x1501, 1, "Employee no.");
            frmLogin.SendMessage(txtFirstName.Handle, 0x1501, 1, "First name.");
            frmLogin.SendMessage(txtMiddleName.Handle, 0x1501, 1, "Middle name.");
            frmLogin.SendMessage(txtLastName.Handle, 0x1501, 1, "Last name.");
            frmLogin.SendMessage(txtAddress.Handle, 0x1501, 1, "Address.");
            frmLogin.SendMessage(txtPlaceofBirth.Handle, 0x1502, 1, "Place of birth.");
            frmLogin.SendMessage(txtContactNo.Handle, 0x1501, 1, "Contact no.");
            displayRecords(dtgRecords);
            clearItems(panelFileInformation);
        }

        private Image ConvertBinaryToImage(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
            {
                return Image.FromStream(ms);
            }
        }

        private byte[] ConvertImageToBinary(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }

        private void copyFile(string source, string des)
        {
            FileStream fsout = new FileStream(des, FileMode.Create);
            FileStream fsin = new FileStream(source, FileMode.Open);
            byte[] bt = new byte[1048756];

            int readByte;

            while ((readByte = fsin.Read(bt, 0, bt.Length)) > 0)
            {
                fsout.Write(bt, 0, readByte);
                worker.ReportProgress((int)(fsin.Position * 100 / fsin.Length));
            }

            fsin.Close();
            fsout.Close();


        }

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            lblPercent.Text = progressBar1.Value + "%";
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            copyFile(source, destination);
        }

        private void displayRecords(DataGridView gridView)
        {
            try
            {
                using (MySqlConnection conn =
                    new MySqlConnection(ConfigurationManager.ConnectionStrings["HRISConnection"].ConnectionString))
                {
                    conn.Open();
                    string query =
                        @"SELECT emp.employee_no, emp.first_name, emp.middle_name, emp.last_name, emp.address, emp.gender, date_format(emp.date_of_birth, '%M %d, %Y') AS 'Date of Birth', emp.place_of_birth, emp.contact_no, emp.civil_status, pos.position_name, dept.department_name, emp.work_status, date_format(emp.hired_date, '%M %d, %Y') AS 'Hired Date', date_format(emp.end_of_contract, '%M %d, %Y') AS 'End of Contract', emp.status, emp.documentpath, emp.employee_photo, emp.degree, emp.employee_type FROM employees emp INNER JOIN positions pos ON emp.position_id = pos.position_id INNER JOIN departments dept ON emp.department_id = dept.department_id WHERE emp.status = 'Active' ORDER BY emp.last_name ASC";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter da = new MySqlDataAdapter
                    {
                        SelectCommand = cmd
                    };
                    DataTable dt = new DataTable();
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
                    gridView.Columns[16].Visible = false;
                    gridView.Columns[17].Visible = false;
                    gridView.Columns[18].HeaderText = "Degree";
                    gridView.Columns[19].HeaderText = "Employee Type";
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("No data found.", "Not found",
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

        private void displayDepartments(ComboBox cmbDepartments)
        {
            try
            {
                using (MySqlConnection conn =
                    new MySqlConnection(ConfigurationManager.ConnectionStrings["HRISConnection"].ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM departments";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader dr = cmd.ExecuteReader();
                    cmbDepartments.Items.Clear();
                    while (dr.Read())
                    {
                        cmbDepartments.Items.Add(dr["department_id"] + " - " + dr["department_name"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void displayPositions(ComboBox cmbPositions, string positionType)
        {
            try
            {
                using (MySqlConnection conn =
                    new MySqlConnection(ConfigurationManager.ConnectionStrings["HRISConnection"].ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM positions WHERE position_type = @position_type ORDER BY position_name ASC";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("position_type", positionType);
                    MySqlDataReader dr = cmd.ExecuteReader();
                    cmbPositions.Items.Clear();
                    while (dr.Read())
                    {
                        cmbPositions.Items.Add(dr["position_id"] + " - " + dr["position_name"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void clearItems(Panel panel)
        {
            try
            {
                foreach (Control control in panel.Controls)
                {
                    if (control is TextBox)
                    {
                        control.ResetText();
                    }
                    else if (control is ComboBox)
                    {
                        ((ComboBox)control).SelectedIndex = 0;
                    }
                    else if (control is DateTimePicker)
                    {
                        ((DateTimePicker)control).ResetText();
                    }
                    else if (control is ProgressBar)
                    {
                        ((ProgressBar)control).Value = 0;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please add department and position first.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            grpPicture.Visible = false;
            dtgRecords.Enabled = true;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            clearItems(panelFileInformation);
            progressBar1.Value = 0;
            panelFileInformation.Enabled = true;
            btnNew.Enabled = false;
            btnSave.Enabled = true;
            btnSave.Text = "&Save";
            btnCancel.Enabled = true;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            btnView.Enabled = false;
            Image myImage = Resources.default1;
            pictureBox2.Image = myImage;
            grpPicture.Visible = true;
            grpPicture.Enabled = true;
            grpAttachment.Enabled = true;
            dtgRecords.Enabled = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtEmployeeNo.Text != "" && txtFirstName.Text != "" && txtMiddleName.Text != "" &&
                txtLastName.Text != "" && txtAddress.Text != "" && cmbGender.Text != "" && txtPlaceofBirth.Text != "" &&
                txtContactNo.Text != "" && cmbCivilStatus.Text != "" && cmbPosition.Text != "" &&
                cmbDepartment.Text != "" && cmbWorkStatus.Text != "" && cmbDegree.Text != "" && cmbEmployeeType.Text != "")
            {
                if (btnSave.Text == "&Save")
                {
                    if (destination != null)
                    {
                        try
                        {
                            using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["HRISConnection"]
                                .ConnectionString))
                            {
                                conn.Open();
                                string query =
                                    "INSERT INTO employees (employee_no, first_name, middle_name, last_name, address, gender, date_of_birth, place_of_birth, contact_no, civil_status, position_id, department_id, work_status, hired_date, end_of_contract, status, documentpath, employee_photo, degree, employee_type) VALUES (@employee_no, @first_name, @middle_name, @last_name, @address, @gender, @date_of_birth, @place_of_birth, @contact_no, @civil_status, @position_id, @department_id, @work_status, @hired_date, @end_of_contract, @status, @documentpath, @employee_photo, @degree, @employee_type);";
                                string input = cmbPosition.SelectedItem.ToString();
                                int index = input.IndexOf(" ");
                                if (index > 0)
                                {
                                    input = input.Substring(0, index);
                                }

                                string input1 = cmbDepartment.SelectedItem.ToString();
                                int index1 = input1.IndexOf(" ");
                                if (index1 > 0)
                                {
                                    input1 = input1.Substring(0, index1);
                                }

                                MySqlCommand cmd = new MySqlCommand(query, conn);
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
                                cmd.Parameters.AddWithValue("position_id", input);
                                cmd.Parameters.AddWithValue("department_id", input1);
                                cmd.Parameters.AddWithValue("work_status", cmbWorkStatus.SelectedItem.ToString());
                                cmd.Parameters.AddWithValue("hired_date", dtpHiredDate.Value.ToString("yyyy-MM-dd"));

                                // if work status is selected to contractual end contract field will set to null.
                                cmd.Parameters.AddWithValue("end_of_contract",
                                    cmbWorkStatus.SelectedItem.ToString() == "Contractual"
                                        ? dtpEndofContract.Value.ToString("yyyy-MM-dd")
                                        : null);
                                cmd.Parameters.AddWithValue("status", cmbStatus.SelectedItem.ToString());
                                cmd.Parameters.AddWithValue("documentpath", destination);
                                cmd.Parameters.AddWithValue("employee_photo", ConvertImageToBinary(pictureBox2.Image));
                                cmd.Parameters.AddWithValue("degree", cmbDegree.SelectedItem.ToString());
                                cmd.Parameters.AddWithValue("employee_type", cmbEmployeeType.SelectedItem.ToString());
                                cmd.ExecuteNonQuery();
                                worker.RunWorkerAsync();
                                cmd.Parameters.Clear();
                                MessageBox.Show("Employee Information Added!");
                                clearItems(panelFileInformation);
                                progressBar1.Value = 0;
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
                                grpPicture.Visible = false;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Failed to add employee information. " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please attach a file.", "Required",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (btnSave.Text == "&Update")
                {
                    try
                    {
                        using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["HRISConnection"]
                            .ConnectionString))
                        {
                            conn.Open();
                            string query =
                                @"UPDATE employees SET first_name = @first_name, middle_name = @middle_name, last_name = @last_name, address = @address, gender = @gender, date_of_birth = @date_of_birth, place_of_birth = @place_of_birth, contact_no = @contact_no, civil_status = @civil_status, position_id = @position_id, department_id = @department_id, work_status = @work_status, hired_date = @hired_date, end_of_contract = @end_of_contract, status = @status, degree = @degree, employee_type = @employee_type WHERE employee_no = @employee_no";
                            MySqlCommand cmd = new MySqlCommand(query, conn);
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
                            cmd.Parameters.AddWithValue("end_of_contract",
                                cmbWorkStatus.SelectedItem.ToString() == "Contractual"
                                    ? dtpEndofContract.Value.ToString("yyyy-MM-dd")
                                    : null);
                            cmd.Parameters.AddWithValue("status", cmbStatus.SelectedItem);
                            cmd.Parameters.AddWithValue("degree", cmbDegree.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("employee_type", cmbEmployeeType.SelectedItem.ToString());
                            //if (isAttachmentUpdated)
                            //{
                            //    cmd.Parameters.AddWithValue("documentpath", destination);
                            //}
                            //else
                            //{
                            //    using (MySqlConnection conn1 = new MySqlConnection(ConfigurationManager
                            //        .ConnectionStrings["HRISConnection"].ConnectionString))
                            //    {
                            //        conn1.Open();
                            //        string query1 = @"SELECT documentpath FROM employees where employee_no = @employee_no";
                            //        using (MySqlCommand cmd1 = new MySqlCommand(query1, conn1))
                            //        {
                            //            cmd1.Parameters.AddWithValue("employee_no", txtEmployeeNo.Text);
                            //            using (MySqlDataReader reader = cmd1.ExecuteReader())
                            //            {
                            //                while (reader.Read())
                            //                {
                            //                    destination = reader[0].ToString();
                            //                }
                            //            }
                            //        }
                            //    }

                            //    cmd.Parameters.AddWithValue("documentpath", destination);
                            //}

                            //if (isPictureUpdated)
                            //{
                            //    cmd.Parameters.AddWithValue("employee_photo", ConvertImageToBinary(pictureBox2.Image));
                            //}
                            //else
                            //{
                            //    byte[] pictureBytes = new byte[0];
                            //    using (MySqlConnection conn1 = new MySqlConnection(ConfigurationManager
                            //        .ConnectionStrings["HRISConnection"].ConnectionString))
                            //    {
                            //        conn1.Open();
                            //        string query1 = @"SELECT employee_photo FROM employees where employee_no = @employee_no";
                            //        using (MySqlCommand cmd1 = new MySqlCommand(query1, conn1))
                            //        {
                            //            cmd1.Parameters.AddWithValue("employee_no", txtEmployeeNo.Text);
                            //            using (MySqlDataReader reader = cmd1.ExecuteReader())
                            //            {
                            //                while (reader.Read())
                            //                {
                            //                    pictureBytes = (byte[])reader[0];
                            //                }
                            //            }
                            //        }
                            //    }
                            //    cmd.Parameters.AddWithValue("employee_photo", pictureBytes);
                            //}

                            cmd.Parameters.AddWithValue("employee_no", txtEmployeeNo.Text);
                            cmd.ExecuteNonQuery();
                            //worker.RunWorkerAsync();
                            cmd.Parameters.Clear();
                            MessageBox.Show("Employee Information Updated!", "Success", MessageBoxButtons.OK,
                                MessageBoxIcon.None);
                            clearItems(panelFileInformation);
                            progressBar1.Value = 0;
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
                            dtgRecords.Enabled = true;
                            grpPicture.Visible = false;
                            
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please input required fields.", "Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                DialogResult dialogResult =
                    MessageBox.Show(
                        $"Delete {selectedRow.Cells["last_name"].Value}, {selectedRow.Cells["first_name"].Value} {selectedRow.Cells["middle_name"].Value} ?",
                        "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    using (MySqlConnection conn =
                        new MySqlConnection(ConfigurationManager.ConnectionStrings["HRISConnection"].ConnectionString))
                    {
                        conn.Open();
                        string query = "DELETE FROM employees WHERE employee_no = @employee_no";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@employee_no", selectedRow.Cells["employee_no"].Value);
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        MessageBox.Show("Successfully deleted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.None);
                        displayRecords(dtgRecords);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            frmViewEmployee frm = new frmViewEmployee(dtgRecords.CurrentRow.Cells[0].Value.ToString(),
                dtgRecords.CurrentRow.Cells[1].Value.ToString(), dtgRecords.CurrentRow.Cells[2].Value.ToString(),
                dtgRecords.CurrentRow.Cells[3].Value.ToString(), dtgRecords.CurrentRow.Cells[4].Value.ToString(),
                dtgRecords.CurrentRow.Cells[5].Value.ToString(), dtgRecords.CurrentRow.Cells[6].Value.ToString(),
                dtgRecords.CurrentRow.Cells[7].Value.ToString(), dtgRecords.CurrentRow.Cells[8].Value.ToString(),
                dtgRecords.CurrentRow.Cells[9].Value.ToString(), dtgRecords.CurrentRow.Cells[10].Value.ToString(),
                dtgRecords.CurrentRow.Cells[11].Value.ToString(), dtgRecords.CurrentRow.Cells[12].Value.ToString(),
                dtgRecords.CurrentRow.Cells[13].Value.ToString(), dtgRecords.CurrentRow.Cells[14].Value.ToString(),
                dtgRecords.CurrentRow.Cells[15].Value.ToString(), dtgRecords.CurrentRow.Cells[16].Value.ToString(), (byte[])dtgRecords.CurrentRow.Cells[17].Value, dtgRecords.CurrentRow.Cells[18].Value.ToString(), dtgRecords.CurrentRow.Cells[19].Value.ToString());
            frm.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            panelFileInformation.Enabled = true;
            grpPicture.Visible = true;
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
            cmbDegree.SelectedItem = dtgRecords.CurrentRow.Cells[18].Value;
            cmbEmployeeType.SelectedItem = dtgRecords.CurrentRow.Cells[19].Value;
            pictureBox2.Image = ConvertBinaryToImage((byte[])dtgRecords.CurrentRow.Cells[17].Value);
            dtgRecords.Enabled = false;
            grpPicture.Enabled = false;
            grpAttachment.Enabled = false;
        }

        private void txtContactNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void dtgRecords_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmViewEmployee frm = new frmViewEmployee(dtgRecords.CurrentRow.Cells[0].Value.ToString(),
                dtgRecords.CurrentRow.Cells[1].Value.ToString(), dtgRecords.CurrentRow.Cells[2].Value.ToString(),
                dtgRecords.CurrentRow.Cells[3].Value.ToString(), dtgRecords.CurrentRow.Cells[4].Value.ToString(),
                dtgRecords.CurrentRow.Cells[5].Value.ToString(), dtgRecords.CurrentRow.Cells[6].Value.ToString(),
                dtgRecords.CurrentRow.Cells[7].Value.ToString(), dtgRecords.CurrentRow.Cells[8].Value.ToString(),
                dtgRecords.CurrentRow.Cells[9].Value.ToString(), dtgRecords.CurrentRow.Cells[10].Value.ToString(),
                dtgRecords.CurrentRow.Cells[11].Value.ToString(), dtgRecords.CurrentRow.Cells[12].Value.ToString(),
                dtgRecords.CurrentRow.Cells[13].Value.ToString(), dtgRecords.CurrentRow.Cells[14].Value.ToString(),
                dtgRecords.CurrentRow.Cells[15].Value.ToString(), dtgRecords.CurrentRow.Cells[16].Value.ToString(), (byte[])dtgRecords.CurrentRow.Cells[17].Value, dtgRecords.CurrentRow.Cells[18].Value.ToString(), dtgRecords.CurrentRow.Cells[19].Value.ToString());
            frm.ShowDialog();
        }

        private void frmEmployeesRecord_Load(object sender, EventArgs e)
        {
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmEmployeesReport frm = new frmEmployeesReport();
            frm.ShowDialog();
        }

        private void btnAttach_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                openFileDialog.Title = "Select a word document to be upload.";
                openFileDialog.Filter = "Select Valid Word File(*.doc; *.docx;)|*.doc;*.docx;";
                openFileDialog.FilterIndex = 1;
                openFileDialog.FileName = "";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    source = openFileDialog.FileName;
                    destination = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Files\" +
                                  openFileDialog.SafeFileName;
                    isAttachmentUpdated = true;
                }
            }
        }


        private void btnUpload_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openfiledialog = new OpenFileDialog())
            {
                openfiledialog.Filter = "JPEG|*.jpg|PNG|*.png";
                openfiledialog.Multiselect = false;
                openfiledialog.ValidateNames = true;
                if (openfiledialog.ShowDialog() == DialogResult.OK)
                {
                    lblFileName.Text = $"File: {openfiledialog.FileName}";
                    pictureBox2.Image = Image.FromFile(openfiledialog.FileName);
                    isPictureUpdated = true;
                }
            }
        }

        private void cmbEmployeeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEmployeeType.SelectedItem.ToString() == "Academic")
                displayPositions(cmbPosition, cmbEmployeeType.SelectedItem.ToString());
            else if (cmbEmployeeType.SelectedItem.ToString() == "Non - Academic")
                displayPositions(cmbPosition, cmbEmployeeType.SelectedItem.ToString());
        }
    }
}