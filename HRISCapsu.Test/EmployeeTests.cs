using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static HRISCapsu.Repository.EmployeeRepository;
using static HRISCapsu.Repository.LeaveCreditRepository;
using static HRISCapsu.Repository.ListOfSeminarRepository;
using MySql.Data;
using System.Threading.Tasks;
using HRISCapsu.Models;
using System.Linq;
using System.Data;

namespace HRISCapsu.Test
{
    [TestClass]
    public class EmployeeTests
    {
        [TestMethod]
        public void Insert_Employee_Should_Return_1()
        {
            // Arrange
            var model = new Employee
            {
                EmployeeNo = "1",
                FirstName = "Mark",
                MiddleName = "Joe",
                LastName = "Smith",
                Address = "Manila City",
                Gender = "Male",
                DateOfBirth = new DateTime(1998, 6, 21),
                PlaceOfBirth = "Roxas City, Capiz",
                ContactNo = "09206264079",
                CivilStatus = "Single",
                HighestDegree = "College",
                BsCourse = "BSIT",
                BsYearGraduated = 2019,
                BsSchool = "FCU",
                MasteralCourse = "MASB",
                MasteralYearGraduated = 2020,
                MasteralSchool = "CPU",
                DoctoralCourse = "DIT",
                DoctoralYearGraduated = 2021,
                DoctoralSchool = "FEU",
                Eligibility = "CSE",
                EmployeeType = "Academic",
                Position = "Instructor I",
                UniqueItemNo = "20FF",
                SalaryGrade = 12,
                Step = 3,
                Department = "College of Education Arts and Science",
                WorkStatus = "Regular",
                EmployeePhoto = new byte[23242],
                DocumentPath = @"D:\\Test.jpg",
                HiredDate = new DateTime(2020, 05, 04),
                EndOfContract = null,
                IsDeleted = 0
            };
            // Act
            int result = InsertEmployee(model);

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Insert_Leave_Credit_Should_Return_1()
        {
            // Arrange
            var model = new LeaveCredits
            {
                EmployeeNo = "1",
                LeaveCredit = 3,
                RemainingLeaveCredit = 3,
                IsDeleted = 0
            };
            // Act
            int result = InsertLeaveCredits(model);

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Insert_Seminar_Should_Return_1()
        {
            // Arrange
            var model = new Seminar
            {
                EmployeeNo = "1",
                LocalSeminarName = "Local Training",
                LocalSeminarType = "Managerial",
                LocalFrom = new DateTime(2020, 3, 20),
                LocalTo = new DateTime(2020, 4, 1),
                RegionalSeminarName = "Regional Training",
                RegionalSeminarType = "Managerial",
                RegionalFrom = new DateTime(2020, 2, 20),
                RegionalTo = new DateTime(2020, 3, 4),
                NationalSeminarName = "National Training",
                NationalSeminarType = "Managerial",
                NationalFrom = new DateTime(2020, 2, 20),
                NationalTo = new DateTime(2020, 3, 4),
                InternationalSeminarName = "International Training",
                InternationalSeminarType = "Managerial",
                InternationalFrom = new DateTime(2020, 2, 20),
                InternationalTo = new DateTime(2020, 3, 4),
                IsDeleted = 0
            };
            // Act
            int result = InsertSeminar(model);

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Get_Employees_Should_Return_More_Than_1()
        {
            // Arrange
            var dt = new DataTable();
            // Act
            GetAllEmployees(null, 0, dt);
            // Assert
            Assert.AreNotEqual(0, dt.Rows.Count);

            
        }

        [TestMethod]
        public void Update_Employee_Should_Return_1()
        {
            // Arrange
            var model = new Employee
            {
                EmployeeNo = "25",
                FirstName = "Mark",
                MiddleName = "Joe",
                LastName = "Smith",
                Address = "Roxas City",
                Gender = "Male",
                DateOfBirth = new DateTime(1998, 6, 21),
                PlaceOfBirth = "Roxas City, Capiz",
                ContactNo = "09206264079",
                CivilStatus = "Single",
                HighestDegree = "College",
                BsCourse = "BSIT",
                BsYearGraduated = 2019,
                BsSchool = "FCU",
                MasteralCourse = "MASB",
                MasteralYearGraduated = 2020,
                MasteralSchool = "CPU",
                DoctoralCourse = "DIT",
                DoctoralYearGraduated = 2021,
                DoctoralSchool = "FEU",
                Eligibility = "CSE",
                EmployeeType = "Academic",
                Position = "Position I",
                UniqueItemNo = "20FF",
                SalaryGrade = 12,
                Step = 3,
                Department = "College of Education Arts and Science",
                WorkStatus = "Regular",
                HiredDate = new DateTime(2020, 5, 4),
                EndOfContract = null
            };
            // Act
            var result = UpdateEmployee(model);

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Update_Leave_Credit_Should_Return_1()
        {
            // Arrange
            var model = new LeaveCredits
            {
                EmployeeNo = "25",
                LeaveCredit = 4,
                RemainingLeaveCredit = 4
            };
            // Act
            var result = UpdateLeaveCredit(model);

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Delete_Employee_Should_Return_1()
        {
            // Arrange
            var model = new Employee
            {
                EmployeeNo = "1",
                IsDeleted = 0
            };
            // Act
            var result = DeleteEmployee(model);

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Delete_Leave_Credit_Should_Return_1()
        {
            // Arrange
            var model = new LeaveCredits
            {
                EmployeeNo = "1",
                IsDeleted = 0
            };
            // Act
            var result = DeleteLeaveCredit(model);

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Delete_List_Of_Seminars_Should_Return_1()
        {
            // Arrange
            var model = new Seminar
            {
                EmployeeNo = "1",
                IsDeleted = 0
            };
            // Act
            var result = DeleteSeminar(model);

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Get_List_of_Employees_Should_Return_More_Than_1()
        {
            // Arrange
            var dt = new DataTable();
            // Act
            GetAllListOfEmployees(null, "Academic", "Regular", 0, dt);

            // Assert
            Assert.AreNotEqual(0, dt.Rows.Count);
        }

        [TestMethod]
        public void Get_Single_Employee_Should_Not_Return_Null()
        {
            // Arrange
            Employee employee;
            // Act
            employee = GetSingleEmployee("1");

            // Assert
            Assert.IsNotNull(employee);
        }

        [TestMethod]
        public void Get_Single_Seminar_Should_Not_Return_Null()
        {
            // Arrange
            Seminar seminar;
            // Act
            seminar = GetSingleSeminar("2");

            // Assert
            Assert.IsNotNull(seminar);
        }
    }
}
