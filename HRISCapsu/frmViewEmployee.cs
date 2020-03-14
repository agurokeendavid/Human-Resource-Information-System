using System;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace HRISCapsu
{
    public partial class frmViewEmployee : Form
    {
        private readonly string path;

        public frmViewEmployee(string employeeNo, string firstName, string middleName, string lastName, string address, string gender, string dob, string placeofbirth, string contactNo, string civilStatus, string degree, string bscourse, string bsyeargraduated, string bsschool, string masteralcourse, string masteralyeargraduated, string masteralschool, string doctoralcourse, string doctoralyeargraduated, string doctoralschool, string eligibility, string employeetype, string position, string unique_item_no, string salary_grade, string step, string department, string workstatus, byte[] employeephoto, string documentpath, string hireddate, string endofcontract, string localSeminarName, string localSeminarType, string localFrom, string localTo, string regionalSeminarName, string regionalSeminarType, string regionalFrom, string regionalTo, string nationalSeminarName, string nationalSeminarType, string nationalFrom, string nationalTo, string internationalSeminarName, string internationalSeminarType, string internationalFrom, string internationalTo)
        {
            InitializeComponent();
            lblEmployeeNo.Text = employeeNo;
            lblFirstName.Text = firstName;
            lblMiddleName.Text = middleName;
            lblLastName.Text = lastName;
            lblAddress.Text = address;
            lblGender.Text = gender;
            lblDateofBirth.Text = dob;
            lblPlaceofBirth.Text = placeofbirth;
            lblContactNo.Text = contactNo;
            lblCivilStatus.Text = civilStatus;
            lblDegree.Text = degree;
            lblBSCourse.Text = bscourse;
            lblBSYearGraduated.Text = bsyeargraduated;
            lblBSSchool.Text = bsschool;
            lblMasteralCourse.Text = masteralcourse;
            lblMasteralYearGraduated.Text = masteralyeargraduated;
            lblMasteralSchool.Text = masteralschool;
            lblDoctoralCourse.Text = doctoralcourse;
            lblDoctoralYearGraduated.Text = doctoralyeargraduated;
            lblDoctoralSchool.Text = doctoralschool;
            lblEligibility.Text = eligibility;
            lblEmployeeType.Text = employeetype;
            lblPosition.Text = position;
            lblUniqueItemNo.Text = unique_item_no;
            lblSalaryGrade.Text = salary_grade;
            lblStep.Text = step;
            lblDepartment.Text = department;
            lblWorkStatus.Text = workstatus;
            pictureBox2.Image = ConvertBinaryToImage(employeephoto);
            path = documentpath;
            lblHiredDate.Text = hireddate;
            if (endofcontract != "")
            {
                lblEndofContract.Text = endofcontract;
                lblEndofContract.Visible = true;
                label14.Visible = true;
            }

            lblLocalSeminarName.Text = localSeminarName;
            lblLocalSeminarType.Text = localSeminarType;
            lblLocalSeminarFrom.Text = localFrom;
            lblLocalSeminarTo.Text = localTo;
            lblRegionalSeminarName.Text = regionalSeminarName;
            lblRegionalSeminarType.Text = regionalSeminarType;
            lblRegionalSeminarFrom.Text = regionalFrom;
            lblRegionalSeminarTo.Text = regionalTo;
            lblNationalSeminarName.Text = nationalSeminarName;
            lblNationalSeminarType.Text = nationalSeminarType;
            lblNationalSeminarFrom.Text = nationalFrom;
            lblNationalSeminarTo.Text = nationalTo;
            lblInternationalSeminarName.Text = internationalSeminarName;
            lblInternationalSeminarType.Text = internationalSeminarType;
            lblInternationalFrom.Text = internationalFrom;
            lblInternationalSeminarTo.Text = internationalTo;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAttach_Click(object sender, EventArgs e)
        {
            Process.Start(path);
        }

        private void panelFileInformation_Paint(object sender, PaintEventArgs e)
        {

        }
        Image ConvertBinaryToImage(byte[] data)
        {
            using (var ms = new MemoryStream(data))
            {
                return Image.FromStream(ms);
            }
        }
        private void frmViewEmployee_Load(object sender, EventArgs e)
        {
        }
    }
}