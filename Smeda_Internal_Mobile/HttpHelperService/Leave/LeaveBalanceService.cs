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
    public class LeaveBalanceService : ILeaveBalanceService
    {
        private readonly IApiManager _apiManager;
        private readonly IConfiguration _configuration;

        public LeaveBalanceService(IApiManager apiManager, IConfiguration configuration)
        {
            _apiManager = apiManager;
            _configuration = configuration;

        }

        //public async Task<GenericResponse<List<EmployeeLeaveBalanceViewModel>>> GetAllEmployeeLeaveBalance()
        //{
        //    try
        //    {
        //        var response = await _apiManager.GetAsync<GenericResponse<List<EmployeeLeaveBalanceViewModel>>>(_configuration["BaseUrl"] + $"LeaveBalance/GetAllEmployeeLeaveBalance");
        //        return response;
        //    }
        //    catch (Exception ex)
        //    {
        //        return new GenericResponse<List<EmployeeLeaveBalanceViewModel>> { Success = false, Error = ex.Message };
        //    }
        //}

        public async Task<GenericResponse<LeaveBalanceViewModel>> GetLeaveBalanceByEmpId(Guid EmpId)
        {
            try
            {
                var response = await _apiManager.GetAsync<GenericResponse<LeaveBalanceViewModel>>(_configuration["BaseUrl"] + $"LeaveBalance/GetLeveBalanceByEmpId/{EmpId}");
                return response;
            }
            catch (Exception ex)
            {
                return new GenericResponse<LeaveBalanceViewModel> { Success = false, Error = ex.Message };
            }
        }

        //public async Task<GenericResponse<LeaveBalanceLogsViewModel>> GetEmployeeLeaveHistory(Guid LeaveBalanceId)
        //{
        //    try
        //    {
        //        var response = await _apiManager.GetAsync<GenericResponse<LeaveBalanceLogsViewModel>>(_configuration["BaseUrl"] + $"LeaveBalance/GetEmployeeLeaveHistory/{LeaveBalanceId}");
        //        return response;
        //    }
        //    catch (Exception ex)
        //    {
        //        return new GenericResponse<LeaveBalanceLogsViewModel> { Success = false, Error = ex.Message };
        //    }
        //}

        //public async Task<GenericResponse<EmployeeLeaveBalanceViewModel>> GetLeaveBalanceById(Guid id)
        //{
        //    try
        //    {
        //        var response = await _apiManager.GetAsync<GenericResponse<EmployeeLeaveBalanceViewModel>>(_configuration["BaseUrl"] + $"LeaveBalance/GetLeaveBalanceById/{id}");
        //        return response;
        //    }
        //    catch (Exception ex)
        //    {
        //        return new GenericResponse<EmployeeLeaveBalanceViewModel> { Success = false, Error = ex.Message };
        //    }
        //}
        //public async Task<GenericResponse<string>> UpdateEmployeeBalance(EmployeeLeaveBalanceViewModel model)
        //{
        //    try
        //    {
        //        var response = await _apiManager.PostAsync<GenericResponse<string>>(_configuration["BaseUrl"] + $"LeaveBalance/UpdateEmployeeBalance", model);
        //        return response;
        //    }
        //    catch (Exception ex)
        //    {
        //        return new GenericResponse<string> { Success = false, Error = ex.Message };
        //    }
        //}
    }
}
