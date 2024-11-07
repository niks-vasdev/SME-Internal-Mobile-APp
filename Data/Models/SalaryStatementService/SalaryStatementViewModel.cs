using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.SalaryStatementService
{
	public class SalaryStatementViewModel
	{
		public Guid? Id { get; set; }
		public Guid? SalaryStatementTypeId { get; set; }
		[Required]
		public Guid? EmployeeId { get; set; }
		[Required]
		public Guid ApproverId { get; set; }
		public List<Guid?> ApproverIds { get; set; }
		public int? HrStatus { get; set; }
		public string HrReason { get; set; }
		public int? ApproverStatus { get; set; }
		public string ApproverReason { get; set; }
	}
}
