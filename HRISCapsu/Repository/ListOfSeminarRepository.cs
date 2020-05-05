using HRISCapsu.Models;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
using static HRISCapsu.Classes.ConnectionString;

namespace HRISCapsu.Repository
{
    public static class ListOfSeminarRepository
    {
        public static int InsertSeminar(Seminar model)
        {
            using (var connection = new MySqlConnection(GetConnectionString()))
            {
                connection.Open();
                string query = "INSERT INTO tbl_list_of_seminars (employee_no, local_seminar_name, local_seminar_type, local_from, local_to, regional_seminar_name, regional_seminar_type, regional_from, regional_to, national_seminar_name, national_seminar_type, national_from, national_to, international_seminar_name, international_seminar_type, international_from, international_to, is_deleted) VALUES (@employee_no, @local_seminar_name, @local_seminar_type, @local_from, @local_to, @regional_seminar_name, @regional_seminar_type, @regional_from, @regional_to, @national_seminar_name, @national_seminar_type, @national_from, @national_to, @international_seminar_name, @international_seminar_type, @international_from, @international_to, @is_deleted);";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.Add("employee_no", MySqlDbType.VarChar).Value = model.EmployeeNo;
                    command.Parameters.Add("local_seminar_name", MySqlDbType.VarChar).Value = model.LocalSeminarName;
                    command.Parameters.Add("local_seminar_type", MySqlDbType.VarChar).Value = model.LocalSeminarType;
                    command.Parameters.Add("local_from", MySqlDbType.Date).Value = model.LocalFrom;
                    command.Parameters.Add("local_to", MySqlDbType.Date).Value = model.LocalTo;
                    command.Parameters.Add("regional_seminar_name", MySqlDbType.VarChar).Value = model.RegionalSeminarName;
                    command.Parameters.Add("regional_seminar_type", MySqlDbType.VarChar).Value = model.RegionalSeminarType;
                    command.Parameters.Add("regional_from", MySqlDbType.Date).Value = model.RegionalFrom;
                    command.Parameters.Add("regional_to", MySqlDbType.Date).Value = model.RegionalTo;
                    command.Parameters.Add("national_seminar_name", MySqlDbType.VarChar).Value = model.NationalSeminarName;
                    command.Parameters.Add("national_seminar_type", MySqlDbType.VarChar).Value = model.NationalSeminarType;
                    command.Parameters.Add("national_from", MySqlDbType.Date).Value = model.NationalFrom;
                    command.Parameters.Add("national_to", MySqlDbType.Date).Value = model.NationalTo;
                    command.Parameters.Add("international_seminar_name", MySqlDbType.VarChar).Value = model.InternationalSeminarName;
                    command.Parameters.Add("international_seminar_type", MySqlDbType.VarChar).Value = model.InternationalSeminarType;
                    command.Parameters.Add("international_from", MySqlDbType.Date).Value = model.InternationalFrom;
                    command.Parameters.Add("international_to", MySqlDbType.Date).Value = model.InternationalTo;
                    command.Parameters.Add("is_deleted", MySqlDbType.Int16).Value = model.IsDeleted;
                    return command.ExecuteNonQuery();
                }
            }
        }

        public static int DeleteSeminar(Seminar model)
        {
            try
            {
                using (var connection = new MySqlConnection(GetConnectionString()))
                {
                    connection.Open();
                    string query = "UPDATE tbl_list_of_seminars SET is_deleted = @is_deleted WHERE employee_no = @employee_no;";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.Add("is_deleted", MySqlDbType.Int16).Value = model.IsDeleted;
                        command.Parameters.Add("employee_no", MySqlDbType.VarChar).Value = model.EmployeeNo;
                        return command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        public static Seminar GetSingleSeminar(string employeeNo)
        {
            var seminar = new Seminar();
            try
            {
                using (var connection = new MySqlConnection(GetConnectionString()))
                {
                    connection.Open();
                    string query = "SELECT * FROM tbl_list_of_seminars WHERE employee_no = @employee_no;";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.Add("employee_no", MySqlDbType.VarChar).Value = employeeNo;
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while(reader.Read())
                            {
                                seminar.LocalSeminarName = reader.GetString("local_seminar_name");
                                seminar.LocalSeminarType = reader.GetString("local_seminar_type");
                                seminar.LocalFrom = reader["local_from"] != DBNull.Value ? (DateTime?)reader["local_from"] : null;
                                seminar.LocalTo = reader["local_to"] != DBNull.Value ? (DateTime?)reader["local_to"] : null;
                                seminar.RegionalSeminarName = reader.GetString("regional_seminar_name");
                                seminar.RegionalSeminarType = reader.GetString("regional_seminar_type");
                                seminar.RegionalFrom = reader["regional_from"] != DBNull.Value ? (DateTime?)reader["regional_from"] : null;
                                seminar.RegionalTo = reader["regional_to"] != DBNull.Value ? (DateTime?)reader["regional_to"] : null;
                                seminar.NationalSeminarName = reader.GetString("national_seminar_name");
                                seminar.NationalSeminarType = reader.GetString("national_seminar_type");
                                seminar.NationalFrom = reader["national_from"] != DBNull.Value ? (DateTime?)reader["national_from"] : null;
                                seminar.NationalTo = reader["national_to"] != DBNull.Value ? (DateTime?)reader["national_to"] : null;
                                seminar.InternationalSeminarName = reader.GetString("international_seminar_name");
                                seminar.InternationalSeminarType = reader.GetString("international_seminar_type");
                                seminar.InternationalFrom = reader["international_from"] != DBNull.Value ? (DateTime?)reader["international_from"] : null;
                                seminar.InternationalTo = reader["international_to"] != DBNull.Value ? (DateTime?)reader["international_to"] : null;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var error = ex.Message;
                seminar = null;
            }
            return seminar;
        }
    }
}
