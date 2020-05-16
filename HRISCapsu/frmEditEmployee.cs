using System;
using System.Data;
using System.Windows.Forms;
using static HRISCapsu.Repository.EmployeeRepository;
using static HRISCapsu.Repository.LeaveCreditRepository;
using static HRISCapsu.Classes.Methods;
using static HRISCapsu.Classes.Position;
using static HRISCapsu.Repository.ListOfSeminarRepository;
using HRISCapsu.Models;
using HRISCapsu.ReportPreviewer;

namespace HRISCapsu
{
    public partial class frmEditEmployee : Form
    {
        public frmEditEmployee()
        {
            InitializeComponent();
            GetAllPositionInComboBox(cmbPosition);
        }
        private void LoadDataInGridView()
        {
            using (var dt = new DataTable())
            {
                GetAllEmployees(txtSearch.Text, 0, dt);
                dtgRecords.AutoGenerateColumns = false;
                dtgRecords.DataSource = dt;
            }
        }

        private void frmEditEmployee_Load(object sender, EventArgs e)
        {
            LoadDataInGridView();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearItems(panelFileInformation);
            ClearGroupControls(grpBS);
            ClearGroupControls(grpMasteral);
            ClearGroupControls(grpDoctoral);
            DisableSaveAndCancelButtons();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadDataInGridView();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            panelFileInformation.Enabled = true;
            txtSearch.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnPrint.Enabled = false;
            btnSave.Visible = true;
            btnCancel.Visible = true;
            btnClose.Enabled = false;
            BindDataToTextBox();
        }
        private void BindDataToTextBox()
        {
            txtEmployeeNo.Text = dtgRecords.CurrentRow.Cells[1].Value.ToString();
            txtFirstName.Text = dtgRecords.CurrentRow.Cells[2].Value.ToString();
            txtMiddleName.Text = dtgRecords.CurrentRow.Cells[3].Value.ToString();
            txtLastName.Text = dtgRecords.CurrentRow.Cells[4].Value.ToString();
            txtAddress.Text = dtgRecords.CurrentRow.Cells[5].Value.ToString();
            cmbGender.Text = dtgRecords.CurrentRow.Cells[6].Value.ToString();
            dtpDateofBirth.Text = dtgRecords.CurrentRow.Cells[7].Value.ToString();
            txtPlaceofBirth.Text = dtgRecords.CurrentRow.Cells[8].Value.ToString();
            txtContactNo.Text = dtgRecords.CurrentRow.Cells[9].Value.ToString();
            cmbCivilStatus.Text = dtgRecords.CurrentRow.Cells[10].Value.ToString();
            cmbDegree.Text = dtgRecords.CurrentRow.Cells[11].Value.ToString();
            txtBSCourse.Text = dtgRecords.CurrentRow.Cells[12].Value.ToString();
            txtBSYearGraduated.Text = dtgRecords.CurrentRow.Cells[13].Value.ToString();
            txtBSSchool.Text = dtgRecords.CurrentRow.Cells[14].Value.ToString();
            txtMasteralCourse.Text = dtgRecords.CurrentRow.Cells[15].Value.ToString();
            txtMasteralYearGraduated.Text = dtgRecords.CurrentRow.Cells[16].Value.ToString();
            txtMasteralSchool.Text = dtgRecords.CurrentRow.Cells[17].Value.ToString();
            txtDoctoralCourse.Text = dtgRecords.CurrentRow.Cells[18].Value.ToString();
            txtDoctoralYearGraduated.Text = dtgRecords.CurrentRow.Cells[19].Value.ToString();
            txtDoctoralSchool.Text = dtgRecords.CurrentRow.Cells[20].Value.ToString();
            txtEligibility.Text = dtgRecords.CurrentRow.Cells[21].Value.ToString();
            cmbEmployeeType.Text = dtgRecords.CurrentRow.Cells[22].Value.ToString();
            cmbPosition.Text = dtgRecords.CurrentRow.Cells[23].Value.ToString();
            txtUniqueItemNo.Text = dtgRecords.CurrentRow.Cells[24].Value.ToString();
            txtSalaryGrade.Text = dtgRecords.CurrentRow.Cells[25].Value.ToString();
            txtStep.Text = dtgRecords.CurrentRow.Cells[26].Value.ToString();
            cmbDepartment.Text = dtgRecords.CurrentRow.Cells[27].Value.ToString();
            cmbWorkStatus.Text = dtgRecords.CurrentRow.Cells[28].Value.ToString();
            dtpHiredDate.Text = dtgRecords.CurrentRow.Cells[29].Value.ToString();
            dtpEndofContract.Text = dtgRecords.CurrentRow.Cells[30].Value.ToString();
            txtLeaveCredits.Text = dtgRecords.CurrentRow.Cells[31].Value.ToString();
        }

