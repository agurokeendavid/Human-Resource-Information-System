using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static HRISCapsu.Repository.EmployeeRepository;


namespace HRISCapsu
{
    public partial class frmEmployeesOnLeave : Form
    {
        private string _employeeType;
        private readonly string[] arrayMessage = new string[20];
        private readonly SerialPort sp = new SerialPort();
        private double arrayCount;
        private string inputMessage;
        private string message_start = "";
        public frmEmployeesOnLeave(string employeeType)
        {
            InitializeComponent();
            _employeeType = employeeType;
            if (_employeeType == "Academic")
            {
                btnModemPort.Visible = false;
                btnSend.Visible = false;
                BindAcademicEmployeesOnLeaveInGridView();
                dtgRecords.Columns[0].HeaderText = "Name";
                dtgRecords.Columns[1].HeaderText = "Leave Credits";
                dtgRecords.Columns[2].HeaderText = "Remaining Leave Credits";
            }
            else if (_employeeType == "Non - Academic")
            {
                btnModemPort.Visible = true;
                btnSend.Visible = true;
                BindNonAcademicEmployeesOnLeaveInGridView();
                dtgRecords.Columns[0].HeaderText = "Name";
                dtgRecords.Columns[1].HeaderText = "Contact No.";
                dtgRecords.Columns[2].HeaderText = "Leave Started";
                dtgRecords.Columns[2].DefaultCellStyle.Format = "MMMMM dd, yyyy";
                dtgRecords.Columns[3].HeaderText = "Leave End";
                dtgRecords.Columns[3].DefaultCellStyle.Format = "MMMMM dd, yyyy";
            }
        }
        private void BindAcademicEmployeesOnLeaveInGridView()
        {
            using (var dt = new DataTable())
            {
                GetAcademicEmployeesOnLeave(txtEmployeeName.Text, 0, dt);
                dtgRecords.DataSource = dt;
            }

        }

