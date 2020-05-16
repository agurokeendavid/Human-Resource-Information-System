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
                                seminar.LocalSeminarName = reader["local_seminar_name"] != DBNull.Value ? reader["local_seminar_name"].ToString() : null;
                                seminar.LocalSeminarType = reader["local_seminar_type"] != DBNull.Value ? reader["local_seminar_type"].ToString() : null;
                                seminar.LocalFrom = reader["local_from"] != DBNull.Value ? (DateTime?)reader["local_from"] : null;
                                seminar.LocalTo = reader["local_to"] != DBNull.Value ? (DateTime?)reader["local_to"] : null;
                                seminar.RegionalSeminarName = reader["regional_seminar_name"] != DBNull.Value ? reader["regional_seminar_name"].ToString() : null;
                                seminar.RegionalSeminarType = reader["regional_seminar_type"] != DBNull.Value ? reader["regional_seminar_type"].ToString() : null;
                                seminar.RegionalFrom = reader["regional_from"] != DBNull.Value ? (DateTime?)reader["regional_from"] : null;
                                seminar.RegionalTo = reader["regional_to"] != DBNull.Value ? (DateTime?)reader["regional_to"] : null;
                                seminar.NationalSeminarName = reader["national_seminar_name"] != DBNull.Value ? reader["national_seminar_name"].ToString() : null;
                                seminar.NationalSeminarType = reader["national_seminar_type"] != DBNull.Value ? reader["national_seminar_type"].ToString() : null;
                                seminar.NationalFrom = reader["national_from"] != DBNull.Value ? (DateTime?)reader["national_from"] : null;
                                seminar.NationalTo = reader["national_to"] != DBNull.Value ? (DateTime?)reader["national_to"] : null;
                                seminar.InternationalSeminarName = reader["international_seminar_name"] != DBNull.Value ? reader["international_seminar_name"].ToString() : null;
                                seminar.InternationalSeminarType = reader["international_seminar_type"] != DBNull.Value ? reader["international_seminar_type"].ToString() : null;
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

        public static int UpdateLocalSeminar(Seminar seminar)
        {
            if (seminar.LocalFrom.HasValue && seminar.LocalTo.HasValue && seminar.LocalFrom.Value.Date == seminar.LocalTo.Value.Date)
                seminar.LocalTo = seminar.LocalTo.Value.AddDays(1);

            using (var connection = new MySqlConnection(GetConnectionString()))
            {
                string sql =
                    "UPDATE tbl_list_of_seminars SET local_seminar_name = @local_seminar_name, local_seminar_type = @local_seminar_type, local_from = @local_from, local_to = @local_to WHERE employee_no = @employee_no;";
                connection.Open();
                using (var command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.Add("local_seminar_name", MySqlDbType.VarChar).Value = seminar.LocalSeminarName;
                    command.Parameters.Add("local_seminar_type", MySqlDbType.VarChar).Value = seminar.LocalSeminarType;
                    command.Parameters.Add("local_from", MySqlDbType.DateTime).Value = seminar.LocalFrom;
                    command.Parameters.Add("local_to", MySqlDbType.DateTime).Value = seminar.LocalTo;
                    command.Parameters.Add("employee_no", MySqlDbType.VarChar).Value = seminar.EmployeeNo;
                    return command.ExecuteNonQuery();
                }
            }
        }

        public static int UpdateRegionalSeminar(Seminar seminar)
        {
            if (seminar.RegionalFrom.HasValue && seminar.RegionalTo.HasValue && seminar.RegionalFrom.Value.Date == seminar.RegionalTo.Value.Date)
                seminar.RegionalTo = seminar.RegionalTo.Value.AddDays(1);

            using (var connection = new MySqlConnection(GetConnectionString()))
            {
                string sql =
                    "UPDATE tbl_list_of_seminars SET regional_seminar_name = @regional_seminar_name, regional_seminar_type = @regional_seminar_type, regional_from = @regional_from, regional_to = @regional_to WHERE employee_no = @employee_no;";
                connection.Open();
                using (var command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.Add("regional_seminar_name", MySqlDbType.VarChar).Value = seminar.RegionalSeminarName;
                    command.Parameters.Add("regional_seminar_type", MySqlDbType.VarChar).Value = seminar.RegionalSeminarType;
                    command.Parameters.Add("regional_from", MySqlDbType.DateTime).Value = seminar.RegionalFrom;
                    command.Parameters.Add("regional_to", MySqlDbType.DateTime).Value = seminar.RegionalTo;
                    command.Parameters.Add("employee_no", MySqlDbType.VarChar).Value = seminar.EmployeeNo;
                    return command.ExecuteNonQuery();
                }
            }
        }

        public static int UpdateNationalSeminar(Seminar seminar)
        {
            if (seminar.NationalFrom.HasValue && seminar.NationalTo.HasValue && seminar.NationalFrom.Value.Date == seminar.NationalTo.Value.Date)
                seminar.NationalTo = seminar.NationalTo.Value.AddDays(1);

            using (var connection = new MySqlConnection(GetConnectionString()))
            {
                string sql =
                    "UPDATE tbl_list_of_seminars SET national_seminar_name = @national_seminar_name, national_seminar_type = @national_seminar_type, national_from = @national_from, national_to = @national_to WHERE employee_no = @employee_no;";
                connection.Open();
                using (var command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.Add("national_seminar_name", MySqlDbType.VarChar).Value = seminar.NationalSeminarName;
                    command.Parameters.Add("national_seminar_type", MySqlDbType.VarChar).Value = seminar.NationalSeminarType;
                    command.Parameters.Add("national_from", MySqlDbType.DateTime).Value = seminar.NationalFrom;
                    command.Parameters.Add("national_to", MySqlDbType.DateTime).Value = seminar.NationalTo;
                    command.Parameters.Add("employee_no", MySqlDbType.VarChar).Value = seminar.EmployeeNo;
                    return command.ExecuteNonQuery();
                }
            }
        }

        public static int UpdateInternationalSeminar(Seminar seminar)
        {
            if (seminar.InternationalFrom.HasValue && seminar.InternationalTo.HasValue && seminar.InternationalFrom.Value.Date == seminar.InternationalTo.Value.Date)
                seminar.InternationalTo = seminar.InternationalTo.Value.AddDays(1);

            using (var connection = new MySqlConnection(GetConnectionString()))
            {
                string sql =
                    "UPDATE tbl_list_of_seminars SET international_seminar_name = @international_seminar_name, international_seminar_type = @international_seminar_type, international_from = @international_from, international_to = @international_to WHERE employee_no = @employee_no;";
                connection.Open();
                using (var command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.Add("international_seminar_name", MySqlDbType.VarChar).Value = seminar.InternationalSeminarName;
                    command.Parameters.Add("international_seminar_type", MySqlDbType.VarChar).Value = seminar.InternationalSeminarType;
                    command.Parameters.Add("international_from", MySqlDbType.DateTime).Value = seminar.InternationalFrom;
                    command.Parameters.Add("international_to", MySqlDbType.DateTime).Value = seminar.InternationalTo;
                    command.Parameters.Add("employee_no", MySqlDbType.VarChar).Value = seminar.EmployeeNo;
                    return command.ExecuteNonQuery();
                }
            }
        }
    }
}
