using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace HRISCapsu
{
    public partial class frmAddPosition : Form
    {
        private string command;
        private string posid;
        public frmAddPosition(string command, string posid, string posname, string postype, string possg, string postep, string positemno)
        {
            InitializeComponent();
            this.command = command;

            if (this.command == "Edit" && posid != null && posname != null && postype != null && possg != null && postep != null && positemno != null)
            {
                this.posid = posid;
                txtUniqueItemNo.Text = positemno;
                txtPositionName.Text = posname;
                cmbPositionType.SelectedItem = postype;
                txtSalaryGradeLevel.Text = possg;
                txtStep.Text = postep;

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (command == "Add")
            {
                if (txtUniqueItemNo.Text == String.Empty)
                {
                    MessageBox.Show("Unique Item Field required! ", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    try
                    {
                        using (var connection =
                            new MySqlConnection(ConfigurationManager.ConnectionStrings["HRISConnection"].ConnectionString))
                        {
                            connection.Open();
                            string query =
                                "INSERT INTO positions (position_name, position_type, position_sg, position_step, position_item_no) VALUES (@position_name, @position_type, @position_sg, @position_step, @position_item_no);";
                            var cmd = new MySqlCommand(query, connection);
                            cmd.Parameters.AddWithValue("position_name", txtPositionName.Text);
                            cmd.Parameters.AddWithValue("position_type", cmbPositionType.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("position_sg", txtSalaryGradeLevel.Text);
                            cmd.Parameters.AddWithValue("position_step", txtStep.Text);
                            cmd.Parameters.AddWithValue("position_item_no", txtPositionName.Text);
                            cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                            MessageBox.Show("Successfully added!", "Success", MessageBoxButtons.OK,
                                MessageBoxIcon.None);
                            Close();
                        }
                    }
                    catch (MySqlException)
                    {
                        MessageBox.Show("Item No. already exist!", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show("Error inserting position: " + exception.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                
            }
            else
            {
                try
                {
                    using (var conn =
                        new MySqlConnection(ConfigurationManager.ConnectionStrings["HRISConnection"].ConnectionString))
                    {
                        conn.Open();
                        var query =
                            @"UPDATE positions SET position_name = @position_name, position_type = @position_type, position_sg = @position_sg, position_step = @position_step, position_item_no = @position_item_no WHERE position_id = @position_id;";
                        var cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("position_name", txtPositionName.Text);
                        cmd.Parameters.AddWithValue("position_type", cmbPositionType.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("position_sg", txtSalaryGradeLevel.Text);
                        cmd.Parameters.AddWithValue("position_step", txtStep.Text);
                        cmd.Parameters.AddWithValue("position_item_no", txtUniqueItemNo.Text);
                        cmd.Parameters.AddWithValue("position_id", posid);
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        MessageBox.Show("Successfully updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.None);
                        Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating position: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmAddPosition_Load(object sender, EventArgs e)
        {
            if (this.command == "Add")
            {
                lblTitle.Text = "ADD POSITION";
            }
            else
            {
                lblTitle.Text = "UPDATE POSITION";
            }
        }
    }
}
