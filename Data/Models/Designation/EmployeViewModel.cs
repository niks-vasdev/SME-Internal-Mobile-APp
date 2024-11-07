using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Designation
{
    public class EmployeViewModel
    {
        public Guid? Id { get; set; }

        //[Required]
        public Guid? SurnameId { get; set; }

        //[Required]
        public string RoleId { get; set; }


        //[Required(ErrorMessage = "Full Name is required")]
        public string FullName { get; set; }


        //[Required(ErrorMessage = "Date Of Birth is required")]
        [DataType(DataType.DateTime)]
        public DateTime? DateOfBirth { get; set; }

        //[Required(ErrorMessage = "Contact is required")]
        public string Contact { get; set; }

        //[Required]
        //[EmailAddress]
        //[DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        //[Required(ErrorMessage = "Gender is required")]
        public Guid? GenderId { get; set; }

        //[Required(ErrorMessage = "Village is required")]
        public Guid? WilayatId { get; set; }

        //[Required]
        //public IEnumerable<Guid> ReportingToId    { get; set; }

        // [Required(ErrorMessage = "Organization is required")]
        //public Guid? OrganizationId { get; set; }
        public IEnumerable<Guid?> OrganizationId { get; set; }


        //[Required(ErrorMessage = "Governate is required")]
        public Guid? GovernateId { get; set; }

        //[Required(ErrorMessage = "Joining date is required")]
        //[DataType(DataType.Date)]
        public DateTime JoiningDate { get; set; }

        //public string? CV { get; set; }
        //[Required(ErrorMessage ="Profile pic is required")]
        //public string ProfilePhoto { get; set; }

        //[Required(ErrorMessage = "Employee code is required")]
        public string EmployeeCode { get; set; }
        //[Required(ErrorMessage = "Designation is required")]
        public Guid? DesignationId { get; set; }
        //[Required(ErrorMessage = "Department is required")]
        //public Guid? DepartmentId { get; set; }
        public Guid? DepartmentId { get; set; }
        public Guid? DepartmentSectionId { get; set; }
        public IEnumerable<Guid?> EmployeeDepartmentId { get; set; }
        public IEnumerable<Guid?> EmployeeDepartmentSectionId { get; set; }

        //[Required(ErrorMessage = "Nationality is required")]
        public Guid? NationalityId { get; set; }
        //[Required(ErrorMessage = "Religion is required")]
        public Guid? ReligionId { get; set; }
        // [Required]
        //[EmailAddress]
        //[DataType(DataType.EmailAddress)]
        public string OfficeEmail { get; set; }
        //[Required(ErrorMessage = "Employee Type is required")]
        public Guid? EmployeeTypeId { get; set; }
        // [Required(ErrorMessage = "Status is required")]
        public Guid? MaritalStatusId { get; set; }
        public string? EmergencyFullName { get; set; }
        public string? RelationShip { get; set; }
        //[Required(ErrorMessage ="Grade is required")]
        public Guid? GradeId { get; set; }
        public string? EmergencyEmail { get; set; }
        public string? EmergencyContact { get; set; }
        public SalaryViewModel Salary { get; set; }
        public Guid? ApproverId { get; set; }
        public bool IsDetailCompleted { get; set; }

        public string fileData { get; set; }
        public string fileExtension { get; set; }
        public string fileName { get; set; }
        public string PdffileName { get; set; }
        public string address { get; set; }
        public bool IsHr { get; set; }
        public bool InCommittee { get; set; }
        public Guid? DirectoratesId { get; set; }

    }
}