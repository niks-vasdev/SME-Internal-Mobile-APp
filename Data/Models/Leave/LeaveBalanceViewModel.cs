using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Leave
{
    public class LeaveBalanceViewModel
    {
        public Guid? Id { get; set; }
        public Guid? EmployeeId { get; set; }
        public int Balance { get; set; }
        public int NoOfDays { get; set; }
    }
}
