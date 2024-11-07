using Data.Models.Leave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Car
{
    public class CarRequestApprover
    {
        public List<ApproverViewModel?> DuringHours { get; set; } = new List<ApproverViewModel>();
        public List<ApproverViewModel?> AfterHours { get; set; } = new List<ApproverViewModel?>();
    }
}