        private void DisableSaveAndCancelButtons()
        {
            panelFileInformation.Enabled = false;
            txtSearch.Enabled = true;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            btnPrint.Enabled = true;
            btnSave.Visible = false;
            btnCancel.Visible = false;
            btnClose.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                var model = new Employee
                {
                    EmployeeNo = txtEmployeeNo.Text,
                    FirstName = txtFirstName.Text,
                    MiddleName = txtMiddleName.Text,
                    LastName = txtLastName.Text,
                    Address = txtAddress.Text,
                    Gender = cmbGender.Text,
                    DateOfBirth = dtpDateofBirth.Value,
                    PlaceOfBirth = txtPlaceofBirth.Text,
                    ContactNo = txtContactNo.Text,
                    CivilStatus = cmbCivilStatus.Text,
                    HighestDegree = cmbDegree.Text,
                    BsCourse = txtBSCourse.Text,
                    BsYearGraduated = txtBSYearGraduated.Text,
                    BsSchool = txtBSSchool.Text,
                    MasteralCourse = txtMasteralCourse.Text,
                    MasteralYearGraduated = txtMasteralYearGraduated.Text,
                    MasteralSchool = txtMasteralSchool.Text,
                    DoctoralCourse = txtDoctoralCourse.Text,
                    DoctoralYearGraduated = txtDoctoralYearGraduated.Text,
                    DoctoralSchool = txtDoctoralSchool.Text,
                    Eligibility = txtEligibility.Text,
                    EmployeeType = cmbEmployeeType.Text,
                    Position = cmbPosition.Text,
                    UniqueItemNo = txtUniqueItemNo.Text,
                    SalaryGrade = Convert.ToInt32(txtSalaryGrade.Text),
                    Step = Convert.ToInt32(txtStep.Text),
                    Department = cmbDepartment.Text,
                    WorkStatus = cmbWorkStatus.Text,
                    HiredDate = dtpHiredDate.Value,
                    EndOfContract = dtpEndofContract.Value
                };
                UpdateEmployee(model);
                int? leaveCredit = null, remainingLeaveCredit = null;

                if (cmbEmployeeType.Text == "Academic")
                {
                    leaveCredit = Convert.ToInt32(txtLeaveCredits.Text);
                    remainingLeaveCredit = GetRemainingLeaveCredit();
                }
                var modelLeaveCredit = new LeaveCredits
                {
                    EmployeeNo = txtEmployeeNo.Text,
                    LeaveCredit = leaveCredit,
                    RemainingLeaveCredit = remainingLeaveCredit
                };
                UpdateLeaveCredit(modelLeaveCredit);

                var seminar = new Seminar
                {
                    EmployeeNo = txtEmployeeNo.Text,
                    LocalSeminarName = frmSeminarLocal.LocalSeminar,
                    LocalSeminarType = frmSeminarLocal.LocalSeminarType,
                    LocalFrom = frmSeminarLocal.LocalSeminarFrom,
                    LocalTo = frmSeminarLocal.LocalSeminarTo,
                    RegionalSeminarName = frmSeminarRegional.RegionalSeminar,
                    RegionalSeminarType = frmSeminarRegional.RegionalSeminarType,
                    RegionalFrom = frmSeminarRegional.RegionalSeminarFrom,
                    RegionalTo = frmSeminarRegional.RegionalSeminarTo,
                    NationalSeminarName = frmSeminarNational.NationalSeminar,
                    NationalSeminarType = frmSeminarNational.NationalSeminarType,
                    NationalFrom = frmSeminarNational.NationalSeminarFrom,
                    NationalTo = frmSeminarNational.NationalSeminarTo,
                    InternationalSeminarName = frmSeminarInternational.InternationalSeminar,
                    InternationalSeminarType = frmSeminarInternational.InternationalSeminarType,
                    InternationalFrom = frmSeminarInternational.InternationalSeminarFrom,
                    InternationalTo = frmSeminarInternational.InternationalSeminarTo
                };

                if (frmSeminarLocal.LocalSeminar != null)
                    UpdateLocalSeminar(seminar);

                if (frmSeminarRegional.RegionalSeminar != null)
                    UpdateRegionalSeminar(seminar);

                if (frmSeminarNational.NationalSeminar != null)
                    UpdateNationalSeminar(seminar);

                if (frmSeminarInternational.InternationalSeminar != null)
                    UpdateInternationalSeminar(seminar);

                MessageBox.Show("Successfully updated!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearSeminars();
                ClearItems(panelFileInformation);
                ClearGroupControls(grpBS);
                ClearGroupControls(grpMasteral);
                ClearGroupControls(grpDoctoral);
                DisableSaveAndCancelButtons();
                LoadDataInGridView();
            }
            
        }

