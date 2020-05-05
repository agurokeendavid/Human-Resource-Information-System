using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;
using HRISCapsu.ReportPreviewer;

namespace HRISCapsu
{
    public partial class frmListofContractualEmployees : Form
    {
        private readonly string[] arrayMessage = new string[20];
        private readonly SerialPort sp = new SerialPort();
        private double arrayCount;
        private string inputMessage;
        private string message_start = "";
        private string employeeType;

        public frmListofContractualEmployees(string employeeType)
        {
            InitializeComponent();
            this.employeeType = employeeType;
            frmLogin.SendMessage(txtSearch.Handle, 0x1501, 1, "Employee name.");
        }

        private bool hasModemConnection()
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

        private void sendStartMessage(string phoneNumber, string s_message)
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
                        resend(phoneNumber, s_message, 1);
                    }
                    else
                    {
                        d += 1;
                    }
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


        private void resend(string num, string message, int count)
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

        private void sendMessage(string phoneNumber)
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
                            resend(phoneNumber, arrayMessage[i], i);
                        }
                        else
                        {
                            d += 1;
                        }
                    }
                    catch (Exception)
                    {
                        resend(phoneNumber, arrayMessage[i], i);
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


        private void message(string phoneNumber)
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
                sendStartMessage(phoneNumber, message_start);
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

                    sendStartMessage(phoneNumber, message_start);

                    sendMessage(phoneNumber);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void displayRecords(DataGridView gridView, string keyword)
        {
            try
            {
                using (MySqlConnection conn =
                    new MySqlConnection(ConfigurationManager.ConnectionStrings["HRISConnection"].ConnectionString))
                {
                    conn.Open();
                    string query = @"SELECT emp.employee_no, emp.first_name, emp.middle_name, emp.last_name, emp.address, emp.gender, date_format(emp.date_of_birth, '%M %d, %Y') AS DateOfBirth, emp.place_of_birth, emp.contact_no, emp.civil_status, emp.highest_degree, emp.bs_course, emp.bs_year_graduated, emp.bs_school, emp.masteral_course, emp.masteral_year_graduated, emp.masteral_school, emp.doctoral_course, emp.doctoral_year_graduated, emp.doctoral_school, emp.eligibility, emp.employee_type, emp.position, emp.department, emp.work_status, employee_photo, emp.documentpath, date_format(emp.hired_date, '%M %d, %Y') AS HiredDate, date_format(emp.end_of_contract, '%M %d, %Y') AS EndOfContract FROM employees emp WHERE emp.last_name LIKE @keyword AND emp.work_status = @work_status AND emp.is_deleted = @is_deleted AND emp.employee_type = @employee_type ORDER BY emp.last_name ASC;";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("keyword", '%' + keyword + '%');
                    cmd.Parameters.AddWithValue("work_status", "Contractual");
                    cmd.Parameters.AddWithValue("is_deleted", 0);
                    cmd.Parameters.AddWithValue("employee_type", employeeType);
                    MySqlDataAdapter da = new MySqlDataAdapter
                    {
                        SelectCommand = cmd
                    };
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    gridView.DataSource = dt;

                    gridView.Columns[0].HeaderText = "Employee No.";
                    gridView.Columns[1].HeaderText = "First Name";
                    gridView.Columns[2].HeaderText = "Middle Name";
                    gridView.Columns[3].HeaderText = "Last Name";
                    gridView.Columns[4].HeaderText = "Address";
                    gridView.Columns[5].HeaderText = "Gender";
                    gridView.Columns[6].Visible = false;
                    gridView.Columns[7].Visible = false;
                    gridView.Columns[8].Visible = false;
                    gridView.Columns[9].Visible = false;
                    gridView.Columns[10].HeaderText = "Highest Degree";
                    gridView.Columns[11].Visible = false;
                    gridView.Columns[12].Visible = false;
                    gridView.Columns[13].Visible = false;
                    gridView.Columns[14].Visible = false;
                    gridView.Columns[15].Visible = false;
                    gridView.Columns[16].Visible = false;
                    gridView.Columns[17].Visible = false;
                    gridView.Columns[18].Visible = false;
                    gridView.Columns[19].Visible = false;
                    gridView.Columns[20].Visible = false;
                    gridView.Columns[21].HeaderText = "Employee Type";
                    gridView.Columns[22].HeaderText = "Position";
                    gridView.Columns[23].HeaderText = "Department";
                    gridView.Columns[24].HeaderText = "Employee Status";
                    gridView.Columns[25].Visible = false;
                    gridView.Columns[26].Visible = false;
                    gridView.Columns[27].HeaderText = "Date Hired";
                    gridView.Columns[28].HeaderText = "End of Contract";

                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataGridViewRow dataGridViewRow in dtgRecords.Rows)
                        {
                            DateTime hiredDate = Convert.ToDateTime(dataGridViewRow.Cells[27].Value);
                            DateTime endOfContract = Convert.ToDateTime(dataGridViewRow.Cells[28].Value);
                            double expiredContract = (endOfContract - DateTime.Now.Date).TotalDays;
                            if (expiredContract >= 1 && expiredContract <= 30)
                            {
                                dataGridViewRow.DefaultCellStyle.BackColor = Color.Red;
                                dataGridViewRow.DefaultCellStyle.ForeColor = Color.White;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
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
            if (hasModemConnection())
            {
                foreach (DataGridViewRow dataGridViewRow in dtgRecords.Rows)
                {
                    DateTime endOfContract = Convert.ToDateTime(dataGridViewRow.Cells[28].Value);
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
            
            if (employeeType == "Academic")
            {
               var frm = new previewContractualAcademicEmployees();
               frm.ShowDialog();
            }
            else if (employeeType == "Non - Academic")
            {
                var frm = new previewContractualNonAcademicEmployees();
                frm.ShowDialog();
            }
            
        }

        private void btnModemPort_Click(object sender, EventArgs e)
        {
            frmChooseModem frm = new frmChooseModem();
            frm.ShowDialog();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            var frm = new frmViewContractualEmployees(dtgRecords.CurrentRow.Cells[0].Value.ToString());
            frm.ShowDialog();
        }
    }
}