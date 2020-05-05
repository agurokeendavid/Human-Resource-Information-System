using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRISCapsu.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeNo { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
        public string ContactNo { get; set; }
        public string CivilStatus { get; set; }
        public string HighestDegree { get; set; }
        public string BsCourse { get; set; }
        public int BsYearGraduated { get; set; }
        public string BsSchool { get; set; }
        public string MasteralCourse { get; set; }
        public int MasteralYearGraduated { get; set; }
        public string MasteralSchool { get; set; }
        public string DoctoralCourse { get; set; }
        public int DoctoralYearGraduated { get; set; }
        public string DoctoralSchool { get; set; }
        public string Eligibility { get; set; }
        public string EmployeeType { get; set; }
        public string Position { get; set; }
        public string UniqueItemNo { get; set; }
        public int SalaryGrade { get; set; }
        public int Step { get; set; }
        public string Department { get; set; }
        public string WorkStatus { get; set; }
        public byte[] EmployeePhoto { get; set; }
        public string DocumentPath { get; set; }
        public DateTime HiredDate { get; set; }
        public DateTime? EndOfContract { get; set; }
        public int IsDeleted { get; set; }
    }
}
