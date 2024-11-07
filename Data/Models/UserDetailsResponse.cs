using Data.Models.Car;
using System;
using System.Collections.Generic;

namespace Data.Models
{
    public class UserDetailsResponse
    {
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeType { get; set; }
        public string Designation { get; set; }
        public string Grade { get; set; }
        public string GradeId { get; set; }
        public string CivilCode { get; set; }
        public string Contact { get; set; }
        public string ApproverId { get; set; }
        public bool Successful { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }
        public string RoleId { get; set; }
        public bool IsHr { get; set; }
        public List<string> Department { get; set; }
        public List<string> Section { get; set; }
        public List<Role> RoleList { get; set; }
        public List<Permission> PermissionsList { get; set; }
        public List<string> UpcomingHolidayList { get; set; }
        public bool IsDetailCompleted { get; set; }
        public List<string> HrId { get; set; }
        public List<Approver> LeaveApprover { get; set; }
        public List<Approver> ServiceApprover { get; set; }
        public List<Approver> DispatchApprover { get; set; }
        public CarRequestApprover CarRequestApprover { get; set; }

        // Additional properties can be added here as needed
    }

    public class Role
    {
        public string Id { get; set; }
        public string RoleName { get; set; }
        public string EntityName { get; set; }
        public string ActionName { get; set; }
    }

    public class Permission
    {
        public string Entity { get; set; }
        public string Action { get; set; }
    }

    public class Approver
    {
        public string ApproverId { get; set; }
        public int Priority { get; set; }
    }

    //public class CarRequestApprover
    //{
    //    public List<Approver> DuringHours { get; set; }
    //    public List<Approver> AfterHours { get; set; }
    //}
}
