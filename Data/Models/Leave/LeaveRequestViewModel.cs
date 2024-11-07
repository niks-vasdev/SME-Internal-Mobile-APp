using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Leave
{
    public class LeaveRequestViewModel
    {
        public Guid EmployeeId { get; set; }
        public Guid Id { get; set; }
        [Required]
        public int NumberOfdays { get; set; }
        [Required]
        public Guid? LeaveTypeId { get; set; }
        [Required]
        public DateTime? From { get; set; }
        [Required]
        public DateTime? To { get; set; }
        [Required]
        public Guid ApproverId { get; set; }
        public string? UploadDocument { get; set; }

        public string? Reason { get; set; }
        //public List<Guid?> Approvers { get; set; }
        public List<ApproverViewModel?> Approvers { get; set; }
        public Guid? SubstituteId { get; set; }
    }
}
