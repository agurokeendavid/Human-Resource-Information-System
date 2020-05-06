using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRISCapsu.Models
{
    public class LeaveCredits
    {
        public int Id { get; set; }
        public string EmployeeNo { get; set; }
        public int? LeaveCredit { get; set; }
        public int? RemainingLeaveCredit { get; set; }
        public byte IsDeleted { get; set; }
    }
}
