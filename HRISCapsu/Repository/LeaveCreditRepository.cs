using HRISCapsu.Models;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
using static HRISCapsu.Classes.ConnectionString;

namespace HRISCapsu.Repository
{
    public static class LeaveCreditRepository
    {
        public static int InsertLeaveCredits(LeaveCredits model)
        {
            using (var connection = new MySqlConnection(GetConnectionString()))
            {
                connection.Open();
                string query = "INSERT INTO tbl_leave_credits (employee_no, leave_credit, remaining_leave_credit, is_deleted) VALUES (@employee_no, @leave_credit, @remaining_leave_credit, @is_deleted);";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.Add("employee_no", MySqlDbType.VarChar).Value = model.EmployeeNo;
                    command.Parameters.Add("leave_credit", MySqlDbType.Int16).Value = model.LeaveCredit;
                    command.Parameters.Add("remaining_leave_credit", MySqlDbType.Int16).Value = model.RemainingLeaveCredit;
                    command.Parameters.Add("is_deleted", MySqlDbType.Int16).Value = model.IsDeleted;
                    return command.ExecuteNonQuery();
                }
            }
        }

        public static int UpdateLeaveCredit(LeaveCredits model)
        {
            try
            {
                using (var connection = new MySqlConnection(GetConnectionString()))
                {
                    connection.Open();
                    string query = "UPDATE tbl_leave_credits SET leave_credit = @leave_credit, remaining_leave_credit = @remaining_leave_credit WHERE employee_no = @employee_no;";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.Add("leave_credit", MySqlDbType.Int16).Value = model.LeaveCredit;
                        command.Parameters.Add("remaining_leave_credit", MySqlDbType.Int16).Value = model.RemainingLeaveCredit;
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

        public static int DeleteLeaveCredit(LeaveCredits model)
        {
            try
            {
                using (var connection = new MySqlConnection(GetConnectionString()))
                {
                    connection.Open();
                    string query = "UPDATE tbl_leave_credits SET is_deleted = @is_deleted WHERE employee_no = @employee_no;";
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

        public static int DeleteLeave(string employeeNo, int isDeleted)
        {
            try
            {
                using (var connection = new MySqlConnection(GetConnectionString()))
                {
                    connection.Open();
                    string query = "UPDATE tbl_leave SET is_deleted = @is_deleted WHERE employee_no = @employee_no;";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.Add("employee_no", MySqlDbType.VarChar).Value = employeeNo;
                        command.Parameters.Add("is_deleted", MySqlDbType.Int16).Value = isDeleted;
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

        public static int UpdateRemainingLeaveCredit(int remainingLeaveCredits, string employeeNo)
        {
            try
            {
                using (var connection = new MySqlConnection(GetConnectionString()))
                {
                    connection.Open();
                    string query = "UPDATE tbl_leave_credits SET remaining_leave_credit = remaining_leave_credit - @remaining_leave_credit WHERE employee_no = @employee_no;";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.Add("remaining_leave_credit", MySqlDbType.Int16).Value = remainingLeaveCredits;
                        command.Parameters.Add("employee_no", MySqlDbType.VarChar).Value = employeeNo;
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
    }
}
