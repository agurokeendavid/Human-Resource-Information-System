using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRISCapsu
{
    public partial class frmViewEmployee : Form
    {
        public frmViewEmployee(string employeeNo, string firstName, string middleName, string lastName, string address, string gender, string dob, string placeofbirth, string contactNo, string civilStatus, string position, string department, string workStatus, string hiredDate, string endOfContract)
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
            if (endOfContract != "")
            {
                lblEndofContract.Text = endOfContract;
                lblEndofContract.Visible = true;
                label14.Visible = true;
            }
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
