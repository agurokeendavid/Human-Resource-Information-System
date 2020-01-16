using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;

namespace HRISCapsu
{
    public partial class frmListofContractualEmployees : Form
    {
        public frmListofContractualEmployees()
        {
            InitializeComponent();
            frmLogin.SendMessage(txtSearch.Handle, 0x1501, 1, "Employee name.");
        }

        private void getModem()
        {
            try
            {
                using (var conn = new MySqlConnection(Classes.DBConnection.conString))
                {
                    conn.Open();
                    var query = "select * from capsuthesis.tblmodems";
                    var cmd = new MySqlCommand(query, conn);
                    var da = new MySqlDataAdapter();
                    var dt = new DataTable();
                    da.SelectCommand = cmd;
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
<<<<<<< HEAD
<<<<<<< HEAD
                        while (reader.Read())
                        {
                            
                            string modemName = reader["port_name"].ToString();
                            sp.PortName = modemName;
                            sp.Open();
                            sp.WriteLine("AT" + Environment.NewLine);
                            Thread.Sleep(200);
                            sp.WriteLine("AT+CMGF=1" + Environment.NewLine);
                            Thread.Sleep(200);
                            sp.WriteLine("AT+CSCS=\"GSM\"" + Environment.NewLine);
                            Thread.Sleep(100);

                            var response = sp.ReadExisting();


                            if (response.Contains("ERROR"))
                            {
                                return false;
                            }
                            else
                            {
                                return true;
                            }

#pragma warning disable CS0162 // Unreachable code detected
                            sp.Close();
#pragma warning restore CS0162 // Unreachable code detected
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        void sendStartMessage(string phoneNumber, string s_message)
        {
            try
            {
                if (sp.IsOpen)
                {
                    sp.Close();
                    sp.Open();

                    sp.DtrEnable = true;
                    sp.RtsEnable = true;
                }
                else
                {
                    sp.Open();

                    sp.DtrEnable = true;
                    sp.RtsEnable = true;
                }

                var d = 1;


                try
                {
                    var x = "";

                    var m = arrayCount + 1;

                    new ManualResetEvent(false).WaitOne(500);
=======
=======
>>>>>>> parent of 98aef7b... Finalized project.
                        //modemEmpty = false;
                        //modemName = dt.Rows[0].Field<string>("modem_name");
                        var sp = new SerialPort();
                        //sp.PortName = modemName;
                        sp.Open();
<<<<<<< HEAD
>>>>>>> parent of 98aef7b... Finalized project.


                        sp.WriteLine("AT" + Environment.NewLine);
                        Thread.Sleep(200);
                        sp.WriteLine("AT+CMGF=1" + Environment.NewLine);
                        Thread.Sleep(200);
                        sp.WriteLine("AT+CSCS=\"GSM\"" + Environment.NewLine);
                        Thread.Sleep(100);

=======


                        sp.WriteLine("AT" + Environment.NewLine);
                        Thread.Sleep(200);
                        sp.WriteLine("AT+CMGF=1" + Environment.NewLine);
                        Thread.Sleep(200);
                        sp.WriteLine("AT+CSCS=\"GSM\"" + Environment.NewLine);
                        Thread.Sleep(100);

>>>>>>> parent of 98aef7b... Finalized project.
                        var response = sp.ReadExisting();


                        //if (response.Contains("ERROR"))
                        //{
                        //    lblHeading.Text = "Send Message [Not connected]";
                        //    lblHeading.ForeColor = Color.Red;
                        //}
                        //else
                        //{
                        //    lblHeading.Text = "Send Message [Connected]";
                        //    lblHeading.ForeColor = Color.Green;
                        //}

                        sp.Close();
                    }
                    else
                    {
                        //modemEmpty = true;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void resend(string num, string message)
        {
            MessageBox.Show("resending..");

            var x = "";
            double arrayCount = 0;

            new ManualResetEvent(false).WaitOne(500);
            using (var sp = new SerialPort())
            {
                sp.Write("AT+CMGS=\"" + num + "\"" + Environment.NewLine);

                new ManualResetEvent(false).WaitOne(500);
                sp.ReadExisting();
                sp.Write(x);

                sp.Write(1 + "/" + arrayCount + " " + message);

                new ManualResetEvent(false).WaitOne(500);
                sp.ReadExisting();
                sp.Write(x);

                sp.Write(new byte[] { 26 }, 0, 1);
                new ManualResetEvent(false).WaitOne(8000);
                sp.ReadExisting();
                sp.Write(x);
            }

        }


        private void sendMessage(string phoneNumber, string s_message)
        {
            using (var sp = new SerialPort())
            {
                try
                {
                    if (sp.IsOpen)
                    {
                        sp.DtrEnable = true;
                        sp.RtsEnable = true;
                    }
                    else
                    {
                        sp.Open();
                        sp.DtrEnable = true;
                        sp.RtsEnable = true;
                    }

                    var x = "";
                    double arrayCount = 0;
                    var m = arrayCount + 1;

                    new ManualResetEvent(false).WaitOne(500);
                    sp.Write("AT+CMGS=\"" + phoneNumber + "\"" + Environment.NewLine);
                    new ManualResetEvent(false).WaitOne(500);
                    sp.ReadExisting();
                    sp.Write(x);
<<<<<<< HEAD

                    sp.Write("1" + "/" + m + " " + s_message);

                    new ManualResetEvent(false).WaitOne(500);
                    sp.ReadExisting();
                    sp.Write(x);

                    sp.Write(new byte[] { 26 }, 0, 1);
                    new ManualResetEvent(false).WaitOne(8000);
                    sp.ReadExisting();
                    sp.Write(x);


=======

                    sp.Write("1" + "/" + m + " " + s_message);

                    new ManualResetEvent(false).WaitOne(500);
                    sp.ReadExisting();
                    sp.Write(x);

                    sp.Write(new byte[] { 26 }, 0, 1);
                    new ManualResetEvent(false).WaitOne(8000);
                    sp.ReadExisting();
                    sp.Write(x);


>>>>>>> parent of 98aef7b... Finalized project.
                    var response = sp.ReadExisting();


                }
                catch (Exception ex)
                {
                    resend(phoneNumber, s_message);
                }
            }
        }

        void displayRecords(DataGridView gridView, string keyword)
        {
            try
            {
                using (var conn = new MySqlConnection(Classes.DBConnection.conString))
                {
                    conn.Open();
                    string query = @"SELECT emp.employee_no, emp.first_name, emp.middle_name, emp.last_name, emp.address, emp.gender, date_format(emp.date_of_birth, '%M %d, %Y') AS 'Date of Birth', emp.place_of_birth, emp.contact_no, emp.civil_status, pos.position_name, dept.department_name, emp.work_status, date_format(emp.hired_date, '%M %d, %Y') AS 'Hired Date', date_format(emp.end_of_contract, '%M %d, %Y') AS 'End of Contract' FROM employees emp INNER JOIN positions pos ON emp.position_id = pos.position_id INNER JOIN departments dept ON emp.department_id = dept.department_id WHERE (emp.first_name LIKE @keyword OR emp.middle_name LIKE @keyword OR emp.last_name LIKE @keyword) AND (emp.work_status = 'Contractual') AND (emp.status = 'Active')";
                    var cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("keyword", '%' + keyword + '%');
                    var da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;
                    var dt = new DataTable();
                    da.Fill(dt);

                    gridView.DataSource = dt;

                    gridView.Columns[0].HeaderText = "Employee No.";
                    gridView.Columns[1].HeaderText = "First Name";
                    gridView.Columns[2].HeaderText = "Middle Name";
                    gridView.Columns[3].HeaderText = "Last Name";
                    gridView.Columns[4].HeaderText = "Address";
                    gridView.Columns[5].HeaderText = "Gender";
                    gridView.Columns[6].Visible = true;
                    gridView.Columns[7].Visible = false;
                    gridView.Columns[8].Visible = false;
                    gridView.Columns[9].Visible = false;
                    gridView.Columns[10].HeaderText = "Position";
                    gridView.Columns[11].HeaderText = "Department";
                    gridView.Columns[12].HeaderText = "Work Status";
                    gridView.Columns[13].HeaderText = "Hired Date";
                    gridView.Columns[14].HeaderText = "End of Contract";

                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataGridViewRow dataGridViewRow in dtgRecords.Rows)
                        {
                            DateTime hiredDate = Convert.ToDateTime(dataGridViewRow.Cells[13].Value);
                            DateTime endOfContract = Convert.ToDateTime(dataGridViewRow.Cells[14].Value);
                            double expiredContract = (endOfContract - DateTime.Now.Date).TotalDays;
                            if (expiredContract >= 1 && expiredContract <= 30)
                            {
                                dataGridViewRow.DefaultCellStyle.BackColor = Color.Red;
                                dataGridViewRow.DefaultCellStyle.ForeColor = Color.White;

                            }
                        }
                    }
                    else
                        MessageBox.Show("No data found!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            displayRecords(dtgRecords, txtSearch.Text);

        }

        private void frmListofContractualEmployees_Load(object sender, EventArgs e)
        {
            displayRecords(dtgRecords, txtSearch.Text);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {

        }
    }
}
