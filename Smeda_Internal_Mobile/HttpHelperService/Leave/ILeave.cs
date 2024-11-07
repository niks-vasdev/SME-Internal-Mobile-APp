using Data.Models;
using Data.Models.Leave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmedaInternalMobile.HttpHelperService.Leave
{
    public interface ILeave
    {
        Task<GenericResponse<string>> AddLeaveRule(LeavesViewModel leave);
        Task<GenericResponse<FilteredData<LeaveHistoryViewModel>>> ApproverLeaves(bool isArabic, LoadDataArgsViewModel loadDataArgs);
        Task<GenericResponse<string>> Delete(Guid id);
        Task<GenericResponse<List<LeaveRuleListingViewModel>>> GetAll(bool isArabic);
        Task<GenericResponse<List<LeaveRuleListingViewModel>>> GetAllLeaveRequest(bool isArabic);
        Task<GenericResponse<LeavesViewModel>> GetById(Guid id);
        Task<GenericResponse<LeaveHistoryViewModel>> GetLeaveById(Guid id);
        Task<GenericResponse<List<LeaveDetailsViewModel>>> GetProfileLeaveDetails();
        Task<GenericResponse<List<AttendanceLeaveViewModel>>> GetLeaveDetails(string id);
        Task<GenericResponse<string>> LeaveAction(LeaveHistoryViewModel leave);
        Task<GenericResponse<List<LeaveHistoryViewModel>>> LeaveHistory(bool isArabic);
        Task<GenericResponse<GetCountDataByEmployeeIdResult>> GetTodayAllLeaveRequest();
        Task<GenericResult<LeaveHistoryViewModel>> LeaveRequest(LeaveRequestViewModel leave, bool isArabic);
        Task<GenericResponse<List<StatusViewModal>>> GetStatusDetail(Guid id, bool isArabic);
        Task<GenericResponse<int>> GetLeaveBalance(Guid id);
        Task<GenericResponse<List<LeaveRuleListingViewModel>>> GetLeaveRule(bool isArabic);
    }
}
