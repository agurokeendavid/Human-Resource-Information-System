using HRISCapsu.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HRISCapsu.Repository.EmployeeRepository;
using static HRISCapsu.Repository.ListOfSeminarRepository;

namespace HRISCapsu
{
    public partial class frmViewContractualEmployees : Form
    {
        private string _employeeNo;
        private string _path;
        public frmViewContractualEmployees(string employeeNo)
        {
            InitializeComponent();
            _employeeNo = employeeNo;
        }
        Image ConvertBinaryToImage(byte[] data)
        {
            using (var ms = new MemoryStream(data))
            {
                return Image.FromStream(ms);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmViewContractualEmployees_Load(object sender, EventArgs e)
        {
            var employee = GetSingleEmployee(_employeeNo);
            lblEmployeeNo.Text = employee.EmployeeNo;
            lblFirstName.Text = employee.FirstName;
            lblMiddleName.Text = employee.MiddleName;
            lblLastName.Text = employee.LastName;
            lblAddress.Text = employee.Address;
            lblGender.Text = employee.Gender;
            lblDateofBirth.Text = employee.DateOfBirth.ToString("MMMM dd, yyyy");
            lblPlaceofBirth.Text = employee.PlaceOfBirth;
            lblContactNo.Text = employee.ContactNo;
            lblCivilStatus.Text = employee.CivilStatus;
            lblDegree.Text = employee.HighestDegree;
            lblBSCourse.Text = employee.BsCourse != string.Empty ? employee.BsCourse : "N/A";
            lblBSYearGraduated.Text = employee.BsYearGraduated != string.Empty ? employee.BsYearGraduated : "N/A";
            lblBSSchool.Text = employee.BsSchool != string.Empty ? employee.BsSchool : "N/A";
            lblMasteralCourse.Text = employee.MasteralCourse != string.Empty ? employee.MasteralCourse : "N/A";
            lblMasteralYearGraduated.Text = employee.MasteralYearGraduated != string.Empty ? employee.MasteralYearGraduated : "N/A";
            lblMasteralSchool.Text = employee.MasteralSchool != string.Empty ? employee.MasteralSchool : "N/A";
            lblDoctoralCourse.Text = employee.DoctoralCourse != string.Empty ? employee.DoctoralCourse : "N/A";
            lblDoctoralYearGraduated.Text = employee.DoctoralYearGraduated != string.Empty ? employee.DoctoralYearGraduated : "N/A";
            lblDoctoralSchool.Text = employee.DoctoralSchool != string.Empty ? employee.DoctoralSchool : "N/A";
            lblEligibility.Text = employee.Eligibility != string.Empty ? employee.Eligibility : "N/A";
            lblPosition.Text = employee.Position;
            lblUniqueItemNo.Text = employee.UniqueItemNo;
            lblSalaryGrade.Text = employee.SalaryGrade.ToString();
            lblStep.Text = employee.Step.ToString();
            lblDepartment.Text = employee.Department;
            lblWorkStatus.Text = employee.WorkStatus;
            lblEmployeeType.Text = employee.EmployeeType;
            lblHiredDate.Text = employee.HiredDate.ToString("MMMM dd, yyyy");
            lblEndofContract.Text = employee.EndOfContract != null ? employee.EndOfContract.Value.ToString("MMMM dd, yyyy") : "N/A";
            pictureBox2.Image = ConvertBinaryToImage(employee.EmployeePhoto);
            _path = employee.DocumentPath;
            var seminar = GetSingleSeminar(_employeeNo);
            lblLocalSeminarName.Text = seminar.LocalSeminarName != string.Empty ? seminar.LocalSeminarName : "N/A";
            lblLocalSeminarType.Text = seminar.LocalSeminarType != string.Empty ? seminar.LocalSeminarType : "N/A";
            lblLocalSeminarFrom.Text = seminar.LocalFrom != null ? seminar.LocalFrom.Value.ToString("MMMM dd, yyyy") : "N/A";
            lblLocalSeminarTo.Text = seminar.LocalTo != null ? seminar.LocalTo.Value.ToString("MMMM dd, yyyy") : "N/A";
            lblRegionalSeminarName.Text = seminar.RegionalSeminarName != string.Empty ? seminar.RegionalSeminarName : "N/A";
            lblRegionalSeminarType.Text = seminar.RegionalSeminarType != string.Empty ? seminar.RegionalSeminarType : "N/A";
            lblRegionalSeminarFrom.Text = seminar.RegionalFrom != null ? seminar.RegionalFrom.Value.ToString("MMMM dd, yyyy") : "N/A";
            lblRegionalSeminarTo.Text = seminar.RegionalTo != null ? seminar.RegionalTo.Value.ToString("MMMM dd, yyyy") : "N/A";
            lblNationalSeminarName.Text = seminar.NationalSeminarName != string.Empty ? seminar.NationalSeminarName : "N/A";
            lblNationalSeminarType.Text = seminar.NationalSeminarType != string.Empty ? seminar.NationalSeminarType : "N/A";
            lblNationalSeminarFrom.Text = seminar.NationalFrom != null ? seminar.NationalFrom.Value.ToString("MMMM dd, yyyy") : "N/A";
            lblNationalSeminarTo.Text = seminar.NationalTo != null ? seminar.NationalTo.Value.ToString("MMMM dd, yyyy") : "N/A";
            lblInternationalSeminarName.Text = seminar.InternationalSeminarName != string.Empty ? seminar.InternationalSeminarName : "N/A";
            lblInternationalSeminarType.Text = seminar.InternationalSeminarType != string.Empty ? seminar.InternationalSeminarType : "N/A";
            lblInternationalFrom.Text = seminar.InternationalFrom != null ? seminar.InternationalFrom.Value.ToString("MMMM dd, yyyy") : "N/A";
            lblInternationalSeminarTo.Text = seminar.InternationalTo != null ? seminar.InternationalTo.Value.ToString("MMMM dd, yyyy") : "N/A";

        }

        private void btnAttach_Click(object sender, EventArgs e)
        {
            Process.Start(_path);
        }
    }
}
