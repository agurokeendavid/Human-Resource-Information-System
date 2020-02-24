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

        public frmViewEmployee(string employeeNo, string firstName, string middleName, string lastName, string address,
            string gender, string dob, string placeofbirth, string contactNo, string civilStatus, string position,
            string department, string workStatus, string hiredDate, string endOfContract, string status, string path, byte[] imageBytes, string degree, string employeeType)
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
            lblPosition.Text = position;
            lblDepartment.Text = department;
            lblWorkStatus.Text = workStatus;
            lblHiredDate.Text = hiredDate;
            lblStatus.Text = status;
            lblDegree.Text = degree;
            lblEmployeeType.Text = employeeType;
            pictureBox2.Image = ConvertBinaryToImage(imageBytes);
            if (endOfContract != "")
            {
                lblEndofContract.Text = endOfContract;
                lblEndofContract.Visible = true;
                label14.Visible = true;
            }

            this.path = path;
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