using MySql.Data.MySqlClient;
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

namespace HRISCapsu.Graphs
{
    public partial class frmPositionGraph : Form
    {
        public frmPositionGraph()
        {
            InitializeComponent();
        }
        private List<string> LoadPositions()
        {
            var positions = new List<string>();
            using (var connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["HRISConnection"].ConnectionString))
            {
                connection.Open();
                string query = "SELECT position_name FROM tbl_positions WHERE position_type = @position_type;";
                using ( var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.Add("position_type", MySqlDbType.VarChar).Value = "Academic";
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        positions.Add(reader["position_name"].ToString());
                    }
                }
            }

            return positions;
        }

        int CountPosition(string positionName)
        {
            int count = 0;
            try
            {
                using (var connection =
                    new MySqlConnection(ConfigurationManager.ConnectionStrings["HRISConnection"].ConnectionString))
                {
                    connection.Open();
                    string query =
                        "SELECT COUNT(employee_no) AS employee_count FROM employees WHERE employee_type = @employee_type AND position = @position AND is_deleted = @is_deleted;";
                    var command = new MySqlCommand(query, connection);
                    command.Parameters.Add("employee_type", MySqlDbType.VarChar).Value = "Academic";
                    command.Parameters.Add("position", MySqlDbType.VarChar).Value = positionName;
                    command.Parameters.Add("is_deleted", MySqlDbType.Int16).Value = 0;
                    MySqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            count = Convert.ToInt32(reader["employee_count"]);
                        }
                    }
                    else
                    {
                        count = 0;
                    }

                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            return count;
        }
        private void frmPositionGraph_Load(object sender, EventArgs e)
        {
            foreach (var position in LoadPositions())
            {
                chart1.Series["Series1"].Points.AddXY(position, CountPosition(position));
            }
            
        }
    }
}
