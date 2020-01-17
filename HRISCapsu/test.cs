using System;
using System.Windows.Forms;

namespace HRISCapsu
{
    public partial class test : Form
    {
        public test()
        {
            InitializeComponent();
        }

        private void btnDeduct_Click(object sender, EventArgs e)
        {
            DateTime userDate = dateTimePicker1.Value.Date;
            DateTime currentDate = DateTime.Now.Date;
            TimeSpan timeSpan = userDate.Subtract(currentDate);
            double a = (currentDate - userDate).TotalDays;
            MessageBox.Show(a.ToString());
        }
    }
}