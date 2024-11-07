using Data.Models.Leave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Designation
{
    public class ChangeDesignationViewModel
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string? CurrentDesignation { get; set; }
        public string NewDesignation { get; set; }
        public Guid? CurrentDesignationId { get; set; }
        public Guid? NewDesignationId { get; set; }
        public string? UploadDocument { get; set; }
        public string Reason { get; set; }
        public Guid ApproverId { get; set; }
        public string FileData { get; set; }
        public string FileExtension { get; set; }
        public string FileName { get; set; }
        public string Approver { get; set; }
        public string Code { get; set; }
        public string ApproversStatus { get; set; }
        public string ApproversReason { get; set; }
        public string ApproverStatus { get; set; }
        public Guid CurrentUserId { get; set; }
        public string ApproverUploadDocument { get; set; }
        public string Attachment { get; set; }
        public Dictionary<string, string> ApproverDocuments { get; set; }
        public List<OrganisationApprovalViewModel> Approvers { get; set; }
        public Dictionary<string, string> Reasons { get; set; }
        public Dictionary<string, string> ApprovedRoles { get; set; }
        public Dictionary<string, DisplayFile> DisplayFile { get; set; } = new Dictionary<string, DisplayFile>();
        public List<ApproverViewModel> ServiceApprover { get; set; }
    }
}
