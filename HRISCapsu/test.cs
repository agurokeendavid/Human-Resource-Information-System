using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace HRISCapsu
{
    public partial class test : Form
    {

        BackgroundWorker worker = new BackgroundWorker();
        string pathname;
        public test()
        {
            InitializeComponent();
            worker.WorkerSupportsCancellation = true;
            worker.WorkerReportsProgress = true;

            worker.ProgressChanged += worker_ProgressChanged;
            worker.DoWork += Worker_DoWork;
        }

        void copyFile(string source, string des)
        {
            FileStream fsout = new FileStream(des, FileMode.Create);
            FileStream fsin = new FileStream(source, FileMode.Open);
            byte[] bt = new byte[1048756];

            int readByte;

            while ((readByte = fsin.Read(bt, 0, bt.Length)) > 0)
            {
                fsout.Write(bt, 0, readByte);
                worker.ReportProgress((int)(fsin.Position * 100 / fsin.Length));
            }
            fsin.Close();
            fsout.Close();
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            copyFile(txtSource.Text, txtTarget.Text);
        }

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            label3.Text = progressBar1.Value.ToString() + "%";
        }

        private void btnDeduct_Click(object sender, EventArgs e)
        {
            DateTime userDate = dateTimePicker1.Value.Date;
            DateTime currentDate = DateTime.Now.Date;
            TimeSpan timeSpan = userDate.Subtract(currentDate);
            double a = (currentDate - userDate).TotalDays;
            MessageBox.Show(a.ToString());
        }
        

        private void openPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                if (!Directory.Exists("files"))
                {
                    Directory.CreateDirectory("files");
                    
                    MessageBox.Show("Created");
                }
                else
                {
                    MessageBox.Show("Not created");
                }
            }
            catch (Exception ex)
            {

            }
            string path = Environment.CurrentDirectory + @"\files\DocumentTextMerge1.pdf";
            Process.Start(path);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //openFileDialog1.InitialDirectory = "C://Desktop";
            //openFileDialog1.Title = "Select file to be upload.";
            //openFileDialog1.Filter = "Select Valid Document(*.pdf; *.doc; *.xlsx; *.html)|*.pdf; *.docx; *.xlsx; *.html";
            //openFileDialog1.FilterIndex = 1;
            //openFileDialog1.FileName = "";
            //try
            //{
            //    if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //    {
            //        if (openFileDialog1.CheckFileExists)
            //        {
            //            string path = System.IO.Path.GetFullPath(openFileDialog1.FileName);
            //            label2.Text = path;
            //            File.Create(openFileDialog1.FileName);
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("Please Upload document.");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //File.Copy(openFileDialog1.FileName, "D:\\Keen\\Documents\\");
            //MessageBox.Show(openFileDialog1.FileName);
            OpenFileDialog openFileDialog = sender as OpenFileDialog;
            //OpenFileDialog o = new OpenFileDialog();
            //if (o.ShowDialog() == DialogResult.OK)
            //    pathname = o.FileName;
            copyFile(openFileDialog1.FileName, "D:\\");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string filename = System.IO.Path.GetFileName(openFileDialog1.FileName);
                if (filename == null)
                {
                    MessageBox.Show("Please select a valid document.");
                }
                else
                {
                    using (var conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["HRISConnection"].ConnectionString))
                    {
                        conn.Open();
                        var cmd = new MySqlCommand("insert into test (documentpath)values('\\Document\\" + filename + "')", conn);
                        string path = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
                        //System.IO.File.Copy(openFileDialog1.FileName, Environment.CurrentDirectory + @"\files\" + filename);
                        File.Copy(filename, "D:\\Keen\\Documents\\pdfsample\\" + filename);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Document uploaded.");
                    }
                        
                    
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialog.Title = "Select file to be upload.";
            openFileDialog.Filter = "Select Valid PDF(*.pdf;)|*.pdf;";
            openFileDialog.FilterIndex = 1;
            openFileDialog.FileName = "";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtSource.Text = openFileDialog.FileName;
                txtTarget.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Files\" + openFileDialog.SafeFileName;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtTarget.Text = Path.Combine(fbd.SelectedPath, Path.GetFileName(txtSource.Text));
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //worker.RunWorkerAsync();
            Process.Start(@"D:\Keen\Documents\Files\dummy.pdf");
        }

        private void test_Load(object sender, EventArgs e)
        {
            //txtTarget.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Files\" + openFileDialog1.FileName;
            //ProcessStartInfo startInfo = new ProcessStartInfo(@"D:\Keen\Documents\Files\dummy.pdf");
            //System.Diagnostics.Process.Start(@"D:\Keen\Documents\Files\dummy.pdf");
            
        }
    }
}
