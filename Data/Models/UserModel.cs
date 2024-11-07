using Data.Models.Car;
using Data.Models.Leave;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class UserModel
    {
        public UserModel()
        {
            PermissionsList = new();
            RoleList = new();
        }

        public Guid EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public Guid EmployeeType { get; set; }
        public string Designation { get; set; }
        public string Grade { get; set; }
        public Guid? GradeId { get; set; }
        public string CivilCode { get; set; }
        public string Contact { get; set; }
        public Guid ApproverId { get; set; }
        public bool Successful { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }
        public string RoleId { get; set; }
        public bool IsHr { get; set; }
        public List<Guid?> Department { get; set; }
        public List<Guid?> Section { get; set; }
        public List<RoleBasedViewModel>? RoleList { get; set; }
        public List<Leave.Permissions>? PermissionsList { get; set; }
        public List<HolidayViewModel>? UpcomingHolidayList { get; set; }
        public bool IsDetailCompleted { get; set; }

        public bool HasPermission(string entity, string action)
        {
            if (PermissionsList.Any(x => x.Entity.Trim() == entity.Trim() && x.Action.Trim() == action.Trim()))
            {
                return true;
            }
            else
            {
                if (RoleList.Any(y => y.EntityName.Trim() == entity.Trim() && y.ActionName.Trim() == action.Trim()))
                {
                    return true;
                }
                return false;
            }
        }
        public List<Guid?> HrId { get; set; }
  
        public List<ApproverViewModel?> LeaveApprover { get; set; }
        public CarRequestApprover? CarRequestApprover { get; set; }
        public List<ApproverViewModel> ServiceApprover { get; set; }
        public string? DocumentErrorMessage { get; set; }

    }
}