        private void BindNonAcademicEmployeesOnLeaveInGridView()
        {
            using (var dt = new DataTable())
            {
                GetNonAcademicEmployeesOnLeave(txtEmployeeName.Text, 0, dt);
                dtgRecords.DataSource = dt;
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmEmployeesOnLeave_Load(object sender, EventArgs e)
        {

        }

        private void txtEmployeeName_TextChanged(object sender, EventArgs e)
        {
            if (_employeeType == "Academic")
            {
                BindAcademicEmployeesOnLeaveInGridView();
            }
            else if (_employeeType == "Non - Academic")
            {
                BindNonAcademicEmployeesOnLeaveInGridView();
            }
        }

        private void SendStartMessage(string phoneNumber, string s_message)
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

                int d = 1;


                try
                {
                    string x = "";

                    double m = arrayCount + 1;

                    new ManualResetEvent(false).WaitOne(500);

                    sp.Write("AT+CMGS=\"" + phoneNumber + "\"" + Environment.NewLine);

                    new ManualResetEvent(false).WaitOne(500);
                    sp.ReadExisting();
                    sp.Write(x);

                    if (inputMessage.Length < 1)
                    {
                        sp.Write(s_message);
                    }
                    else
                    {
                        sp.Write("1" + "/" + m + " " + s_message);
                    }

                    new ManualResetEvent(false).WaitOne(500);
                    sp.ReadExisting();
                    sp.Write(x);

                    sp.Write(new byte[] { 26 }, 0, 1);
                    new ManualResetEvent(false).WaitOne(8000);
                    sp.ReadExisting();
                    sp.Write(x);


                    string response = sp.ReadExisting();


                    if (response.Contains("ERROR"))
                    {
                        Resend(phoneNumber, s_message, 1);
                    }
                    else
                    {
                        d += 1;
                    }
                }
                catch (Exception)
                {
                    Resend(phoneNumber, s_message, 1);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            sp.Close();
        }


        private void Resend(string num, string message, int count)
        {
            MessageBox.Show("resending..");

            string x = "";


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

        private void SendMessage(string phoneNumber)
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

                int d = 1;

                for (int i = 0; i < arrayCount; i++)
                {
                    try
                    {
                        string x = "";
                        int z = i + 2;

                        double m = arrayCount + 1;

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


                        string response = sp.ReadExisting();


                        if (response.Contains("ERROR"))
                        {
                            Resend(phoneNumber, arrayMessage[i], i);
                        }
                        else
                        {
                            d += 1;
                        }
                    }
                    catch (Exception)
                    {
                        Resend(phoneNumber, arrayMessage[i], i);
                    }
                }

                MessageBox.Show("Message Sent!");
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            sp.Close();
        }

        private void Message(string phoneNumber)
        {
            string intro = "Capiz State University Pontevedra Campus: ";
            string bodyMessage = "Message here";
            if (bodyMessage.Length < 135)
            {
                string message_start_substring = bodyMessage.Substring(0);
                message_start = intro + message_start_substring;
                inputMessage = "";
            }
            else
            {
                string message_start_substring = bodyMessage.Substring(0, 135);

                message_start = intro + message_start_substring;

                int start_index = 0;


                for (int w = 1; w < 30; w++)
                {
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
                SendStartMessage(phoneNumber, message_start);
            }
            else
            {
                try
                {
                    int textLimit = 155;


                    double x = inputMessage.Length;

                    arrayCount = x / 155.00;

                    if (arrayCount <= 1)
                    {
                        arrayCount = 1;
                    }
                    else if (arrayCount > 1 && arrayCount <= 2)
                    {
                        arrayCount = 2;
                    }
                    else if (arrayCount > 2 && arrayCount <= 3)
                    {
                        arrayCount = 3;
                    }
                    else if (arrayCount > 3 && arrayCount <= 4)
                    {
                        arrayCount = 4;
                    }
                    else if (arrayCount > 4 && arrayCount <= 5)
                    {
                        arrayCount = 5;
                    }
                    else if (arrayCount > 5 && arrayCount <= 6)
                    {
                        arrayCount = 6;
                    }
                    else if (arrayCount > 6 && arrayCount <= 7)
                    {
                        arrayCount = 7;
                    }
                    else if (arrayCount > 7 && arrayCount <= 8)
                    {
                        arrayCount = 8;
                    }
                    else if (arrayCount > 8 && arrayCount <= 9)
                    {
                        arrayCount = 9;
                    }
                    else if (arrayCount > 9 && arrayCount <= 10)
                    {
                        arrayCount = 10;
                    }

                    int start_subs = 0;
                    int length_subs = 155;
                    int y = start_subs + textLimit;

                    if (inputMessage.Length > textLimit)
                    {
                        int backwards = 0;


                        int loopcount = 0;

                        for (int i = 0; i < 100; i++)
                        {
                            if (start_subs + length_subs > inputMessage.Length)
                            {
                                loopcount++;
                                arrayMessage[i] = inputMessage.Substring(start_subs);
                                string changed = arrayMessage[i];

                                break;
                            }
                            else
                            {
                                loopcount++;


                                arrayMessage[i] = inputMessage.Substring(start_subs, length_subs);

                                string current = arrayMessage[i];

                                for (int w = 1; w < 30; w++)
                                {
                                    if (current[current.Length - w].ToString() != " ")
                                    {
                                    }
                                    else
                                    {
                                        arrayMessage[i] = inputMessage.Substring(start_subs, length_subs - w);

                                        string changed = arrayMessage[i];


                                        start_subs = start_subs + textLimit - w;


                                        backwards = backwards + w;

                                        break;
                                    }
                                }
                            }
                        }

                        MessageBox.Show("total backwards: " + backwards);
                    }
                    else
                    {
                        arrayMessage[0] = inputMessage.Substring(0);
                    }

                    SendStartMessage(phoneNumber, message_start);

                    SendMessage(phoneNumber);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private bool HasModemConnection()
        {
            try
            {
                using (MySqlConnection conn =
                    new MySqlConnection(ConfigurationManager.ConnectionStrings["HRISConnection"].ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT * from ports";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
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

                            string response = sp.ReadExisting();

                            sp.Close();

                            if (response.Contains("ERROR"))
                            {
                                return false;
                            }

                            return true;


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

        private void btnModemPort_Click(object sender, EventArgs e)
        {
            var frm = new frmChooseModem();
            frm.ShowDialog();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (HasModemConnection())
            {
                foreach (DataGridViewRow dataGridViewRow in dtgRecords.Rows)
                {
                    if (DateTime.Now.Date <= Convert.ToDateTime(dataGridViewRow.Cells[3].Value).Date)
                    {
                        double countTotalDays = (Convert.ToDateTime(dataGridViewRow.Cells[3].Value) - Convert.ToDateTime(dataGridViewRow.Cells[2].Value)).TotalDays;
                        if (countTotalDays <= 30)
                        {
                            Message(dataGridViewRow.Cells[1].Value.ToString());
                        }
                    }

                }
            }
        }
    }
}
