using Data.Models;
using Data.Models.Designation;
using Microsoft.Extensions.Configuration;
using SmedaInternalMobile.ApiManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmedaInternalMobile.HttpHelperService.Employee
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IConfiguration _configuration;
        private readonly IApiManager _apiManager;
        public EmployeeService(IConfiguration configuration, IApiManager apiManager)
        {
            _apiManager = apiManager;
            _configuration = configuration;

        }


        public async Task<GenericResponse<List<EmployeeDesignationData>>> GetAllEmployeeAndDesignation(bool isArabic)
        {
            try
            {
                var response = await _apiManager.GetAsync<GenericResponse<List<EmployeeDesignationData>>>(_configuration["BaseUrl"] + $"employee/GetAllEmployeeAndDesignation/{isArabic}");
                return response;
            }
            catch (Exception ex)
            {
                return new GenericResponse<List<EmployeeDesignationData>> { Success = false, Error = ex.Message };
            }
        }



        public async Task<GenericResponse<EmployeeDesignationData>> GetAllEmployeeDesignationData(bool arabic)
        {
            try
            {
                var response = await _apiManager.GetAsync<GenericResponse<EmployeeDesignationData>>(_configuration["BaseUrl"] + $"employee/GetAllEmployeeDesignationData/{arabic}");
                return response;
            }
            catch (Exception ex)
            {
                return new GenericResponse<EmployeeDesignationData> { Success = false, Error = ex.Message };
            }
        }

       

    }
}