        private void ClearSeminars()
        {
            frmSeminarLocal.LocalSeminar = null;
            frmSeminarLocal.LocalSeminarType = null;
            frmSeminarLocal.LocalSeminarFrom = null;
            frmSeminarLocal.LocalSeminarTo = null;
            frmSeminarRegional.RegionalSeminar = null;
            frmSeminarRegional.RegionalSeminarType = null;
            frmSeminarRegional.RegionalSeminarFrom = null;
            frmSeminarRegional.RegionalSeminarTo = null;
            frmSeminarNational.NationalSeminar = null;
            frmSeminarNational.NationalSeminarType = null;
            frmSeminarNational.NationalSeminarFrom = null;
            frmSeminarNational.NationalSeminarTo = null;
            frmSeminarInternational.InternationalSeminar = null;
            frmSeminarInternational.InternationalSeminarType = null;
            frmSeminarInternational.InternationalSeminarFrom = null;
            frmSeminarInternational.InternationalSeminarTo = null;
        }

        private int GetRemainingLeaveCredit()
        {
            int remainingLeaveCredit;
            if (dtgRecords.CurrentRow.Cells[31].Value.ToString() == txtLeaveCredits.Text)
            {
                remainingLeaveCredit = Convert.ToInt32(dtgRecords.CurrentRow.Cells[32].Value);
            }
            else
            {
                remainingLeaveCredit = Convert.ToInt32(txtLeaveCredits.Text);
            }
            return remainingLeaveCredit;
        }

        private void cmbEmployeeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtLeaveCredits.Clear();
            if (cmbEmployeeType.Text == "Academic")
            {
                txtLeaveCredits.Text = dtgRecords.CurrentRow.Cells[31].Value.ToString();
                txtLeaveCredits.Enabled = true;
            }
            else
            {
                txtLeaveCredits.Enabled = false;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult =
                    MessageBox.Show(
                        $"Do you want to delete {dtgRecords.CurrentRow.Cells["LastName"].Value}, {dtgRecords.CurrentRow.Cells["FirstName"].Value} {dtgRecords.CurrentRow.Cells["MiddleName"].Value} profile ?",
                        "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                var employee = new Employee
                {
                    EmployeeNo = dtgRecords.CurrentRow.Cells[1].Value.ToString(),
                    IsDeleted = 1
                };
                DeleteEmployee(employee);
                var leaveCredit = new LeaveCredits
                {
                    EmployeeNo = dtgRecords.CurrentRow.Cells[1].Value.ToString(),
                    IsDeleted = 1
                };
                DeleteLeaveCredit(leaveCredit);
                var seminar = new Seminar
                {
                    EmployeeNo = dtgRecords.CurrentRow.Cells[1].Value.ToString(),
                    IsDeleted = 1
                };
                DeleteSeminar(seminar);
                MessageBox.Show("Successfully deleted!", "Successfully deleted!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataInGridView();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            var frm = new previewAllEmployees();
            frm.ShowDialog();
        }

        private void cmbWorkStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbWorkStatus.Text == "Contractual")
                dtpEndofContract.Enabled = true;
            else
                dtpEndofContract.Enabled = false;
        }

