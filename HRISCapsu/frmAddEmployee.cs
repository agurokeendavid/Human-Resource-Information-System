using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using HRISCapsu.Models;
using static HRISCapsu.Classes.Position;
using static HRISCapsu.Classes.Methods;
using static HRISCapsu.Repository.EmployeeRepository;
using static HRISCapsu.Repository.LeaveCreditRepository;
using static HRISCapsu.Repository.ListOfSeminarRepository;

namespace HRISCapsu
{
    public partial class frmAddEmployee : Form
    {
        private string source;
        private string destination;
        private readonly BackgroundWorker worker = new BackgroundWorker();
        public frmAddEmployee()
        {
            InitializeComponent();
            worker.WorkerSupportsCancellation = true;
            worker.WorkerReportsProgress = true;
            worker.ProgressChanged += worker_ProgressChanged;
            worker.DoWork += Worker_DoWork;
            ClearStaticVariables();
            
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

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            copyFile(source, destination);
        }

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pgbAttachment.Value = e.ProgressPercentage;
            lblPercent.Text = pgbAttachment.Value + "%";
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


        public byte[] ConvertImageToBinary(Image image)
        {
            using (var ms = new MemoryStream())
            {
                image.Save(ms, ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmAddEmployee_Load(object sender, EventArgs e)
        {            
            GetAllPositionInComboBox(cmbPosition);
            ClearItems(panelFileInformation);
        }

        private void cmbPosition_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtSalaryGrade.Clear();
            if (cmbPosition.Text != null)
            {
                GetSalaryGradeInTextBox(cmbPosition.Text, txtSalaryGrade);
            }
        }

        private void cmbEmployeeType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtLeaveCredits.Clear();
            if (cmbEmployeeType.Text == "Academic")
            {
                txtLeaveCredits.Enabled = true;
            }
            else
            {
                txtLeaveCredits.Enabled = false;
            }
        }

        private void cmbWorkStatus_SelectionChangeCommitted(object sender, EventArgs e)
        {
            dtpEndofContract.ResetText();

            if (cmbWorkStatus.Text == "Contractual")
            {
                dtpEndofContract.Enabled = true;
            }
            else
            {
                dtpEndofContract.Enabled = false;
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
                }
            }
        }

        private void btnAddLocalSeminar_Click(object sender, EventArgs e)
        {
            var frm = new frmSeminarLocal();
            frm.ShowDialog();
        }

        private void btnAddNationalSeminar_Click(object sender, EventArgs e)
        {
            var frm = new frmSeminarNational();
            frm.ShowDialog();
        }

        private void btnAddRegionalSeminar_Click(object sender, EventArgs e)
        {
            var frm = new frmSeminarRegional();
            frm.ShowDialog();
        }

        private void btnAddInternationSeminar_Click(object sender, EventArgs e)
        {
            var frm = new frmSeminarInternational();
            frm.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled) && source != null)
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
                    EmployeePhoto = ConvertImageToBinary(pictureBox2.Image),
                    DocumentPath = destination,
                    HiredDate = dtpHiredDate.Value,
                    EndOfContract = dtpEndofContract.Value,
                    IsDeleted = 0
                };

                if (InsertEmployee(model) == 1)
                {
                    worker.RunWorkerAsync();
                    int? leaveCredit = null, remainingLeaveCredit = null;
                    if (cmbEmployeeType.Text == "Academic")
                    {
                        leaveCredit = Convert.ToInt32(txtLeaveCredits.Text);
                        remainingLeaveCredit = Convert.ToInt32(txtLeaveCredits.Text);
                    }
                    var modelLeaveCredit = new LeaveCredits
                    {
                        EmployeeNo = txtEmployeeNo.Text,
                        LeaveCredit = leaveCredit,
                        RemainingLeaveCredit = remainingLeaveCredit,
                        IsDeleted = 0
                    };
                    InsertLeaveCredits(modelLeaveCredit);

                    var modelSeminar = new Seminar
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
                        InternationalTo = frmSeminarInternational.InternationalSeminarTo,
                        IsDeleted = 0
                    };

                    InsertSeminar(modelSeminar);
                    MessageBox.Show("Employee Information Added!", "Success", MessageBoxButtons.OK,
                            MessageBoxIcon.None);
                    Close();
                }
                else
                {
                    MessageBox.Show("Failed adding employee.", "Failed!", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                }
            }

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
                }
            }
        }

        private void txtContactNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void txtLeaveCredits_KeyPress(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void txtSalaryGrade_KeyPress(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void txtStep_KeyPress(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void txtBSYearGraduated_KeyPress(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void txtMasteralYearGraduated_KeyPress(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void txtDoctoralYearGraduated_KeyPress(object sender, KeyPressEventArgs e)
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
                errorProvider1.SetError(txtEmployeeNo, "Employee No should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtEmployeeNo, "");
            }
        }

        private void txtFirstName_Validating(object sender, CancelEventArgs e)
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

        private void txtLastName_Validating(object sender, CancelEventArgs e)
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

        private void txtAddress_Validating(object sender, CancelEventArgs e)
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

        private void cmbGender_Validating(object sender, CancelEventArgs e)
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

        private void txtPlaceofBirth_Validating(object sender, CancelEventArgs e)
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

        private void txtContactNo_Validating(object sender, CancelEventArgs e)
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

        private void cmbCivilStatus_Validating(object sender, CancelEventArgs e)
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

        private void cmbDegree_Validating(object sender, CancelEventArgs e)
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

        private void cmbEmployeeType_Validating(object sender, CancelEventArgs e)
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

        private void cmbPosition_Validating(object sender, CancelEventArgs e)
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

        private void txtUniqueItemNo_Validating(object sender, CancelEventArgs e)
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

        private void txtSalaryGrade_Validating(object sender, CancelEventArgs e)
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

        private void txtStep_Validating(object sender, CancelEventArgs e)
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

        private void cmbDepartment_Validating(object sender, CancelEventArgs e)
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

        private void cmbWorkStatus_Validating(object sender, CancelEventArgs e)
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

        private void txtLeaveCredits_Validating(object sender, CancelEventArgs e)
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

        private void cmbDegree_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearGroupControls(grpBS);
            ClearGroupControls(grpMasteral);
            ClearGroupControls(grpDoctoral);
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
    }
}
