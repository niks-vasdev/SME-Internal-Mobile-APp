using Data.Models.Leave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Car
{
    public class VehicleRequestViewModel
    {
        public Guid? Id { get; set; }
        public Guid? TypeOfRequestId { get; set; }
        public Guid? DepartmentId { get; set; }
        public Guid? DesignationId { get; set; }
        public Guid? EmployeeId { get; set; }
        public string TypeOfRequestName { get; set; }
        public string EmployeeName { get; set; }
        public List<string> DepartmentName { get; set; }
        public string Grade { get; set; }
        public string DesignationName { get; set; }
        public string Reason { get; set; }
        public string PhoneNo { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public string ApproverStatus { get; set; }
        public Guid ApproverId { get; set; }
        public List<ApproverViewModel> ServiceApprover { get; set; }
        public Guid CurrentUserId { get; set; }
        public string ApproversReason { get; set; }
        public string ApproverUploadDocument { get; set; }
        public string Approver { get; set; }
    }
}
