using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Leave
{
    public class LeaveRuleListingViewModel
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string? Description { get; set; }
        public string? Gender { get; set; }
        public string Grade { get; set; }
        public string LeaveTypeEn { get; set; }
        public string LeaveType { get; set; }
        public string LeaveTypeAr { get; set; }
        public string? MaritalStatus { get; set; }
        public string Religion { get; set; }
        public bool OneTimeEntireService { get; set; }
        public Dictionary<string, string> Reason { get; set; }
        public int? MaxLeave { get; set; }

    }
}
