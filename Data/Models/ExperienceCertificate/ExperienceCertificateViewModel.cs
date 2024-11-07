using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.ExperienceCertificate
{
    public class ExperienceCertificateViewModel
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public Guid DesignationId { get; set; }
        public string Designation { get; set; }
        public string? DocumentUload { get; set; }
        public string Remarks { get; set; }
        public DateTime? StartingDate { get; set; }
        public DateTime? EndingDate { get; set; }
        public Guid ApproverId { get; set; }
        public int? HrStatus { get; set; }
        public List<Guid?> ApproverIds { get; set; }
    }
}
