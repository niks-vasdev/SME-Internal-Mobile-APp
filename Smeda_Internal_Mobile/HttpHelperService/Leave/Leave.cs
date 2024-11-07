using Data.Models;
using Data.Models.Leave;
using Microsoft.Extensions.Configuration;
using SmedaInternalMobile.ApiManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmedaInternalMobile.HttpHelperService.Leave
{
    public class Leave : ILeave
    {
        private readonly IConfiguration _configuration;
        private readonly IApiManager _apiManager;
        public Leave(IConfiguration configuration, IApiManager apiManager)
        {
            _configuration = configuration;
            _apiManager = apiManager;
        }
        public async Task<GenericResponse<string>> AddLeaveRule(LeavesViewModel leave)
        {
            try
            {
                var response = await _apiManager.PostAsync<GenericResponse<string>>(_configuration["BaseUrl"] + "leave/AddLeaveRule", leave);
                return response;
            }
            catch (Exception ex)
            {
                return new GenericResponse<string>() { Success = false, Error = ex.Message };
            }
        }

 

        public async Task<GenericResponse<FilteredData<LeaveHistoryViewModel>>> ApproverLeaves(bool isArabic, LoadDataArgsViewModel loadDataArgs)
        {
            try
            {
                var response = await _apiManager.PostAsync<GenericResponse<FilteredData<LeaveHistoryViewModel>>>(_configuration["BaseUrl"] + $"leave/ApproverLeaves/{isArabic}", loadDataArgs);
                return response;
            }
            catch (Exception ex)
            {
                return new GenericResponse<FilteredData<LeaveHistoryViewModel>> { Success = false, Error = ex.Message };
            }
        }

        public async Task<GenericResponse<string>> Delete(Guid id)
        {
            try
            {
                var response = await _apiManager.DeleteAsync<GenericResponse<string>>(_configuration["BaseUrl"] + $"leave/Delete/{id}");
                return response;
            }
            catch (Exception ex)
            {
                return new GenericResponse<string> { Success = false, Error = ex.Message };
            }
        }

        public async Task<GenericResponse<List<LeaveRuleListingViewModel>>> GetAll(bool isArabic)
        {
            try
            {
                var response = await _apiManager.GetAsync<GenericResponse<List<LeaveRuleListingViewModel>>>(_configuration["BaseUrl"] + $"leave/GetAll/{isArabic}");
                return response;
            }
            catch (Exception ex)
            {
                return new GenericResponse<List<LeaveRuleListingViewModel>> { Success = false, Error = ex.Message };
            }
        }

        public async Task<GenericResponse<List<LeaveRuleListingViewModel>>> GetAllLeaveRequest(bool isArabic)
        {
            try
            {
                var response = await _apiManager.GetAsync<GenericResponse<List<LeaveRuleListingViewModel>>>(_configuration["BaseUrl"] + $"leave/GetAllLeaveRequest");
                return response;
            }
            catch (Exception ex)
            {
                return new GenericResponse<List<LeaveRuleListingViewModel>> { Success = false, Error = ex.Message };
            }
        }

        public async Task<GenericResponse<LeavesViewModel>> GetById(Guid id)
        {
            try
            {
                var response = await _apiManager.GetAsync<GenericResponse<LeavesViewModel>>(_configuration["BaseUrl"] + $"leave/GetById/{id}");
                return response;
            }
            catch (Exception ex)
            {
                return new GenericResponse<LeavesViewModel> { Success = false, Error = ex.Message };
            }
        }

        public async Task<GenericResponse<LeaveHistoryViewModel>> GetLeaveById(Guid id)
        {
            try
            {
                var response = await _apiManager.GetAsync<GenericResponse<LeaveHistoryViewModel>>(_configuration["BaseUrl"] + $"leave/GetLeaveById/{id}");
                return response;
            }
            catch (Exception ex)
            {
                return new GenericResponse<LeaveHistoryViewModel> { Success = false, Error = ex.Message };
            }
        }

        public async Task<GenericResponse<List<LeaveDetailsViewModel>>> GetProfileLeaveDetails()
        {
            try
            {
                var response = await _apiManager.GetAsync<GenericResponse<List<LeaveDetailsViewModel>>>(_configuration["BaseUrl"] + "leave/GetProfileLeaveDetails");
                return response;
            }
            catch (Exception ex)
            {
                return new GenericResponse<List<LeaveDetailsViewModel>> { Success = false, Error = ex.Message };
            }
        }
        public async Task<GenericResponse<List<AttendanceLeaveViewModel>>> GetLeaveDetails(string id)
        {
            try
            {
                var response = await _apiManager.GetAsync<GenericResponse<List<AttendanceLeaveViewModel>>>(_configuration["BaseUrl"] + $"leave/GetLeaveDetails/{id}");
                return response;
            }
            catch (Exception ex)
            {
                return new GenericResponse<List<AttendanceLeaveViewModel>> { Success = false, Error = ex.Message };
            }
        }

        public async Task<GenericResponse<string>> LeaveAction(LeaveHistoryViewModel leave)
        {
            try
            {
                var response = await _apiManager.PostAsync<GenericResponse<string>>(_configuration["BaseUrl"] + "leave/LeaveAction", leave);
                return response;
            }
            catch (Exception ex)
            {
                return new GenericResponse<string> { Success = false, Error = ex.Message };
            }
        }

        public async Task<GenericResponse<List<LeaveHistoryViewModel>>> LeaveHistory(bool isArabic)
        {
            try
            {
                var response = await _apiManager.GetAsync<GenericResponse<List<LeaveHistoryViewModel>>>(_configuration["BaseUrl"] + $"leave/GetLeaveHistory/{isArabic}");
                return response;
            }
            catch (Exception ex)
            {
                return new GenericResponse<List<LeaveHistoryViewModel>> { Success = false, Error = ex.Message };
            }
        }

        public async Task<GenericResult<LeaveHistoryViewModel>> LeaveRequest(LeaveRequestViewModel leave, bool isArabic)
        {
            try
            {
                var response = await _apiManager.PostAsync<GenericResult<LeaveHistoryViewModel>>(_configuration["BaseUrl"] + $"leave/LeaveRequest/{isArabic}", leave);
                return response;
            }
            catch (Exception ex)
            {
                return new GenericResult<LeaveHistoryViewModel> { Successful = false, Error = ex.Message };
            }
        }
        public async Task<GenericResponse<GetCountDataByEmployeeIdResult>> GetTodayAllLeaveRequest()
        {
            try
            {
                var response = await _apiManager.GetAsync<GenericResponse<GetCountDataByEmployeeIdResult>>(_configuration["BaseUrl"] + $"leave/GetTodayAllLeaveRequest");
                return response;
            }
            catch (Exception ex)
            {
                return new GenericResponse<GetCountDataByEmployeeIdResult> { Success = false, Error = ex.Message };
            }
        }

        public async Task<GenericResponse<List<StatusViewModal>>> GetStatusDetail(Guid id, bool isArabic)
        {
            try
            {
                var response = await _apiManager.GetAsync<GenericResponse<List<StatusViewModal>>>(_configuration["BaseUrl"] + $"leave/GetStatusDetail/{id}/{isArabic}");
                return response;
            }
            catch (Exception ex)
            {
                return new GenericResponse<List<StatusViewModal>> { Success = false, Error = ex.Message };
            }
        }

        public async Task<GenericResponse<int>> GetLeaveBalance(Guid id)
        {
            try
            {
                var response = await _apiManager.GetAsync<GenericResponse<int>>(_configuration["BaseUrl"] + $"leave/GetLeaveBalance/{id}");
                return response;
            }
            catch (Exception ex)
            {
                return new GenericResponse<int> { Success = false, Error = ex.Message };
            }
        }

        public async Task<GenericResponse<List<LeaveRuleListingViewModel>>> GetLeaveRule(bool isArabic)
        {
            try
            {
                var response = await _apiManager.GetAsync<GenericResponse<List<LeaveRuleListingViewModel>>>(_configuration["BaseUrl"] + $"leave/GetLeaveRule/{isArabic}");
                return response;
            }
            catch (Exception ex)
            {
                return new GenericResponse<List<LeaveRuleListingViewModel>> { Success = false, Error = ex.Message };
            }
        }
    }
}
