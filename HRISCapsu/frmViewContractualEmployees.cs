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
            lblBSCourse.Text = employee.BsCourse;
            lblBSYearGraduated.Text = employee.BsYearGraduated.ToString();
            lblBSSchool.Text = employee.BsSchool;
            lblMasteralCourse.Text = employee.MasteralCourse;
            lblMasteralYearGraduated.Text = employee.MasteralYearGraduated.ToString();
            lblMasteralSchool.Text = employee.MasteralSchool;
            lblDoctoralCourse.Text = employee.DoctoralCourse;
            lblDoctoralYearGraduated.Text = employee.DoctoralYearGraduated.ToString();
            lblDoctoralSchool.Text = employee.DoctoralSchool;
            lblEligibility.Text = employee.Eligibility;
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
            lblLocalSeminarName.Text = seminar.LocalSeminarName;
            lblLocalSeminarType.Text = seminar.LocalSeminarType;
            lblLocalSeminarFrom.Text = seminar.LocalFrom != null ? seminar.LocalFrom.Value.ToString("MMMM dd, yyyy") : "N/A";
            lblLocalSeminarTo.Text = seminar.LocalTo != null ? seminar.LocalTo.Value.ToString("MMMM dd, yyyy") : "N/A";
            lblRegionalSeminarName.Text = seminar.RegionalSeminarName;
            lblRegionalSeminarType.Text = seminar.RegionalSeminarType;
            lblRegionalSeminarFrom.Text = seminar.RegionalFrom != null ? seminar.RegionalFrom.Value.ToString("MMMM dd, yyyy") : "N/A";
            lblRegionalSeminarTo.Text = seminar.RegionalTo != null ? seminar.RegionalTo.Value.ToString("MMMM dd, yyyy") : "N/A";
            lblNationalSeminarName.Text = seminar.NationalSeminarName;
            lblNationalSeminarType.Text = seminar.NationalSeminarType;
            lblNationalSeminarFrom.Text = seminar.NationalFrom != null ? seminar.NationalFrom.Value.ToString("MMMM dd, yyyy") : "N/A";
            lblNationalSeminarTo.Text = seminar.NationalTo != null ? seminar.NationalTo.Value.ToString("MMMM dd, yyyy") : "N/A";
            lblInternationalSeminarName.Text = seminar.InternationalSeminarName;
            lblInternationalSeminarType.Text = seminar.InternationalSeminarType;
            lblInternationalFrom.Text = seminar.InternationalFrom != null ? seminar.InternationalFrom.Value.ToString("MMMM dd, yyyy") : "N/A";
            lblInternationalSeminarTo.Text = seminar.InternationalTo != null ? seminar.InternationalTo.Value.ToString("MMMM dd, yyyy") : "N/A";

        }

        private void btnAttach_Click(object sender, EventArgs e)
        {
            Process.Start(_path);
        }
    }
}
