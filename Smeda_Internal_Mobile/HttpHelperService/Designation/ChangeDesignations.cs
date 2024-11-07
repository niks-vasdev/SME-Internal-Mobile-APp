using Data.Models;
using Data.Models.Designation;
using Data.Models.Leave;
using Microsoft.Extensions.Configuration;
using SmedaInternalMobile.ApiManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmedaInternalMobile.HttpHelperService.Designation
{
    public class ChangeDesignations : IChangeDesignations
    {
        private readonly IConfiguration _configuration;
        private readonly IApiManager _apiManager;
        public ChangeDesignations(IConfiguration configuration, IApiManager apiManager)
        {
            _apiManager = apiManager;
            _configuration = configuration;
        }
        public async Task<GenericResponse<Guid>> AddDesignation(ChangeDesignationViewModel model)
        {
            try
            {
                var response = await _apiManager.PostAsync<GenericResponse<Guid>>(_configuration["BaseUrl"] + "ChangeDesignation/AddDesignation", model);
                return response;
            }
            catch (Exception ex)
            {
                return new GenericResponse<Guid>() { Success = false, Error = ex.Message };
            }
        }
        public async Task<GenericResponse<List<ChangeDesignationViewModel>>> GetAllChangeDesignationData(bool isArabic)
        {
            try
            {
                var response = await _apiManager.GetAsync<GenericResponse<List<ChangeDesignationViewModel>>>(_configuration["BaseUrl"] + $"ChangeDesignation/GetAllChangeDesignationData/{isArabic}");
                return response;
            }
            catch (Exception ex)
            {
                return new GenericResponse<List<ChangeDesignationViewModel>> { Success = false, Error = ex.Message };
            }
        }

        public async Task<GenericResponse<List<ChangeDesignationViewModel>>> ApproverChangeDesignation(bool isArabic)
        {
            try
            {
                var response = await _apiManager.GetAsync<GenericResponse<List<ChangeDesignationViewModel>>>(_configuration["BaseUrl"] + $"ChangeDesignation/ApproverChangeDesignation/{isArabic}");
                return response;
            }
            catch (Exception ex)
            {
                return new GenericResponse<List<ChangeDesignationViewModel>> { Success = false, Error = ex.Message };
            }
        }
        public async Task<GenericResponse<ChangeDesignationViewModel>> GetChangeDesignationById(Guid id, bool isArabic)
        {
            try
            {
                var response = await _apiManager.GetAsync<GenericResponse<ChangeDesignationViewModel>>(_configuration["BaseUrl"] + $"ChangeDesignation/GetChangeDesignationById/{id}");
                return response;
            }
            catch (Exception ex)
            {
                return new GenericResponse<ChangeDesignationViewModel> { Success = false, Error = ex.Message };
            }
        }
        public async Task<GenericResponse<string>> ChangeDesignationAction(ChangeDesignationViewModel model)
        {
            try
            {
                var response = await _apiManager.PostAsync<GenericResponse<string>>(_configuration["BaseUrl"] + "ChangeDesignation/ChangeDesignationAction", model);
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
                var response = await _apiManager.GetAsync<GenericResponse<List<StatusViewModal>>>(_configuration["BaseUrl"] + $"ChangeDesignation/GetStatusDetail/{id}/{isArabic}");
                return response;
            }
            catch (Exception ex)
            {
                return new GenericResponse<List<StatusViewModal>> { Success = false, Error = ex.Message };
            }
        }

    }
}
