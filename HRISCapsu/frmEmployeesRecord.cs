using HRISCapsu.Classes;
using HRISCapsu.Properties;
using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using HRISCapsu.ReportPreviewer;
using System.Collections.Generic;

namespace HRISCapsu
{
    public partial class frmEmployeesRecord : Form
    {
        private string destination = string.Empty;
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

            frmLogin.SendMessage(txtEmployeeNo.Handle, 0x1501, 1, "Employee no.");
            frmLogin.SendMessage(txtFirstName.Handle, 0x1501, 1, "First name.");
            frmLogin.SendMessage(txtMiddleName.Handle, 0x1501, 1, "Middle name.");
            frmLogin.SendMessage(txtLastName.Handle, 0x1501, 1, "Last name.");
            frmLogin.SendMessage(txtAddress.Handle, 0x1501, 1, "Address.");
            frmLogin.SendMessage(txtPlaceofBirth.Handle, 0x1502, 1, "Place of birth.");
            frmLogin.SendMessage(txtContactNo.Handle, 0x1501, 1, "Contact no.");
            frmLogin.SendMessage(txtEligibility.Handle, 0x1501, 1, "Eligibility");
            frmLogin.SendMessage(txtUniqueItemNo.Handle, 0x1501, 1, "Unique Item No.");
            frmLogin.SendMessage(txtSalaryGrade.Handle, 0x1501, 1, "Salary Grade");
            frmLogin.SendMessage(txtStep.Handle, 0x1501, 1, "Step");
            frmLogin.SendMessage(txtBSCourse.Handle, 0x1501, 1, "Course");
            frmLogin.SendMessage(txtBSYearGraduated.Handle, 0x1501, 1, "Year Graduated");
            frmLogin.SendMessage(txtBSSchool.Handle, 0x1501, 1, "School");
            frmLogin.SendMessage(txtMasteralCourse.Handle, 0x1501, 1, "Course");
            frmLogin.SendMessage(txtMasteralYearGraduated.Handle, 0x1501, 1, "Year Graduated");
            frmLogin.SendMessage(txtMasteralSchool.Handle, 0x1501, 1, "School");
            frmLogin.SendMessage(txtDoctoralCourse.Handle, 0x1501, 1, "Course");
            frmLogin.SendMessage(txtDoctoralYearGraduated.Handle, 0x1501, 1, "Year Graduated");
            frmLogin.SendMessage(txtDoctoralSchool.Handle, 0x1501, 1, "School");
            DisplayRecords(string.Empty);
            Methods.ClearItems(panelFileInformation);
        }

