using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HRISCapsu.Classes.ConnectionString;

namespace HRISCapsu.Classes
{
    public static class Position
    {
        public static void GetAllPositionInComboBox(ComboBox comboBox)
        {
            try
            {
                using (var connection = new MySqlConnection(GetConnectionString()))
                {
                    connection.Open();
                    string query = "SELECT position_name FROM tbl_positions;";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        var da = new MySqlDataAdapter { SelectCommand = command };
                        var dt = new DataTable();

                        da.Fill(dt);

                        comboBox.DataSource = dt;
                        comboBox.DisplayMember = "position_name";
                        comboBox.ValueMember = "position_name";
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to load data in combobox.");
            }
        }

        public static void GetSalaryGradeInTextBox(string positionName, TextBox textBox)
        {
            try
            {
                using (var connection = new MySqlConnection(GetConnectionString()))
                {
                    connection.Open();
                    string query = "SELECT salary_grade_level FROM tbl_positions WHERE position_name = @position_name;";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.Add("position_name", MySqlDbType.VarChar).Value = positionName;
                        textBox.Text = command.ExecuteScalar().ToString();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to load data in textbox.");
            }
        }
    }
}
