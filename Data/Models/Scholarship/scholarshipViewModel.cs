using Data.Models.Leave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Scholarship
{

    public class ScholarshipViewModel : ICommonProperty
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string University { get; set; }
        public Guid? LevelOfDegreeId { get; set; }
        public string LevelOfDegree { get; set; }
        public string ApproveDocumentForCollage { get; set; }
        public string ApproveDocumentForCollageUid { get; set; }
        public string PaymentInvoiceDocument { get; set; }
        public string PaymentInvoiceDocumentUid { get; set; }
        public string Description { get; set; }
        public Guid ApproverId { get; set; }
        public List<ApproverViewModel> ServiceApprover { get; set; }
    }
}
