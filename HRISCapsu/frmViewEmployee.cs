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
            lblAge.Text = (DateTime.Now.Date.Year - DateTime.Parse(dob).Year) + " yrs old.";
            lblDateofBirth.Text = DateTime.Parse(dob).ToString("MMMM dd, yyyy");
            lblPlaceofBirth.Text = placeofbirth;
            lblContactNo.Text = contactNo;
            lblCivilStatus.Text = civilStatus;
            lblDegree.Text = degree;
            lblBSCourse.Text = bscourse != string.Empty ? bscourse : "N/A";
            lblBSYearGraduated.Text = bsyeargraduated != string.Empty ? bsyeargraduated : "N/A";
            lblBSSchool.Text = bsschool != string.Empty ? bsschool : "N/A";
            lblMasteralCourse.Text = masteralcourse != string.Empty ? masteralcourse : "N/A";
            lblMasteralYearGraduated.Text = masteralyeargraduated != string.Empty ? masteralyeargraduated : "N/A";
            lblMasteralSchool.Text = masteralschool != string.Empty ? masteralschool : "N/A";
            lblDoctoralCourse.Text = doctoralcourse != string.Empty ? doctoralschool : "N/A";
            lblDoctoralYearGraduated.Text = doctoralyeargraduated != string.Empty ? doctoralyeargraduated : "N/A";
            lblDoctoralSchool.Text = doctoralschool != string.Empty ? doctoralschool : "N/A";
            lblEligibility.Text = eligibility != string.Empty ? eligibility : "N/A";
            lblEmployeeType.Text = employeetype;
            lblPosition.Text = position;
            lblUniqueItemNo.Text = unique_item_no;
            lblSalaryGrade.Text = salary_grade;
            lblStep.Text = step;
            lblDepartment.Text = department;
            lblWorkStatus.Text = workstatus;
            pictureBox2.Image = ConvertBinaryToImage(employeephoto);
            path = documentpath;
            lblHiredDate.Text = DateTime.Parse(hireddate).ToString("MMMM dd, yyyy");
            lblLocalSeminarName.Text = localSeminarName != string.Empty ? localSeminarName : "N/A";
            lblLocalSeminarType.Text = localSeminarType != string.Empty ? localSeminarType : "N/A";
            lblLocalSeminarFrom.Text = localFrom != string.Empty ? localFrom : "N/A";
            lblLocalSeminarTo.Text = localTo != string.Empty ? localTo : "N/A";
            lblRegionalSeminarName.Text = regionalSeminarName != string.Empty ? regionalSeminarName : "N/A";
            lblRegionalSeminarType.Text = regionalSeminarType != string.Empty ? regionalSeminarType : "N/A";
            lblRegionalSeminarFrom.Text = regionalFrom != string.Empty ? regionalFrom : "N/A";
            lblRegionalSeminarTo.Text = regionalTo != string.Empty ? regionalTo : "N/A";
            lblNationalSeminarName.Text = nationalSeminarName != string.Empty ? nationalSeminarName : "N/A";
            lblNationalSeminarType.Text = nationalSeminarType != string.Empty ? nationalSeminarType : "N/A";
            lblNationalSeminarFrom.Text = nationalFrom != string.Empty ? nationalFrom : "N/A";
            lblNationalSeminarTo.Text = nationalTo != string.Empty ? nationalTo : "N/A";
            lblInternationalSeminarName.Text = internationalSeminarName != string.Empty ? internationalSeminarName : "N/A";
            lblInternationalSeminarType.Text = internationalSeminarType != string.Empty ? internationalSeminarType : "N/A";
            lblInternationalFrom.Text = internationalFrom != string.Empty ? internationalFrom : "N/A";
            lblInternationalSeminarTo.Text = internationalTo != string.Empty ? internationalTo : "N/A";

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