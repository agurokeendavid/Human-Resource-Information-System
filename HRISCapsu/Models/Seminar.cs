using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRISCapsu.Models
{
    public class Seminar
    {
        public int Id { get; set; }
        public string EmployeeNo { get; set; }
        public string LocalSeminarName { get; set; }
        public string LocalSeminarType { get; set; }
        public DateTime? LocalFrom { get; set; }
        public DateTime? LocalTo { get; set; }
        public string RegionalSeminarName { get; set; }
        public string RegionalSeminarType { get; set; }
        public DateTime? RegionalFrom { get; set; }
        public DateTime? RegionalTo { get; set; }
        public string NationalSeminarName { get; set; }
        public string NationalSeminarType { get; set; }
        public DateTime? NationalFrom { get; set; }
        public DateTime? NationalTo { get; set; }
        public string InternationalSeminarName { get; set; }
        public string InternationalSeminarType { get; set; }
        public DateTime? InternationalFrom { get; set; }
        public DateTime? InternationalTo { get; set; }
        public int NumberOfSeminars { get; set; }
        public int IsDeleted { get; set; }
    }
}
