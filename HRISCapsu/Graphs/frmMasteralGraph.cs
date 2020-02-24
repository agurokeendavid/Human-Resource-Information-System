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

namespace HRISCapsu.Graphs
{
    public partial class frmMasteralGraph : Form
    {
        public frmMasteralGraph()
        {
            InitializeComponent();
        }

        int CountMaleFaculty()
        {
            int numberOfFaculty = 0;
            try
            {
                using (var conn =
                    new MySqlConnection(ConfigurationManager.ConnectionStrings["HRISConnection"].ConnectionString))
                {
                    conn.Open();
                    string query =
                        "SELECT COUNT(employee_no) AS employee_count FROM employees WHERE gender = @gender AND status = @status AND degree = @degree;";
                    var cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("gender", "Male");
                    cmd.Parameters.AddWithValue("status", "Active");
                    cmd.Parameters.AddWithValue("degree", "Masteral Degree");
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            numberOfFaculty = Convert.ToInt32(reader[0]);
                        }
                    }
                    else
                    {
                        numberOfFaculty = 0;
                    }

                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            return numberOfFaculty;
        }

        int CountFemaleFaculty()
        {
            int numberOfFaculty = 0;
            try
            {
                using (var conn =
                    new MySqlConnection(ConfigurationManager.ConnectionStrings["HRISConnection"].ConnectionString))
                {
                    conn.Open();
                    string query =
                        "SELECT COUNT(employee_no) AS employee_count FROM employees WHERE gender = @gender AND status = @status AND degree = @degree;";
                    var cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("gender", "Female");
                    cmd.Parameters.AddWithValue("status", "Active");
                    cmd.Parameters.AddWithValue("degree", "Masteral Degree");
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            numberOfFaculty = Convert.ToInt32(reader[0]);
                        }
                    }
                    else
                    {
                        numberOfFaculty = 0;
                    }

                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            return numberOfFaculty;
        }

        private void frmMasteralGraph_Load(object sender, EventArgs e)
        {
            
            chart1.Series["Series1"].Points.AddXY("Male", CountMaleFaculty());
            chart1.Series["Series1"].Points.AddXY("Female", CountFemaleFaculty());
        }
    }
}
