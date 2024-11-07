using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Leave
{
   
        public class LeaveHistoryViewModel
        {
            public Guid Id { get; set; }
            public Guid? EmployeeId { get; set; }

            [Required]
            public string EmployeeName { get; set; }

            [Required]
            public string Code { get; set; }

            public string Attachment { get; set; }

            [Required]
            public DateTime From { get; set; }

            [Required]
            public DateTime To { get; set; }

            [Required]
            public int NumberOfDays { get; set; }

            [Required]
            public string Approver { get; set; }
            public List<string?> EmployeeDepartment { get; set; }
            public List<string?> EmployeeSection { get; set; }

            public string ApproversStatus { get; set; }
            public string ApproversReason { get; set; }
            public string LeaveType { get; set; }
            public string FileData { get; set; }
            public string FileExtension { get; set; }
            public string FileName { get; set; }
            public string ApproverUploadDocument { get; set; }
            public Guid CurrentUserId { get; set; }
            public string LeaveReason { get; set; }
            public Dictionary<string, string> Reasons { get; set; }
            public Dictionary<string, string> ApproverDocuments { get; set; }
            public List<OrganisationApprovalViewModel> Approvers { get; set; }
            public Dictionary<string, string> ApprovedRoles { get; set; }
            public Dictionary<string, DisplayFile> DisplayFile { get; set; } = new Dictionary<string, DisplayFile>();
        }

        public class DisplayFile
        {
            public string FileData { get; set; }
            public string FileExtension { get; set; }
            public string FileName { get; set; }
        }
    
}