        #region Methods
        private void InsertRecord()
        {
            using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["HRISConnection"]
                    .ConnectionString))
            {
                connection.Open();
                string query =
                    @"INSERT INTO employees (employee_no, first_name, middle_name, last_name, address, gender, date_of_birth, place_of_birth, contact_no, civil_status, highest_degree, bs_course, bs_year_graduated, bs_school, masteral_course, masteral_year_graduated, masteral_school, doctoral_course, doctoral_year_graduated, doctoral_school, eligibility, employee_type, position, unique_item_no, salary_grade, step, department, work_status, employee_photo, documentpath, hired_date, end_of_contract) VALUES (@employee_no, @first_name, @middle_name, @last_name, @address, @gender, @date_of_birth, @place_of_birth, @contact_no, @civil_status, @highest_degree, @bs_course, @bs_year_graduated, @bs_school, @masteral_course, @masteral_year_graduated, @masteral_school, @doctoral_course, @doctoral_year_graduated, @doctoral_school, @eligibility, @employee_type, @position, @unique_item_no, @salary_grade, @step, @department, @work_status, @employee_photo, @documentpath, @hired_date, @end_of_contract);";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("employee_no", txtEmployeeNo.Text);
                    command.Parameters.AddWithValue("first_name", txtFirstName.Text);
                    command.Parameters.AddWithValue("middle_name", txtMiddleName.Text);
                    command.Parameters.AddWithValue("last_name", txtLastName.Text);
                    command.Parameters.AddWithValue("address", txtAddress.Text);
                    command.Parameters.AddWithValue("gender", cmbGender.SelectedItem.ToString());
                    command.Parameters.AddWithValue("date_of_birth", dtpDateofBirth.Value.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("place_of_birth", txtPlaceofBirth.Text);
                    command.Parameters.AddWithValue("contact_no", txtContactNo.Text);
                    command.Parameters.AddWithValue("civil_status", cmbCivilStatus.SelectedItem.ToString());
                    command.Parameters.AddWithValue("highest_degree", cmbDegree.SelectedItem.ToString());
                    command.Parameters.AddWithValue("bs_course", txtBSCourse.Text);
                    command.Parameters.AddWithValue("bs_year_graduated", txtBSYearGraduated.Text);
                    command.Parameters.AddWithValue("bs_school", txtBSSchool.Text);
                    command.Parameters.AddWithValue("masteral_course", txtMasteralCourse.Text);
                    command.Parameters.AddWithValue("masteral_year_graduated", txtMasteralYearGraduated.Text);
                    command.Parameters.AddWithValue("masteral_school", txtMasteralSchool.Text);
                    command.Parameters.AddWithValue("doctoral_course", txtDoctoralCourse.Text);
                    command.Parameters.AddWithValue("doctoral_year_graduated", txtDoctoralYearGraduated.Text);
                    command.Parameters.AddWithValue("doctoral_school", txtDoctoralSchool.Text);
                    command.Parameters.AddWithValue("eligibility", txtEligibility.Text);
                    command.Parameters.AddWithValue("employee_type", cmbEmployeeType.SelectedItem.ToString());
                    command.Parameters.AddWithValue("position", cmbPosition.SelectedItem.ToString());
                    command.Parameters.AddWithValue("unique_item_no", txtUniqueItemNo.Text);
                    command.Parameters.AddWithValue("salary_grade", txtSalaryGrade.Text);
                    command.Parameters.AddWithValue("step", txtStep.Text);
                    command.Parameters.AddWithValue("department", cmbDepartment.SelectedItem.ToString());
                    command.Parameters.AddWithValue("work_status", cmbWorkStatus.SelectedItem.ToString());
                    command.Parameters.AddWithValue("employee_photo", ConvertImageToBinary(pictureBox2.Image));
                    command.Parameters.AddWithValue("documentpath", destination);
                    command.Parameters.AddWithValue("hired_date", dtpHiredDate.Value.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("end_of_contract",
                        cmbWorkStatus.SelectedItem.ToString() == "Contractual"
                            ? dtpEndofContract.Value.ToString("yyyy-MM-dd")
                            : null);
                    command.ExecuteNonQuery();
                    worker.RunWorkerAsync();
                    InsertSeminar();
                    MessageBox.Show("Employee Information Added!");
                    ClearStaticVariables();
                }
            }

        }

        void ClearStaticVariables()
        {
            frmSeminarLocal.LocalSeminar = string.Empty;
            frmSeminarLocal.LocalSeminarType = string.Empty;
            frmSeminarLocal.LocalSeminarFrom = null;
            frmSeminarLocal.LocalSeminarTo = null;
            frmSeminarRegional.RegionalSeminar = string.Empty;
            frmSeminarRegional.RegionalSeminarType = string.Empty;
            frmSeminarRegional.RegionalSeminarFrom = null;
            frmSeminarRegional.RegionalSeminarTo = null;
            frmSeminarNational.NationalSeminar = string.Empty;
            frmSeminarNational.NationalSeminarType = string.Empty;
            frmSeminarNational.NationalSeminarFrom = null;
            frmSeminarNational.NationalSeminarTo = null;
            frmSeminarInternational.InternationalSeminar = string.Empty;
            frmSeminarInternational.InternationalSeminarType = string.Empty;
            frmSeminarInternational.InternationalSeminarFrom = null;
            frmSeminarInternational.InternationalSeminarTo = null;
        }
        private void InsertSeminar()
        {
            using (var connection =
                new MySqlConnection(ConfigurationManager.ConnectionStrings["HRISConnection"].ConnectionString))
            {
                connection.Open();
                string query =
                    "INSERT INTO tbl_list_of_seminars (employee_no, local_seminar_name, local_seminar_type, local_from, local_to, regional_seminar_name, regional_seminar_type, regional_from, regional_to, national_seminar_name, national_seminar_type, national_from, national_to, international_seminar_name, international_seminar_type, international_from, international_to) VALUES (@employee_no, @local_seminar_name, @local_seminar_type, @local_from, @local_to, @regional_seminar_name, @regional_seminar_type, @regional_from, @regional_to, @national_seminar_name, @national_seminar_type, @national_from, @national_to, @international_seminar_name, @international_seminar_type, @international_from, @international_to);";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("employee_no", MySqlDbType.VarChar).Value = txtEmployeeNo.Text;
                    cmd.Parameters.AddWithValue("local_seminar_name", frmSeminarLocal.LocalSeminar);
                    cmd.Parameters.AddWithValue("local_seminar_type", frmSeminarLocal.LocalSeminarType);
                    cmd.Parameters.AddWithValue("local_from", frmSeminarLocal.LocalSeminarFrom);
                    cmd.Parameters.AddWithValue("local_to", frmSeminarLocal.LocalSeminarTo);
                    cmd.Parameters.AddWithValue("regional_seminar_name", frmSeminarRegional.RegionalSeminar);
                    cmd.Parameters.AddWithValue("regional_seminar_type", frmSeminarRegional.RegionalSeminarType);
                    cmd.Parameters.AddWithValue("regional_from", frmSeminarRegional.RegionalSeminarFrom);
                    cmd.Parameters.AddWithValue("regional_to", frmSeminarRegional.RegionalSeminarTo);
                    cmd.Parameters.AddWithValue("national_seminar_name", frmSeminarNational.NationalSeminar);
                    cmd.Parameters.AddWithValue("national_seminar_type", frmSeminarNational.NationalSeminarType);
                    cmd.Parameters.AddWithValue("national_from", frmSeminarNational.NationalSeminarFrom);
                    cmd.Parameters.AddWithValue("national_to", frmSeminarNational.NationalSeminarTo);
                    cmd.Parameters.AddWithValue("international_seminar_name", frmSeminarInternational.InternationalSeminar);
                    cmd.Parameters.AddWithValue("international_seminar_type", frmSeminarInternational.InternationalSeminarType);
                    cmd.Parameters.AddWithValue("international_from", frmSeminarInternational.InternationalSeminarFrom);
                    cmd.Parameters.AddWithValue("international_to", frmSeminarInternational.InternationalSeminarTo);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void UpdateRecord()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["HRISConnection"]
                    .ConnectionString))
                {
                    connection.Open();
                    string query =
                        @"UPDATE employees SET first_name = @first_name, middle_name = @middle_name, last_name = @last_name, address = @address, gender = @gender,
date_of_birth = @date_of_birth, place_of_birth = @place_of_birth, contact_no = @contact_no, civil_status = @civil_status, highest_degree = @highest_degree, bs_course = @bs_course, bs_year_graduated = @bs_year_graduated, bs_school = @bs_school, masteral_course = @masteral_course, masteral_year_graduated = @masteral_year_graduated, masteral_school = @masteral_school, doctoral_course = @doctoral_course, doctoral_year_graduated = @doctoral_year_graduated, doctoral_school = @doctoral_school, eligibility = @eligibility, employee_type = @employee_type, position = @position, unique_item_no = @unique_item_no, salary_grade = @salary_grade, step = @step, department = @department, work_status = @work_status, hired_date = @hired_date, end_of_contract = @end_of_contract WHERE employee_no = @employee_no";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("first_name", txtFirstName.Text);
                        command.Parameters.AddWithValue("middle_name", txtMiddleName.Text);
                        command.Parameters.AddWithValue("last_name", txtLastName.Text);
                        command.Parameters.AddWithValue("address", txtAddress.Text);
                        command.Parameters.AddWithValue("gender", cmbGender.SelectedItem);
                        command.Parameters.AddWithValue("date_of_birth", dtpDateofBirth.Value.ToString("yyyy-MM-dd"));
                        command.Parameters.AddWithValue("place_of_birth", txtPlaceofBirth.Text);
                        command.Parameters.AddWithValue("contact_no", txtContactNo.Text);
                        command.Parameters.AddWithValue("civil_status", cmbCivilStatus.SelectedItem);
                        command.Parameters.AddWithValue("highest_degree", cmbDegree.SelectedItem);
                        command.Parameters.AddWithValue("bs_course", txtBSCourse.Text);
                        command.Parameters.AddWithValue("bs_year_graduated", txtBSYearGraduated.Text);
                        command.Parameters.AddWithValue("bs_school", txtBSSchool.Text);
                        command.Parameters.AddWithValue("masteral_course", txtMasteralCourse.Text);
                        command.Parameters.AddWithValue("masteral_year_graduated", txtMasteralYearGraduated.Text);
                        command.Parameters.AddWithValue("masteral_school", txtMasteralSchool.Text);
                        command.Parameters.AddWithValue("doctoral_course", txtDoctoralCourse.Text);
                        command.Parameters.AddWithValue("doctoral_year_graduated", txtDoctoralYearGraduated.Text);
                        command.Parameters.AddWithValue("doctoral_school", txtDoctoralSchool.Text);
                        command.Parameters.AddWithValue("eligibility", txtEligibility.Text);
                        command.Parameters.AddWithValue("employee_type", cmbEmployeeType.SelectedItem.ToString());
                        command.Parameters.AddWithValue("position", cmbPosition.SelectedItem.ToString());
                        command.Parameters.AddWithValue("unique_item_no", txtUniqueItemNo.Text);
                        command.Parameters.AddWithValue("salary_grade", txtSalaryGrade.Text);
                        command.Parameters.AddWithValue("step", txtStep.Text);
                        command.Parameters.AddWithValue("department", cmbDepartment.SelectedItem);
                        command.Parameters.AddWithValue("work_status", cmbWorkStatus.SelectedItem);
                        command.Parameters.AddWithValue("hired_date", dtpHiredDate.Value.ToString("yyyy-MM-dd"));
                        command.Parameters.AddWithValue("end_of_contract",
                            cmbWorkStatus.SelectedItem.ToString() == "Contractual"
                                ? dtpEndofContract.Value.ToString("yyyy-MM-dd")
                                : null);
                        command.Parameters.AddWithValue("employee_no", txtEmployeeNo.Text);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Employee Information Updated!", "Success", MessageBoxButtons.OK,
                        MessageBoxIcon.None);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayRecords(string keyword)
        {
            try
            {
                using (MySqlConnection connection =
                    new MySqlConnection(ConfigurationManager.ConnectionStrings["HRISConnection"].ConnectionString))
                {
                    connection.Open();
                    string query =
                        "SELECT emp.employee_no, emp.first_name, emp.middle_name, emp.last_name, emp.address, emp.gender, date_format(emp.date_of_birth, '%M %d, %Y') AS DateOfBirth, emp.place_of_birth, emp.contact_no, emp.civil_status, emp.highest_degree, emp.bs_course, emp.bs_year_graduated, emp.bs_school, emp.masteral_course, emp.masteral_year_graduated, emp.masteral_school, emp.doctoral_course, emp.doctoral_year_graduated, emp.doctoral_school, emp.eligibility, employee_type, position, unique_item_no, salary_grade, step, department, work_status, employee_photo, documentpath, hired_date, end_of_contract, sem.local_seminar_name, sem.local_seminar_type, date_format(sem.local_from, '%M %d, %Y'), date_format(sem.local_to, '%M %d, %Y'), sem.regional_seminar_name, sem.regional_seminar_type, date_format(sem.regional_from, '%M %d, %Y'), date_format(sem.regional_to, '%M %d, %Y'), sem.national_seminar_name, sem.national_seminar_type, date_format(sem.national_from, '%M %d, %Y'), date_format(sem.national_to, '%M %d, %Y'), sem.international_seminar_name, sem.international_seminar_type, date_format(sem.international_from, '%M %d, %Y'), date_format(sem.international_to, '%M %d, %Y') FROM employees emp INNER JOIN tbl_list_of_seminars sem ON emp.employee_no = sem.employee_no WHERE (emp.is_deleted = @is_deleted AND sem.is_deleted = @sem_is_deleted) AND (emp.first_name LIKE @keyword OR emp.last_name LIKE @keyword OR emp.employee_no LIKE @keyword) ORDER BY emp.last_name ASC;";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("is_deleted", MySqlDbType.Int32).Value = 0;
                        command.Parameters.AddWithValue("sem_is_deleted", MySqlDbType.Int32).Value = 0;
                        command.Parameters.AddWithValue("keyword", '%' + keyword + '%');
                        var da = new MySqlDataAdapter();
                        da.SelectCommand = command;
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dtgRecords.DataSource = dt;

                        dtgRecords.Columns[0].HeaderText = "Employee No.";
                        dtgRecords.Columns[1].HeaderText = "First Name";
                        dtgRecords.Columns[2].HeaderText = "Middle Name";
                        dtgRecords.Columns[3].HeaderText = "Last Name";
                        dtgRecords.Columns[4].HeaderText = "Address";
                        dtgRecords.Columns[5].HeaderText = "Gender";
                        dtgRecords.Columns[6].Visible = false;
                        dtgRecords.Columns[7].Visible = false;
                        dtgRecords.Columns[8].Visible = false;
                        dtgRecords.Columns[9].Visible = false;
                        dtgRecords.Columns[10].HeaderText = "Highest Degree";
                        dtgRecords.Columns[11].Visible = false;
                        dtgRecords.Columns[12].Visible = false;
                        dtgRecords.Columns[13].Visible = false;
                        dtgRecords.Columns[14].Visible = false;
                        dtgRecords.Columns[15].Visible = false;
                        dtgRecords.Columns[16].Visible = false;
                        dtgRecords.Columns[17].Visible = false;
                        dtgRecords.Columns[18].Visible = false;
                        dtgRecords.Columns[19].Visible = false;
                        dtgRecords.Columns[20].Visible = false;
                        dtgRecords.Columns[21].HeaderText = "Employee Type";
                        dtgRecords.Columns[22].HeaderText = "Position";
                        dtgRecords.Columns[23].Visible = false;
                        dtgRecords.Columns[24].Visible = false;
                        dtgRecords.Columns[25].Visible = false;
                        dtgRecords.Columns[26].HeaderText = "Department";
                        dtgRecords.Columns[27].HeaderText = "Employee Status";
                        dtgRecords.Columns[28].Visible = false;
                        dtgRecords.Columns[29].Visible = false;
                        dtgRecords.Columns[30].Visible = false;
                        dtgRecords.Columns[31].Visible = false;
                        dtgRecords.Columns[32].Visible = false;
                        dtgRecords.Columns[33].Visible = false;
                        dtgRecords.Columns[34].Visible = false;
                        dtgRecords.Columns[35].Visible = false;
                        dtgRecords.Columns[36].Visible = false;
                        dtgRecords.Columns[37].Visible = false;
                        dtgRecords.Columns[38].Visible = false;
                        dtgRecords.Columns[39].Visible = false;
                        dtgRecords.Columns[40].Visible = false;
                        dtgRecords.Columns[41].Visible = false;
                        dtgRecords.Columns[42].Visible = false;
                        dtgRecords.Columns[43].Visible = false;
                        dtgRecords.Columns[44].Visible = false;
                        dtgRecords.Columns[45].Visible = false;
                        dtgRecords.Columns[46].Visible = false;
                        dtgRecords.Columns[47].Visible = false;
                        if (dt.Rows.Count == 0)
                        {
                            MessageBox.Show("No data found!", "Not found",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Functions
        private bool CheckEmployeeExists()
        {
            try
            {
                using (MySqlConnection connection =
                    new MySqlConnection(ConfigurationManager.ConnectionStrings["HRISConnection"].ConnectionString))
                {

                    connection.Open();
                    string query = "SELECT employee_no FROM employees WHERE employee_no = @employee_no;";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("employee_no", txtEmployeeNo.Text);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                return true;
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }
        private System.Drawing.Image ConvertBinaryToImage(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
            {
                return System.Drawing.Image.FromStream(ms);
            }
        }

        private byte[] ConvertImageToBinary(System.Drawing.Image image)
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

        private List<string> AcademicPositions()
        {
            const string ACADEMIC = "Academic";
            var academicPositions = new List<string>();
            try
            {
                using (var connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["HRISConnection"].ConnectionString))
                {
                    connection.Open();
                    string query = @"SELECT position_name FROM tbl_positions WHERE position_type = @position_type;";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.Add("position_type", MySqlDbType.VarChar).Value = ACADEMIC;
                        MySqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            academicPositions.Add(reader["position_name"].ToString());
                        }
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }

            return academicPositions;
        }

        private List<string> NonAcademicPositions()
        {
            const string NON_ACADEMIC = "Non - Academic";
            var nonAcademicPositions = new List<string>();
            try
            {
                using (var connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["HRISConnection"].ConnectionString))
                {
                    connection.Open();
                    string query = @"SELECT position_name FROM tbl_positions WHERE position_type = @position_type;";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.Add("position_type", MySqlDbType.VarChar).Value = NON_ACADEMIC;
                        MySqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            nonAcademicPositions.Add(reader["position_name"].ToString());
                        }
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }

            return nonAcademicPositions;
        }

        private string GetSalaryGrade()
        {
            string salaryGrade = string.Empty;
            try
            {
                using (var connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["HRISConnection"].ConnectionString))
                {
                    connection.Open();
                    string query = @"SELECT salary_grade_level FROM tbl_positions WHERE position_name = @position_name;";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.Add("position_name", MySqlDbType.VarChar).Value = cmbPosition.SelectedItem.ToString();
                        MySqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            salaryGrade = reader["salary_grade_level"].ToString();
                        }
                    }
                }
            }
            catch (Exception)
            {
                salaryGrade = string.Empty;
            }
            return salaryGrade;
        }
        #endregion


        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pgbAttachment.Value = e.ProgressPercentage;
            lblPercent.Text = pgbAttachment.Value + "%";
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            copyFile(source, destination);
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            Methods.ClearItems(panelFileInformation);
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
            Methods.ClearItems(panelFileInformation);
            pgbAttachment.Value = 0;
            grpSeminar.Enabled = true;
            panelFileInformation.Enabled = true;
            grpBS.Enabled = false;
            grpMasteral.Enabled = false;
            grpDoctoral.Enabled = false;
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
            if ((txtEmployeeNo.Text != string.Empty && txtFirstName.Text != string.Empty && txtMiddleName.Text != string.Empty &&
                txtLastName.Text != string.Empty && txtAddress.Text != string.Empty && cmbGender.Text != string.Empty && txtPlaceofBirth.Text != string.Empty &&
                txtContactNo.Text != string.Empty && cmbCivilStatus.Text != string.Empty && cmbDepartment.Text != string.Empty && cmbWorkStatus.Text != string.Empty &&
                cmbDegree.Text != string.Empty && cmbEmployeeType.Text != string.Empty && destination != string.Empty))
            {
                try
                {
                    if (btnSave.Text == "&Save")
                    {
                        if (!CheckEmployeeExists())
                        {
                            InsertRecord();
                        }
                        else
                        {
                            MessageBox.Show("Duplicate Employee No.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }


                    }
                    else if (btnSave.Text == "&Update")
                    {
                        UpdateRecord();
                    }
                    destination = string.Empty;
                    Methods.ClearItems(panelFileInformation);
                    Methods.ClearItems(grpBS);
                    Methods.ClearItems(grpMasteral);
                    Methods.ClearItems(grpDoctoral);
                    Methods.ClearItems(grpAttachment);
                    btnSave.Text = "&Save";
                    pgbAttachment.Value = 0;
                    panelFileInformation.Enabled = false;
                    DisplayRecords(string.Empty);
                    txtEmployeeNo.ReadOnly = false;
                    label14.Visible = false;
                    dtpEndofContract.Visible = false;
                    panelFileInformation.Enabled = false;
                    btnCancel.Enabled = false;
                    btnSave.Enabled = false;
                    btnNew.Enabled = true;
                    btnDelete.Enabled = true;
                    btnUpdate.Enabled = true;
                    btnView.Enabled = true;
                    grpPicture.Visible = false;
                    dtgRecords.Enabled = true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to insert/update employee information. " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            else
            {
                MessageBox.Show("One of your fields are invalid.", "Required",
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
            DialogResult dialogResult =
                    MessageBox.Show(
                        $"Do you want to delete {dtgRecords.CurrentRow.Cells["last_name"].Value}, {dtgRecords.CurrentRow.Cells["first_name"].Value} {dtgRecords.CurrentRow.Cells["middle_name"].Value} profile ?",
                        "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    using (MySqlConnection connection =
                        new MySqlConnection(ConfigurationManager.ConnectionStrings["HRISConnection"].ConnectionString))
                    {

                        connection.Open();
                        using (MySqlTransaction transaction = connection.BeginTransaction())
                        {
                            
                            string query;
                            query = "UPDATE employees SET is_deleted = @is_deleted WHERE employee_no = @employee_no";
                            using (MySqlCommand command = new MySqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@is_deleted", 1);
                                command.Parameters.AddWithValue("@employee_no", dtgRecords.CurrentRow.Cells["employee_no"].Value);
                                command.ExecuteNonQuery();
                                transaction.Commit();
                                DeleteSeminar();
                                MessageBox.Show("Successfully deleted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.None);
                                DisplayRecords(string.Empty);
                            }
                        }
                    }
                    
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void DeleteSeminar()
        {
            using (var connection =
                new MySqlConnection(ConfigurationManager.ConnectionStrings["HRISConnection"].ConnectionString))
            {
                connection.Open();
                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    string query;
                    query = "UPDATE tbl_list_of_seminars SET is_deleted = @is_deleted WHERE employee_no = @employee_no";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@is_deleted", 1);
                        command.Parameters.AddWithValue("@employee_no", dtgRecords.CurrentRow.Cells["employee_no"].Value);
                        command.ExecuteNonQuery();
                        transaction.Commit();
                    }
                }
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            var frm = new frmViewEmployee(dtgRecords.CurrentRow.Cells[0].Value.ToString(), dtgRecords.CurrentRow.Cells[1].Value.ToString(), dtgRecords.CurrentRow.Cells[2].Value.ToString(), dtgRecords.CurrentRow.Cells[3].Value.ToString(), dtgRecords.CurrentRow.Cells[4].Value.ToString(), dtgRecords.CurrentRow.Cells[5].Value.ToString(), dtgRecords.CurrentRow.Cells[6].Value.ToString(), dtgRecords.CurrentRow.Cells[7].Value.ToString(), dtgRecords.CurrentRow.Cells[8].Value.ToString(), dtgRecords.CurrentRow.Cells[9].Value.ToString(), dtgRecords.CurrentRow.Cells[10].Value.ToString(), dtgRecords.CurrentRow.Cells[11].Value.ToString(), dtgRecords.CurrentRow.Cells[12].Value.ToString(), dtgRecords.CurrentRow.Cells[13].Value.ToString(), dtgRecords.CurrentRow.Cells[14].Value.ToString(), dtgRecords.CurrentRow.Cells[15].Value.ToString(), dtgRecords.CurrentRow.Cells[16].Value.ToString(), dtgRecords.CurrentRow.Cells[17].Value.ToString(), dtgRecords.CurrentRow.Cells[18].Value.ToString(), dtgRecords.CurrentRow.Cells[19].Value.ToString(), dtgRecords.CurrentRow.Cells[20].Value.ToString(), dtgRecords.CurrentRow.Cells[21].Value.ToString(), dtgRecords.CurrentRow.Cells[22].Value.ToString(), dtgRecords.CurrentRow.Cells[23].Value.ToString(), dtgRecords.CurrentRow.Cells[24].Value.ToString(), dtgRecords.CurrentRow.Cells[25].Value.ToString(), dtgRecords.CurrentRow.Cells[26].Value.ToString(), dtgRecords.CurrentRow.Cells[27].Value.ToString(), (byte[])dtgRecords.CurrentRow.Cells[28].Value, dtgRecords.CurrentRow.Cells[29].Value.ToString(), dtgRecords.CurrentRow.Cells[30].Value.ToString(), dtgRecords.CurrentRow.Cells[31].Value.ToString(), dtgRecords.CurrentRow.Cells[32].Value.ToString(), dtgRecords.CurrentRow.Cells[33].Value.ToString(), dtgRecords.CurrentRow.Cells[34].Value.ToString(), dtgRecords.CurrentRow.Cells[35].Value.ToString(), dtgRecords.CurrentRow.Cells[36].Value.ToString(), dtgRecords.CurrentRow.Cells[37].Value.ToString(), dtgRecords.CurrentRow.Cells[38].Value.ToString(), dtgRecords.CurrentRow.Cells[39].Value.ToString(), dtgRecords.CurrentRow.Cells[40].Value.ToString(), dtgRecords.CurrentRow.Cells[41].Value.ToString(), dtgRecords.CurrentRow.Cells[42].Value.ToString(), dtgRecords.CurrentRow.Cells[43].Value.ToString(), dtgRecords.CurrentRow.Cells[44].Value.ToString(), dtgRecords.CurrentRow.Cells[45].Value.ToString(), dtgRecords.CurrentRow.Cells[46].Value.ToString(), dtgRecords.CurrentRow.Cells[47].Value.ToString());
            frm.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string message = "Do you want to edit this employee profile?";
            string title = "Edit Profile";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                grpSeminar.Enabled = false;
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
                cmbDegree.SelectedItem = dtgRecords.CurrentRow.Cells[10].Value;
                txtBSCourse.Text = dtgRecords.CurrentRow.Cells[11].Value.ToString();
                txtBSYearGraduated.Text = dtgRecords.CurrentRow.Cells[12].Value.ToString();
                txtBSSchool.Text = dtgRecords.CurrentRow.Cells[13].Value.ToString();
                txtMasteralCourse.Text = dtgRecords.CurrentRow.Cells[14].Value.ToString();
                txtMasteralYearGraduated.Text = dtgRecords.CurrentRow.Cells[15].Value.ToString();
                txtMasteralSchool.Text = dtgRecords.CurrentRow.Cells[16].Value.ToString();
                txtDoctoralCourse.Text = dtgRecords.CurrentRow.Cells[17].Value.ToString();
                txtDoctoralYearGraduated.Text = dtgRecords.CurrentRow.Cells[18].Value.ToString();
                txtDoctoralSchool.Text = dtgRecords.CurrentRow.Cells[19].Value.ToString();
                txtEligibility.Text = dtgRecords.CurrentRow.Cells[20].Value.ToString();
                cmbEmployeeType.SelectedItem = dtgRecords.CurrentRow.Cells[21].Value;
                cmbPosition.SelectedItem = dtgRecords.CurrentRow.Cells[22].Value;
                txtUniqueItemNo.Text = dtgRecords.CurrentRow.Cells[23].Value.ToString();
                txtSalaryGrade.Text = dtgRecords.CurrentRow.Cells[24].Value.ToString();
                txtStep.Text = dtgRecords.CurrentRow.Cells[25].Value.ToString();
                cmbDepartment.SelectedItem = dtgRecords.CurrentRow.Cells[26].Value;
                cmbWorkStatus.SelectedItem = dtgRecords.CurrentRow.Cells[27].Value;
                destination = dtgRecords.CurrentRow.Cells[29].Value.ToString();
                dtpHiredDate.Text = dtgRecords.CurrentRow.Cells[30].Value.ToString();
                if (cmbWorkStatus.SelectedItem.ToString() == "Regular")
                {
                    label14.Visible = false;
                    dtpEndofContract.Visible = false;
                }
                else
                {
                    label14.Visible = true;
                    dtpEndofContract.Visible = true;
                    dtpEndofContract.Text = dtgRecords.CurrentRow.Cells[31].Value.ToString();
                }
                dtgRecords.Enabled = false;
                grpPicture.Enabled = false;
                grpAttachment.Enabled = false;
            }
            
        }

        private void txtContactNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }


        private void frmEmployeesRecord_Load(object sender, EventArgs e)
        {
        }

        private void btnAttach_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                openFileDialog.Title = "Select a word document to be upload.";
                openFileDialog.Filter = "Select File(*.doc; *.docx;; *.pdf)|*.doc;*.docx;*.pdf;";
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


        private void btnPositions_Click(object sender, EventArgs e)
        {
            frmSelectPositions frm = new frmSelectPositions();
            frm.ShowDialog();
        }

        private void cmbDegree_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDegree.SelectedItem.ToString() == "College")
            {
                grpBS.Enabled = true;
                grpMasteral.Enabled = false;
                grpDoctoral.Enabled = false;
            }
            else if (cmbDegree.SelectedItem.ToString() == "Masteral Degree")
            {
                grpBS.Enabled = true;
                grpMasteral.Enabled = true;
                grpDoctoral.Enabled = false;
            }
            else if (cmbDegree.SelectedItem.ToString() == "Doctoral Degree")
            {
                grpBS.Enabled = true;
                grpMasteral.Enabled = true;
                grpDoctoral.Enabled = true;
            }
            else
            {
                grpBS.Enabled = false;
                grpMasteral.Enabled = false;
                grpDoctoral.Enabled = false;
            }

        }

        private void txtBSYearGraduated_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtMasteralYearGraduated_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtDoctoralYearGraduated_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            var frm = new previewAllEmployees();
            frm.ShowDialog();
        }

        private void dtgRecords_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAddLocalSeminar_Click(object sender, EventArgs e)
        {
            var frm = new frmSeminarLocal();
            frm.ShowDialog();
        }

        private void btnAddRegionalSeminar_Click(object sender, EventArgs e)
        {
            var frm = new frmSeminarRegional();
            frm.ShowDialog();
        }

        private void btnAddNationalSeminar_Click(object sender, EventArgs e)
        {
            var frm = new frmSeminarNational();
            frm.ShowDialog();

        }

        private void btnAddInternationSeminar_Click(object sender, EventArgs e)
        {
            var frm = new frmSeminarInternational();
            frm.ShowDialog();
        }

        private void cmbEmployeeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEmployeeType.SelectedItem.ToString() == "Academic")
            {
                cmbPosition.Items.Clear();
                foreach (var position in AcademicPositions())
                {
                    cmbPosition.Items.Add(position);
                }
            }
            else if (cmbEmployeeType.SelectedItem.ToString() == "Non - Academic")
            {
                cmbPosition.Items.Clear();
                foreach (var position in NonAcademicPositions())
                {
                    cmbPosition.Items.Add(position);
                }
            }
            else
            {
                cmbPosition.Items.Clear();
            }
            txtSalaryGrade.Clear();
        }

        private void txtBSYearGraduated_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSalaryGrade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtStep_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void dtgRecords_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var frm = new frmViewEmployee(dtgRecords.CurrentRow.Cells[0].Value.ToString(), dtgRecords.CurrentRow.Cells[1].Value.ToString(), dtgRecords.CurrentRow.Cells[2].Value.ToString(), dtgRecords.CurrentRow.Cells[3].Value.ToString(), dtgRecords.CurrentRow.Cells[4].Value.ToString(), dtgRecords.CurrentRow.Cells[5].Value.ToString(), dtgRecords.CurrentRow.Cells[6].Value.ToString(), dtgRecords.CurrentRow.Cells[7].Value.ToString(), dtgRecords.CurrentRow.Cells[8].Value.ToString(), dtgRecords.CurrentRow.Cells[9].Value.ToString(), dtgRecords.CurrentRow.Cells[10].Value.ToString(), dtgRecords.CurrentRow.Cells[11].Value.ToString(), dtgRecords.CurrentRow.Cells[12].Value.ToString(), dtgRecords.CurrentRow.Cells[13].Value.ToString(), dtgRecords.CurrentRow.Cells[14].Value.ToString(), dtgRecords.CurrentRow.Cells[15].Value.ToString(), dtgRecords.CurrentRow.Cells[16].Value.ToString(), dtgRecords.CurrentRow.Cells[17].Value.ToString(), dtgRecords.CurrentRow.Cells[18].Value.ToString(), dtgRecords.CurrentRow.Cells[19].Value.ToString(), dtgRecords.CurrentRow.Cells[20].Value.ToString(), dtgRecords.CurrentRow.Cells[21].Value.ToString(), dtgRecords.CurrentRow.Cells[22].Value.ToString(), dtgRecords.CurrentRow.Cells[23].Value.ToString(), dtgRecords.CurrentRow.Cells[24].Value.ToString(), dtgRecords.CurrentRow.Cells[25].Value.ToString(), dtgRecords.CurrentRow.Cells[26].Value.ToString(), dtgRecords.CurrentRow.Cells[27].Value.ToString(), (byte[])dtgRecords.CurrentRow.Cells[28].Value, dtgRecords.CurrentRow.Cells[29].Value.ToString(), dtgRecords.CurrentRow.Cells[30].Value.ToString(), dtgRecords.CurrentRow.Cells[31].Value.ToString(), dtgRecords.CurrentRow.Cells[32].Value.ToString(), dtgRecords.CurrentRow.Cells[33].Value.ToString(), dtgRecords.CurrentRow.Cells[34].Value.ToString(), dtgRecords.CurrentRow.Cells[35].Value.ToString(), dtgRecords.CurrentRow.Cells[36].Value.ToString(), dtgRecords.CurrentRow.Cells[37].Value.ToString(), dtgRecords.CurrentRow.Cells[38].Value.ToString(), dtgRecords.CurrentRow.Cells[39].Value.ToString(), dtgRecords.CurrentRow.Cells[40].Value.ToString(), dtgRecords.CurrentRow.Cells[41].Value.ToString(), dtgRecords.CurrentRow.Cells[42].Value.ToString(), dtgRecords.CurrentRow.Cells[43].Value.ToString(), dtgRecords.CurrentRow.Cells[44].Value.ToString(), dtgRecords.CurrentRow.Cells[45].Value.ToString(), dtgRecords.CurrentRow.Cells[46].Value.ToString(), dtgRecords.CurrentRow.Cells[47].Value.ToString());
            frm.ShowDialog();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DisplayRecords(txtSearch.Text);
        }

        private void cmbPosition_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbPosition.SelectedItem != null)
            {
                txtSalaryGrade.Clear();
                txtSalaryGrade.Text = GetSalaryGrade();
            }
            else
            {
                txtSalaryGrade.Clear();
            }
        }

        private void txtLeaveCredit_KeyPress(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void txtEmployeeNo_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmployeeNo.Text))
            {
                e.Cancel = true;
                txtEmployeeNo.Focus();
                errorProvider1.SetError(txtEmployeeNo, "Name should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtEmployeeNo, "");
            }
        }
    }
}