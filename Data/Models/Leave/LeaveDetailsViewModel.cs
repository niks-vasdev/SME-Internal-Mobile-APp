using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Leave
{
    public class LeaveDetailsViewModel
    {
        public Guid Id { get; set; }
        public string LeaveTypeEn { get; set; }
        public string LeaveTypeAr { get; set; }
        public string LeaveType { get; set; }
        public int TotalLeaves { get; set; }
        public int AvailedLeaves { get; set; }

        public int PendingLeave { get; set; }
        public int TotalAppliedLeaves { get; set; }

    }
}
