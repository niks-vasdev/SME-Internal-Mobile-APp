using Data.Enums;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class GradeRequestModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string CurrentGrade { get; set; }
        [Required]
        public string NewGrade { get; set; }

        [Required]
        public string Reason { get; set; }
        public RequestType RequestStatus { get; set; }

        public RequestType HRStatus { get; set; }

        [Required]
        public string? HRReason { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }


        public byte[]? DocumentData { get; set; }
        public DocumentType DocumentType { get; set; }

        public byte[]? HRDocumentData { get; set; }
        public DocumentType HRDocumentType { get; set; }
    }
}
