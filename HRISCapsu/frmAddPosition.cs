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
        public frmAddPosition()
        {
            InitializeComponent();
            frmLogin.SendMessage(txtPositionName.Handle, 0x1501, 1, "Position.");
            frmLogin.SendMessage(txtSalaryGradeLevel.Handle, 0x1501, 1, "Salary Grade.");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (var connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["HRISConnection"].ConnectionString))
                {
                    connection.Open();
                    string query = @"INSERT INTO tbl_positions (position_name, position_type, salary_grade_level) VALUES (@position_name, @position_type, @salary_grade_level)";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.Add("position_name", MySqlDbType.VarChar).Value = txtPositionName.Text;
                        command.Parameters.Add("position_type", MySqlDbType.VarChar).Value = cmbPositionType.SelectedItem.ToString();
                        command.Parameters.Add("salary_grade_level", MySqlDbType.Int32).Value = txtSalaryGradeLevel.Text;
                        command.ExecuteNonQuery();
                        MessageBox.Show("Successfully added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.None);
                        Close();
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Position already exist! {ex.Message}", "Failed!",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Please try again later! {ex.Message}", "Failed!",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmAddPosition_Load(object sender, EventArgs e)
        {

        }

        private void txtSalaryGradeLevel_KeyPress(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }
    }
}
