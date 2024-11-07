using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Leave
{
    public class AttendanceLeaveViewModel
    {
        public Guid? EmployeeId { get; set; }
        public Guid? LeaveRulesId { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public int NumberOfDays { get; set; }
        public string? Reason { get; set; }
        public int? ApproverStatus { get; set; }
        public string? ApproverReason { get; set; }
        public int? HrStatus { get; set; }
        public string? HrReason { get; set; }
        public Guid? ApproverId { get; set; }
        public string? UploadDocument { get; set; }
        public string? HrUploadDocument { get; set; }
        public string? ApproverUploadDocument { get; set; }
    }
}
