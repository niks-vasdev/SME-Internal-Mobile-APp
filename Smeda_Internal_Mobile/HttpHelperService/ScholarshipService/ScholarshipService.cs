using Data.Models;
using Data.Models.Leave;
using Data.Models.Scholarship;
using Microsoft.Extensions.Configuration;
using SmedaInternalMobile.ApiManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmedaInternalMobile.HttpHelperService.ScholarshipService
{
    public class ScholarshipService : IScholarshipService
    {
        private readonly IConfiguration _configuration;
        private readonly IApiManager _apiManager;

        public ScholarshipService(IConfiguration configuration, IApiManager apiManager)
        {
            _configuration = configuration;
            _apiManager = apiManager;
        }
        public async Task<GenericResponse<Guid>> AddScholarship(ScholarshipViewModel scholarshipViewModel)
        {
            try
            {
                var result = await _apiManager.PostAsync<GenericResponse<Guid>>(_configuration["BaseUrl"] + "Scholarship/AddScholarship", scholarshipViewModel);
                return result;
            }
            catch (Exception ex)
            {
                return new GenericResponse<Guid>() { Success = false, Error = ex.Message };
            }
        }

        public async Task<GenericResponse<List<ScholarshipHistoryViewModel>>> GetAlldata(bool isArabic)
        {
            try
            {
                var response = await _apiManager.GetAsync<GenericResponse<List<ScholarshipHistoryViewModel>>>(_configuration["BaseUrl"] + $"Scholarship/GetAllScholarship/{isArabic}");
                return response;
            }
            catch (Exception ex)
            {
                return new GenericResponse<List<ScholarshipHistoryViewModel>> { Success = false, Error = ex.Message };
            }
        }

        public async Task<GenericResponse<List<ScholarshipHistoryViewModel>>> ApproveScholarship(bool isArabic)
        {
            try
            {
                var result = await _apiManager.GetAsync<GenericResponse<List<ScholarshipHistoryViewModel>>>(_configuration["BaseUrl"] + $"Scholarship/ApproveScholarshipLeave/{isArabic}");
                return result;
            }
            catch (Exception ex)
            {
                return new GenericResponse<List<ScholarshipHistoryViewModel>> { Success = false, Error = ex.Message };
            }
        }

        public async Task<GenericResponse<ScholarshipHistoryViewModel>> GetScholarshipById(Guid id, bool isArabic)
        {
            try
            {
                var response = await _apiManager.GetAsync<GenericResponse<ScholarshipHistoryViewModel>>(_configuration["BaseUrl"] + $"scholarship/GetScholarshipById/{id}/{isArabic}");
                return response;
            }
            catch (Exception ex)
            {
                return new GenericResponse<ScholarshipHistoryViewModel> { Success = false, Error = ex.Message };
            }
        }
        public async Task<GenericResponse<string>> ScholarshipAction(ScholarshipHistoryViewModel scholarship)
        {
            try
            {
                var response = await _apiManager.PostAsync<GenericResponse<string>>(_configuration["BaseUrl"] + "scholarship/ScholarshipAction", scholarship);
                return response;
            }
            catch (Exception ex)
            {
                return new GenericResponse<string> { Success = false, Error = ex.Message };
            }
        }

        public async Task<GenericResponse<List<StatusViewModal>>> GetStatusDetail(Guid id, bool isArabic)
        {
            try
            {
                var response = await _apiManager.GetAsync<GenericResponse<List<StatusViewModal>>>(_configuration["BaseUrl"] + $"scholarship/GetStatusDetail/{id}/{isArabic}");
                return response;
            }
            catch (Exception ex)
            {
                return new GenericResponse<List<StatusViewModal>> { Success = false, Error = ex.Message };
            }
        }
    }
}
