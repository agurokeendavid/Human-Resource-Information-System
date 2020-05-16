using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using HRISCapsu.Models;
using MySql.Data.MySqlClient;
using static HRISCapsu.Classes.ConnectionString;

namespace HRISCapsu.Repository
{
    public static class EmployeeRepository
    {
        public static int InsertEmployee(Employee model)
        {
            try
            {
                using (var connection = new MySqlConnection(GetConnectionString()))
                {
                    connection.Open();
                    string query = @"INSERT INTO employees (employee_no, first_name, middle_name, last_name, address, gender, date_of_birth, place_of_birth, contact_no, civil_status, highest_degree, bs_course, bs_year_graduated, bs_school, masteral_course, masteral_year_graduated, masteral_school, doctoral_course, doctoral_year_graduated, doctoral_school, eligibility, employee_type, position, unique_item_no, salary_grade, step, department, work_status, employee_photo, documentpath, hired_date, end_of_contract, is_deleted) VALUES (@employee_no, @first_name, @middle_name, @last_name, @address, @gender, @date_of_birth, @place_of_birth, @contact_no, @civil_status, @highest_degree, @bs_course, @bs_year_graduated, @bs_school, @masteral_course, @masteral_year_graduated, @masteral_school, @doctoral_course, @doctoral_year_graduated, @doctoral_school, @eligibility, @employee_type, @position, @unique_item_no, @salary_grade, @step, @department, @work_status, @employee_photo, @documentpath, @hired_date, @end_of_contract, @is_deleted)";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.Add("employee_no", MySqlDbType.VarChar).Value = model.EmployeeNo;
                        command.Parameters.Add("first_name", MySqlDbType.VarChar).Value = model.FirstName;
                        command.Parameters.Add("middle_name", MySqlDbType.VarChar).Value = model.MiddleName;
                        command.Parameters.Add("last_name", MySqlDbType.VarChar).Value = model.LastName;
                        command.Parameters.Add("address", MySqlDbType.VarChar).Value = model.Address;
                        command.Parameters.Add("gender", MySqlDbType.VarChar).Value = model.Gender;
                        command.Parameters.Add("date_of_birth", MySqlDbType.Date).Value = model.DateOfBirth;
                        command.Parameters.Add("place_of_birth", MySqlDbType.VarChar).Value = model.PlaceOfBirth;
                        command.Parameters.Add("contact_no", MySqlDbType.VarChar).Value = model.ContactNo;
                        command.Parameters.Add("civil_status", MySqlDbType.VarChar).Value = model.CivilStatus;
                        command.Parameters.Add("highest_degree", MySqlDbType.VarChar).Value = model.HighestDegree;
                        command.Parameters.Add("bs_course", MySqlDbType.VarChar).Value = model.BsCourse;
                        command.Parameters.Add("bs_year_graduated", MySqlDbType.VarChar).Value = model.BsYearGraduated;
                        command.Parameters.Add("bs_school", MySqlDbType.VarChar).Value = model.BsSchool;
                        command.Parameters.Add("masteral_course", MySqlDbType.VarChar).Value = model.MasteralCourse;
                        command.Parameters.Add("masteral_year_graduated", MySqlDbType.VarChar).Value = model.MasteralYearGraduated;
                        command.Parameters.Add("masteral_school", MySqlDbType.VarChar).Value = model.MasteralSchool;
                        command.Parameters.Add("doctoral_course", MySqlDbType.VarChar).Value = model.DoctoralCourse;
                        command.Parameters.Add("doctoral_year_graduated", MySqlDbType.VarChar).Value = model.DoctoralYearGraduated;
                        command.Parameters.Add("doctoral_school", MySqlDbType.VarChar).Value = model.DoctoralSchool;
                        command.Parameters.Add("eligibility", MySqlDbType.VarChar).Value = model.Eligibility;
                        command.Parameters.Add("employee_type", MySqlDbType.VarChar).Value = model.EmployeeType;
                        command.Parameters.Add("position", MySqlDbType.VarChar).Value = model.Position;
                        command.Parameters.Add("unique_item_no", MySqlDbType.VarChar).Value = model.UniqueItemNo;
                        command.Parameters.Add("salary_grade", MySqlDbType.Int16).Value = model.SalaryGrade;
                        command.Parameters.Add("step", MySqlDbType.Int16).Value = model.Step;
                        command.Parameters.Add("department", MySqlDbType.VarChar).Value = model.Department;
                        command.Parameters.Add("work_status", MySqlDbType.VarChar).Value = model.WorkStatus;
                        command.Parameters.Add("employee_photo", MySqlDbType.Blob).Value = model.EmployeePhoto;
                        command.Parameters.Add("documentpath", MySqlDbType.VarChar).Value = model.DocumentPath;
                        command.Parameters.Add("hired_date", MySqlDbType.Date).Value = model.HiredDate;
                        command.Parameters.Add("end_of_contract", MySqlDbType.Date).Value = model.WorkStatus == "Contractual" ? model.EndOfContract : null;
                        command.Parameters.Add("is_deleted", MySqlDbType.Int16).Value = model.IsDeleted;
                        return command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return 0;
        }

        public static void GetAllEmployees(string keyword, int isDeleted, DataTable dataTable)
        {
            try
            {
                using (var connection = new MySqlConnection(GetConnectionString()))
                {
                    connection.Open();
                    string query = "SELECT e.employee_id EmployeeId, e.employee_no EmployeeNo, e.first_name FirstName, e.middle_name MiddleName, e.last_name LastName, e.address Address, e.gender Gender, e.date_of_birth DateOfBirth, e.place_of_birth PlaceOfBirth, e.contact_no ContactNo, e.civil_status CivilStatus, e.highest_degree HighestDegree, e.bs_course BsCourse, e.bs_year_graduated BsYearGraduated, e.bs_school BsSchool, e.masteral_course MasteralCourse, e.masteral_year_graduated MasteralYearGraduated, e.masteral_school MasteralSchool, e.doctoral_course DoctoralCourse, e.doctoral_year_graduated DoctoralYearGraduated, e.doctoral_school DoctoralSchool, e.eligibility Eligibility, e.employee_type EmployeeType, e.position Position, e.unique_item_no UniqueItemNo, e.salary_grade SalaryGrade, e.step Step, e.department Department, e.work_status WorkStatus, e.employee_photo EmployeePhoto, e.documentpath DocumentPath, e.hired_date HiredDate, e.end_of_contract EndOfContract, lc.leave_credit LeaveCredit, lc.remaining_leave_credit RemainingLeaveCredit, e.is_deleted IsDeleted FROM employees e INNER JOIN tbl_leave_credits lc ON e.employee_no = lc.employee_no INNER JOIN tbl_list_of_seminars ls ON e.employee_no = ls.employee_no WHERE (e.first_name LIKE @keyword OR e.middle_name LIKE @keyword OR e.last_name LIKE @keyword) AND e.is_deleted = @is_deleted;";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.Add("keyword", MySqlDbType.VarChar).Value = '%' + keyword + '%';
                        command.Parameters.Add("is_deleted", MySqlDbType.Int16).Value = isDeleted;
                        var adapter = new MySqlDataAdapter(command);
                        adapter.Fill(dataTable);
                    }
                }
            }
            catch (Exception)   
            {

            }
        }

        public static int UpdateEmployee(Employee employee)
        {
            try
            {
                using (var connection = new MySqlConnection(GetConnectionString()))
                {
                    connection.Open();
                    string query = "UPDATE employees SET first_name = @first_name, middle_name = @middle_name, last_name = @last_name, address = @address, gender = @gender, date_of_birth = @date_of_birth, place_of_birth = @place_of_birth, contact_no = @contact_no, civil_status = @civil_status, highest_degree = @highest_degree, bs_course = @bs_course, bs_year_graduated = @bs_year_graduated, bs_school = @bs_school, masteral_course = @masteral_course, masteral_year_graduated = @masteral_year_graduated, masteral_school = @masteral_school, doctoral_course = @doctoral_course, doctoral_year_graduated = @doctoral_year_graduated, doctoral_school = @doctoral_school, eligibility = @eligibility, employee_type = @employee_type, position = @position, unique_item_no = @unique_item_no, salary_grade = @salary_grade, step = @step, department = @department, work_status = @work_status, hired_date = @hired_date, end_of_contract = @end_of_contract WHERE employee_no = @employee_no;";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.Add("first_name", MySqlDbType.VarChar).Value = employee.FirstName;
                        cmd.Parameters.Add("middle_name", MySqlDbType.VarChar).Value = employee.MiddleName;
                        cmd.Parameters.Add("last_name", MySqlDbType.VarChar).Value = employee.LastName;
                        cmd.Parameters.Add("address", MySqlDbType.VarChar).Value = employee.Address;
                        cmd.Parameters.Add("gender", MySqlDbType.VarChar).Value = employee.Gender;
                        cmd.Parameters.Add("date_of_birth", MySqlDbType.Date).Value = employee.DateOfBirth;
                        cmd.Parameters.Add("place_of_birth", MySqlDbType.VarChar).Value = employee.PlaceOfBirth;
                        cmd.Parameters.Add("contact_no", MySqlDbType.VarChar).Value = employee.ContactNo;
                        cmd.Parameters.Add("civil_status", MySqlDbType.VarChar).Value = employee.CivilStatus;
                        cmd.Parameters.Add("highest_degree", MySqlDbType.VarChar).Value = employee.HighestDegree;
                        cmd.Parameters.Add("bs_course", MySqlDbType.VarChar).Value = employee.BsCourse;
                        cmd.Parameters.Add("bs_year_graduated", MySqlDbType.VarChar).Value = employee.BsYearGraduated;
                        cmd.Parameters.Add("bs_school", MySqlDbType.VarChar).Value = employee.BsSchool;
                        cmd.Parameters.Add("masteral_course", MySqlDbType.VarChar).Value = employee.MasteralCourse;
                        cmd.Parameters.Add("masteral_year_graduated", MySqlDbType.VarChar).Value = employee.MasteralYearGraduated;
                        cmd.Parameters.Add("masteral_school", MySqlDbType.VarChar).Value = employee.MasteralSchool;
                        cmd.Parameters.Add("doctoral_course", MySqlDbType.VarChar).Value = employee.DoctoralCourse;
                        cmd.Parameters.Add("doctoral_year_graduated", MySqlDbType.VarChar).Value = employee.DoctoralYearGraduated;
                        cmd.Parameters.Add("doctoral_school", MySqlDbType.VarChar).Value = employee.DoctoralSchool;
                        cmd.Parameters.Add("eligibility", MySqlDbType.VarChar).Value = employee.Eligibility;
                        cmd.Parameters.Add("employee_type", MySqlDbType.VarChar).Value = employee.EmployeeType;
                        cmd.Parameters.Add("position", MySqlDbType.VarChar).Value = employee.Position;
                        cmd.Parameters.Add("unique_item_no", MySqlDbType.VarChar).Value = employee.UniqueItemNo;
                        cmd.Parameters.Add("salary_grade", MySqlDbType.Int16).Value = employee.SalaryGrade;
                        cmd.Parameters.Add("step", MySqlDbType.Int16).Value = employee.Step;
                        cmd.Parameters.Add("department", MySqlDbType.VarChar).Value = employee.Department;
                        cmd.Parameters.Add("work_status", MySqlDbType.VarChar).Value = employee.WorkStatus;
                        cmd.Parameters.Add("hired_date", MySqlDbType.Date).Value = employee.HiredDate;
                        cmd.Parameters.Add("end_of_contract", MySqlDbType.Date).Value = employee.WorkStatus == "Contractual" ? employee.EndOfContract : null;
                        cmd.Parameters.Add("employee_no", MySqlDbType.VarChar).Value = employee.EmployeeNo;
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        public static int DeleteEmployee(Employee model)
        {
            try
            {
                using (var connection = new MySqlConnection(GetConnectionString()))
                {
                    connection.Open();
                    string query = "UPDATE employees SET is_deleted = @is_deleted WHERE employee_no = @employee_no;";
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

        public static void GetAllListOfEmployees(string keyword, string employeeType, string workStatus, int isDeleted, DataTable dataTable)
        {
            try
            {
                using (var connection = new MySqlConnection(GetConnectionString()))
                {
                    connection.Open();
                    string query = "SELECT * FROM employees INNER JOIN tbl_leave_credits ON employees.employee_no = tbl_leave_credits.employee_no INNER JOIN tbl_list_of_seminars ON employees.employee_no = tbl_list_of_seminars.employee_no WHERE (employees.first_name LIKE @keyword OR employees.middle_name LIKE @keyword OR employees.last_name LIKE @keyword) AND employees.employee_type = @employee_type AND employees.work_status = @work_status AND employees.is_deleted = @is_deleted";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.Add("keyword", MySqlDbType.VarChar).Value = '%' + keyword + '%';
                        command.Parameters.Add("employee_type", MySqlDbType.VarChar).Value = employeeType;
                        command.Parameters.Add("work_status", MySqlDbType.VarChar).Value = workStatus;
                        command.Parameters.Add("is_deleted", MySqlDbType.Int16).Value = isDeleted;
                        var da = new MySqlDataAdapter(command);
                        da.Fill(dataTable);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void GetAcademicEmployeesOnLeave(string keyword, int isDeleted, DataTable dt)
        {
            try
            {
                using (var connection = new MySqlConnection(GetConnectionString()))
                {
                    connection.Open();
                    string query = "SELECT CONCAT(last_name, ', ', first_name, ' ', middle_name) FullName, leave_credit, remaining_leave_credit FROM employees INNER JOIN tbl_leave_credits ON employees.employee_no = tbl_leave_credits.employee_no WHERE leave_credit IS NOT NULL AND remaining_leave_credit IS NOT NULL AND (first_name LIKE @keyword OR middle_name LIKE @keyword OR last_name LIKE @keyword) AND employees.is_deleted = @is_deleted";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.Add("keyword", MySqlDbType.VarChar).Value = '%' + keyword + '%';
                        command.Parameters.Add("is_deleted", MySqlDbType.Int16).Value = isDeleted;
                        using (var da = new MySqlDataAdapter(command))
                        {
                            da.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void GetNonAcademicEmployeesOnLeave(string keyword, int isDeleted, DataTable dt)
        {
            try
            {
                using (var connection = new MySqlConnection(GetConnectionString()))
                {
                    connection.Open();
                    string query = "SELECT CONCAT(last_name, ', ', first_name, ' ', middle_name) FullName, contact_no,from_date, to_date FROM employees INNER JOIN tbl_leave ON employees.employee_no = tbl_leave.employee_no WHERE (first_name LIKE @keyword OR middle_name LIKE @keyword OR last_name LIKE @keyword) AND employees.is_deleted = @is_deleted AND tbl_leave.is_deleted = @is_deleted";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.Add("keyword", MySqlDbType.VarChar).Value = '%' + keyword + '%';
                        command.Parameters.Add("is_deleted", MySqlDbType.Int16).Value = isDeleted;
                        using (var da = new MySqlDataAdapter(command))
                        {
                            da.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static Employee GetSingleEmployee(string employeeNo)
        {
            var employee = new Employee();
            try
            {
                using (var connection = new MySqlConnection(GetConnectionString()))
                {
                    connection.Open();
                    string query = "SELECT * FROM employees WHERE employee_no = @employee_no;";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.Add("employee_no", MySqlDbType.VarChar).Value = employeeNo;
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                employee.EmployeeNo = reader.GetString("employee_no");
                                employee.FirstName = reader.GetString("first_name");
                                employee.MiddleName = reader.GetString("middle_name");
                                employee.LastName = reader.GetString("last_name");
                                employee.Address = reader.GetString("address");
                                employee.Gender = reader.GetString("gender");
                                employee.DateOfBirth = reader.GetDateTime("date_of_birth");
                                employee.PlaceOfBirth = reader.GetString("place_of_birth");
                                employee.ContactNo = reader.GetString("contact_no");
                                employee.CivilStatus = reader.GetString("civil_status");
                                employee.HighestDegree = reader.GetString("highest_degree");
                                employee.BsCourse = reader.GetString("bs_course");
                                employee.BsYearGraduated = reader.GetString("bs_year_graduated");
                                employee.BsSchool = reader.GetString("bs_school");
                                employee.MasteralCourse = reader.GetString("masteral_course");
                                employee.MasteralYearGraduated = reader.GetString("masteral_year_graduated");
                                employee.MasteralSchool = reader.GetString("masteral_school");
                                employee.DoctoralCourse = reader.GetString("doctoral_course");
                                employee.DoctoralYearGraduated = reader.GetString("doctoral_year_graduated");
                                employee.DoctoralSchool = reader.GetString("doctoral_school");
                                employee.Eligibility = reader.GetString("eligibility");
                                employee.EmployeeType = reader.GetString("employee_type");
                                employee.Position = reader.GetString("position");
                                employee.UniqueItemNo = reader.GetString("unique_item_no");
                                employee.SalaryGrade = reader.GetInt16("salary_grade");
                                employee.Step = reader.GetInt16("step");
                                employee.Department = reader.GetString("department");
                                employee.WorkStatus = reader.GetString("work_status");
                                employee.EmployeePhoto = (byte[])reader["employee_photo"];
                                employee.DocumentPath = reader.GetString("documentpath");
                                employee.HiredDate = reader.GetDateTime("hired_date");
                                employee.EndOfContract = reader.GetDateTime("end_of_contract");
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                employee = null;
            }
            return employee;
        }
    }
}