        private void txtEmployeeNo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmployeeNo.Text))
            {
                e.Cancel = true;
                txtEmployeeNo.Focus();
                errorProvider1.SetError(txtEmployeeNo, "Employee No should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtEmployeeNo, "");
            }
        }

        private void txtFirstName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                e.Cancel = true;
                txtFirstName.Focus();
                errorProvider1.SetError(txtFirstName, "First Name should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtFirstName, "");
            }
        }

        private void txtLastName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                e.Cancel = true;
                txtLastName.Focus();
                errorProvider1.SetError(txtLastName, "Last Name should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtLastName, "");
            }
        }

        private void txtAddress_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                e.Cancel = true;
                txtAddress.Focus();
                errorProvider1.SetError(txtAddress, "Address should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtAddress, "");
            }
        }

        private void cmbGender_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbGender.Text))
            {
                e.Cancel = true;
                cmbGender.Focus();
                errorProvider1.SetError(cmbGender, "Gender should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(cmbGender, "");
            }
        }

        private void dtpDateofBirth_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(dtpDateofBirth.Text))
            {
                e.Cancel = true;
                dtpDateofBirth.Focus();
                errorProvider1.SetError(dtpDateofBirth, "Date of Birth should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(dtpDateofBirth, "");
            }
        }

        private void txtPlaceofBirth_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPlaceofBirth.Text))
            {
                e.Cancel = true;
                txtPlaceofBirth.Focus();
                errorProvider1.SetError(txtPlaceofBirth, "Place of Birth should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtPlaceofBirth, "");
            }
        }

        private void txtContactNo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtContactNo.Text))
            {
                e.Cancel = true;
                txtContactNo.Focus();
                errorProvider1.SetError(txtContactNo, "Contact No. should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtContactNo, "");
            }
        }

        private void cmbCivilStatus_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbCivilStatus.Text))
            {
                e.Cancel = true;
                cmbCivilStatus.Focus();
                errorProvider1.SetError(cmbCivilStatus, "Civil Status should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(cmbCivilStatus, "");
            }
        }

        private void cmbDegree_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbDegree.Text))
            {
                e.Cancel = true;
                cmbDegree.Focus();
                errorProvider1.SetError(cmbDegree, "Degree should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(cmbDegree, "");
            }
        }

        private void cmbEmployeeType_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbEmployeeType.Text))
            {
                e.Cancel = true;
                cmbEmployeeType.Focus();
                errorProvider1.SetError(cmbEmployeeType, "Employee Type should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(cmbEmployeeType, "");
            }
        }

        private void txtLeaveCredits_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (cmbEmployeeType.Text == "Academic")
            {
                if (string.IsNullOrWhiteSpace(txtLeaveCredits.Text))
                {
                    e.Cancel = true;
                    txtLeaveCredits.Focus();
                    errorProvider1.SetError(txtLeaveCredits, "Leave Credits should not be left blank!");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider1.SetError(txtLeaveCredits, "");
                }
            }
        }

        private void cmbPosition_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbPosition.Text))
            {
                e.Cancel = true;
                cmbPosition.Focus();
                errorProvider1.SetError(cmbPosition, "Position should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(cmbPosition, "");
            }
        }

        private void txtUniqueItemNo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUniqueItemNo.Text))
            {
                e.Cancel = true;
                txtUniqueItemNo.Focus();
                errorProvider1.SetError(txtUniqueItemNo, "Unique Item No. should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtUniqueItemNo, "");
            }
        }

        private void txtSalaryGrade_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSalaryGrade.Text))
            {
                e.Cancel = true;
                txtSalaryGrade.Focus();
                errorProvider1.SetError(txtSalaryGrade, "Salary Grade should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtSalaryGrade, "");
            }
        }

        private void txtStep_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtStep.Text))
            {
                e.Cancel = true;
                txtStep.Focus();
                errorProvider1.SetError(txtStep, "Step should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtStep, "");
            }
        }

        private void cmbDepartment_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbDepartment.Text))
            {
                e.Cancel = true;
                cmbDepartment.Focus();
                errorProvider1.SetError(cmbDepartment, "Department should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(cmbDepartment, "");
            }
        }

        private void cmbWorkStatus_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbWorkStatus.Text))
            {
                e.Cancel = true;
                cmbWorkStatus.Focus();
                errorProvider1.SetError(cmbWorkStatus, "Work Status should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(cmbWorkStatus, "");
            }
        }

        private void cmbDegree_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDegree.Text == "College")
            {
                grpBS.Enabled = true;
                grpMasteral.Enabled = false;
                grpDoctoral.Enabled = false;
            }
            else if (cmbDegree.Text == "Masteral Degree")
            {
                grpBS.Enabled = true;
                grpMasteral.Enabled = true;
                grpDoctoral.Enabled = false;
            }
            else if (cmbDegree.Text == "Doctoral Degree")
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

        private void btnAddLocalSeminar_Click(object sender, EventArgs e)
        {
            var frm = new frmSeminarLocal(dtgRecords.CurrentRow.Cells[1].Value.ToString());
            frm.ShowDialog();
        }

        private void btnAddNationalSeminar_Click(object sender, EventArgs e)
        {
            var frm = new frmSeminarNational(dtgRecords.CurrentRow.Cells[1].Value.ToString());
            frm.ShowDialog();
        }

        private void btnAddRegionalSeminar_Click(object sender, EventArgs e)
        {
            var frm = new frmSeminarRegional(dtgRecords.CurrentRow.Cells[1].Value.ToString());
            frm.ShowDialog();
        }

        private void btnAddInternationSeminar_Click(object sender, EventArgs e)
        {
            var frm = new frmSeminarInternational(dtgRecords.CurrentRow.Cells[1].Value.ToString());
            frm.ShowDialog();
        }
    }
}
