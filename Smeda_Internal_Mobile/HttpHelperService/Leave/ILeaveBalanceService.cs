using Data.Models;
using Data.Models.Leave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmedaInternalMobile.HttpHelperService.Leave
{
    public interface ILeaveBalanceService
    {
        Task<GenericResponse<LeaveBalanceViewModel>> GetLeaveBalanceByEmpId(Guid EmpId);
        //Task<GenericResponse<List<EmployeeLeaveBalanceViewModel>>> GetAllEmployeeLeaveBalance();
        //Task<GenericResponse<LeaveBalanceLogsViewModel>> GetEmployeeLeaveHistory(Guid LeaveBalanceId);
        //Task<GenericResponse<EmployeeLeaveBalanceViewModel>> GetLeaveBalanceById(Guid id);
        //Task<GenericResponse<string>> UpdateEmployeeBalance(EmployeeLeaveBalanceViewModel model);
    }
}
