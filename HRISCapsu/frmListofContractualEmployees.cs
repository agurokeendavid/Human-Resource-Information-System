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
        double arrayCount;
        readonly string[] arrayMessage = new string[20];
        string inputMessage;
        string message_start = "";
        readonly SerialPort sp = new SerialPort();
        public frmListofContractualEmployees()
        {
            InitializeComponent();
            frmLogin.SendMessage(txtSearch.Handle, 0x1501, 1, "Employee name.");
        }

        bool hasModemConnection()
        {
            try
            {
                using (var conn = new MySqlConnection(Classes.DBConnection.conString))
                {
                    conn.Open();
                    string query = "SELECT * from ports";
                    var cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
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

                    sp.Write("AT+CMGS=\"" + phoneNumber + "\"" + Environment.NewLine);

                    new ManualResetEvent(false).WaitOne(500);
                    sp.ReadExisting();
                    sp.Write(x);

                    if (inputMessage.Length < 1)
                        sp.Write(s_message);
                    else
                        sp.Write("1" + "/" + m + " " + s_message);


                    new ManualResetEvent(false).WaitOne(500);
                    sp.ReadExisting();
                    sp.Write(x);

                    sp.Write(new byte[] { 26 }, 0, 1);
                    new ManualResetEvent(false).WaitOne(8000);
                    sp.ReadExisting();
                    sp.Write(x);


                    var response = sp.ReadExisting();


                    if (response.Contains("ERROR"))
                        resend(phoneNumber, s_message, 1);
                    else
                        d += 1;
                }
                catch (Exception)
                {
                    resend(phoneNumber, s_message, 1);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            sp.Close();
        }


        void resend(string num, string message, int count)
        {
            MessageBox.Show("resending..");

            var x = "";


            new ManualResetEvent(false).WaitOne(500);

            sp.Write("AT+CMGS=\"" + num + "\"" + Environment.NewLine);

            new ManualResetEvent(false).WaitOne(500);
            sp.ReadExisting();
            sp.Write(x);

            sp.Write(count + "/" + arrayCount + " " + message);

            new ManualResetEvent(false).WaitOne(500);
            sp.ReadExisting();
            sp.Write(x);

            sp.Write(new byte[] { 26 }, 0, 1);
            new ManualResetEvent(false).WaitOne(8000);
            sp.ReadExisting();
            sp.Write(x);
        }

        void sendMessage(string phoneNumber)
        {
            try
            {
                if (sp.IsOpen)
                {
                    sp.Close();
                    sp.Open();

                    sp.DtrEnable = true; // Data-terminal-ready
                    sp.RtsEnable = true; // Request-to-send
                }
                else
                {
                    sp.Open();

                    sp.DtrEnable = true; // Data-terminal-ready
                    sp.RtsEnable = true; // Request-to-send
                }

                var d = 1;

                for (var i = 0; i < arrayCount; i++)
                    try
                    {
                        var x = "";
                        var z = i + 2;

                        var m = arrayCount + 1;

                        new ManualResetEvent(false).WaitOne(500);

                        sp.Write("AT+CMGS=\"" + phoneNumber + "\"" + Environment.NewLine);

                        new ManualResetEvent(false).WaitOne(500);
                        sp.ReadExisting();
                        sp.Write(x);

                        sp.Write(z + "/" + m + " " + arrayMessage[i]);

                        new ManualResetEvent(false).WaitOne(500);
                        sp.ReadExisting();
                        sp.Write(x);

                        sp.Write(new byte[] { 26 }, 0, 1);
                        new ManualResetEvent(false).WaitOne(8000);
                        sp.ReadExisting();
                        sp.Write(x);


                        var response = sp.ReadExisting();


                        if (response.Contains("ERROR"))
                            resend(phoneNumber, arrayMessage[i], i);
                        else
                            d += 1;
                    }
                    catch (Exception)
                    {
                        resend(phoneNumber, arrayMessage[i], i);
                    }

                MessageBox.Show("Message Sent!");
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            sp.Close();
        }


        void message(string phoneNumber)
        {
            var intro = "Capiz State University Pontevedra Campus: ";
            var bodyMessage = "Message here";
            if (bodyMessage.Length < 135)
            {
                var message_start_substring = bodyMessage.Substring(0);
                message_start = intro + message_start_substring;
                inputMessage = "";
            }
            else
            {
                var message_start_substring = bodyMessage.Substring(0, 135);

                message_start = intro + message_start_substring;

                var start_index = 0;


                for (var w = 1; w < 30; w++)
                    if (message_start[message_start.Length - w].ToString() != " ")
                    {
                    }
                    else
                    {
                        message_start = message_start.Substring(start_index, 155 - w);

                        inputMessage = bodyMessage.Substring(135 - w);

                        break;
                    }
            }


            if (inputMessage.Length > 1550)
            {
                MessageBox.Show(
                    "Message too long. " + bodyMessage.Length +
                    " total characters. Only 1550 total characters allowed.", "Message", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else if (inputMessage.Length < 1)
            {
                sendStartMessage(phoneNumber, message_start);

            }
            else
            {
                try
                {
                    var textLimit = 155;


                    double x = inputMessage.Length;

                    arrayCount = x / 155.00;

                    if (arrayCount <= 1)
                        arrayCount = 1;
                    else if (arrayCount > 1 && arrayCount <= 2)
                        arrayCount = 2;
                    else if (arrayCount > 2 && arrayCount <= 3)
                        arrayCount = 3;
                    else if (arrayCount > 3 && arrayCount <= 4)
                        arrayCount = 4;
                    else if (arrayCount > 4 && arrayCount <= 5)
                        arrayCount = 5;
                    else if (arrayCount > 5 && arrayCount <= 6)
                        arrayCount = 6;
                    else if (arrayCount > 6 && arrayCount <= 7)
                        arrayCount = 7;
                    else if (arrayCount > 7 && arrayCount <= 8)
                        arrayCount = 8;
                    else if (arrayCount > 8 && arrayCount <= 9)
                        arrayCount = 9;
                    else if (arrayCount > 9 && arrayCount <= 10) arrayCount = 10;

                    var start_subs = 0;
                    var length_subs = 155;
                    var y = start_subs + textLimit;

                    if (inputMessage.Length > textLimit)
                    {
                        var backwards = 0;


                        var loopcount = 0;

                        for (var i = 0; i < 100; i++)
                            if (start_subs + length_subs > inputMessage.Length)
                            {
                                loopcount++;
                                arrayMessage[i] = inputMessage.Substring(start_subs);
                                var changed = arrayMessage[i];

                                break;
                            }
                            else
                            {
                                loopcount++;


                                arrayMessage[i] = inputMessage.Substring(start_subs, length_subs);

                                var current = arrayMessage[i];

                                for (var w = 1; w < 30; w++)
                                    if (current[current.Length - w].ToString() != " ")
                                    {
                                    }
                                    else
                                    {
                                        arrayMessage[i] = inputMessage.Substring(start_subs, length_subs - w);

                                        var changed = arrayMessage[i];


                                        start_subs = start_subs + textLimit - w;


                                        backwards = backwards + w;

                                        break;
                                    }
                            }

                        MessageBox.Show("total backwards: " + backwards);
                    }
                    else
                    {
                        arrayMessage[0] = inputMessage.Substring(0);
                    }

                    sendStartMessage(phoneNumber, message_start);

                    sendMessage(phoneNumber);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    gridView.Columns[8].HeaderText = "Contact No.";
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
                        MessageBox.Show("No data found!", "Not found",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (hasModemConnection() == true)
            {
                foreach (DataGridViewRow dataGridViewRow in dtgRecords.Rows)
                {
                    DateTime hiredDate = Convert.ToDateTime(dataGridViewRow.Cells[13].Value);
                    DateTime endOfContract = Convert.ToDateTime(dataGridViewRow.Cells[14].Value);
                    double expiredContract = (endOfContract - DateTime.Now.Date).TotalDays;
                    if (expiredContract >= 1 && expiredContract <= 30)
                    {
                        message(dataGridViewRow.Cells[8].Value.ToString());
                    }
                    
                }
            }
            
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            var frm = new ReportViewer.frmContractualEmployeesReport();
            frm.ShowDialog();
        }

        private void btnModemPort_Click(object sender, EventArgs e)
        {
            var frm = new frmChooseModem();
            frm.ShowDialog();
        }
    }
}
