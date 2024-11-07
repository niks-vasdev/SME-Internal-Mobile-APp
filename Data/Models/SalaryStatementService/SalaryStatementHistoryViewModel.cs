using Data.Models.Leave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.SalaryStatementService
{
	public class SalaryStatementHistoryViewModel
	{
		public Guid Id { get; set; }
		public Guid CurrentUserId { get; set; }
		public Guid? EmployeeId { get; set; }
		public string SalaryStatementType { get; set; }
		public string SalaryStatementTypeEn { get; set; }
		public string Approver { get; set; }
		public string Code { get; set; }
		public string FileData { get; set; }
		public string FileExtension { get; set; }
		public string FileName { get; set; }
		public string EmployeeName { get; set; }
		public string ServiceType { get; set; }
		public string ApproverUploadDocument { get; set; }
		public string ApproversStatus { get; set; }
		public string ApproversReason { get; set; }
		public Dictionary<string, string> Reasons { get; set; }
		public Dictionary<string, string> ApproverDocuments { get; set; }
		public List<OrganisationApprovalViewModel> Approvers { get; set; }
		public Dictionary<string, string> ApprovedRoles { get; set; }
		public Dictionary<string, DisplayFile> DisplayFile { get; set; } = new Dictionary<string, DisplayFile>();
	}
}
