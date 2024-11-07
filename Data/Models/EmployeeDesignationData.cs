using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class EmployeeDesignationData
    {
        [Required]
        public Guid? Id { get; set; }
        public string? Designation { get; set; }
        public Guid? DesignationId { get; set; }
        public string? Department { get; set; }
        public Guid? DepartmentId { get; set; }
        public string? Name { get; set; }
        public DateTime? JoiningDate { get; set; }
        public string? Surname { get; set; }
        public string? EmployeeType { get; set; }
    }
}
