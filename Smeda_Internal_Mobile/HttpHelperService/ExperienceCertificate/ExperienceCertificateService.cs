using Data.Models;
using Data.Models.ExperienceCertificate;
using Data.Models.Leave;
using Microsoft.Extensions.Configuration;
using SmedaInternalMobile.ApiManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmedaInternalMobile.HttpHelperService.ExperienceCertificate
{
    public class ExperienceCertificateService : IExperienceCertificateService
    {
        private readonly IApiManager _apiManager;
        private readonly IConfiguration _configuration;

        public ExperienceCertificateService(IApiManager apiManager, IConfiguration configuration)
        {
            _apiManager = apiManager;
            _configuration = configuration;
        }
        public async Task<GenericResponse<Guid>> AddExprienceCertificate(ExperienceCertificateViewModel experienceCertificateViewModel)
        {
            try
            {
                var response = await _apiManager.PostAsync<GenericResponse<Guid>>(_configuration["BaseUrl"] + "ExperienceCertificate/AddExprienceCertificate", experienceCertificateViewModel);
                return response;
            }
            catch (Exception ex)
            {
                return new GenericResponse<Guid> { Success = false, Error = ex.Message };
            }
        }



        public async Task<GenericResponse<List<ExperienceCertificateHistoryViewModel>>> ApproveExperienceCertificate(bool isArabic)
        {
            try
            {
                var response = await _apiManager.GetAsync<GenericResponse<List<ExperienceCertificateHistoryViewModel>>>(_configuration["BaseUrl"] + $"ExperienceCertificate/ApproveExperienceCertificate/{isArabic}");
                return response;
            }
            catch (Exception ex)
            {
                return new GenericResponse<List<ExperienceCertificateHistoryViewModel>> { Success = false, Error = ex.Message };
            }
        }

        public async Task<GenericResponse<string>> ExperienceCertificateAction(ExperienceCertificateHistoryViewModel experienceCertificateViewModel)
        {
            try
            {
                var response = await _apiManager.PostAsync<GenericResponse<string>>(_configuration["BaseUrl"] + "ExperienceCertificate/ExperienceCertificateAction", experienceCertificateViewModel);
                return response;
            }
            catch (Exception ex)
            {
                return new GenericResponse<string> { Success = false, Error = ex.Message };
            }
        }

        public async Task<GenericResponse<List<ExperienceCertificateHistoryViewModel>>> GetExperienceCertificates(bool isArabic)
        {
            try
            {
                var response = await _apiManager.GetAsync<GenericResponse<List<ExperienceCertificateHistoryViewModel>>>(_configuration["BaseUrl"] + $"ExperienceCertificate/GetExperienceCertificates/{isArabic}");
                return response;
            }
            catch (Exception ex)
            {
                return new GenericResponse<List<ExperienceCertificateHistoryViewModel>> { Success = false, Error = ex.Message };
            }
        }

        public async Task<GenericResponse<ExperienceCertificateHistoryViewModel>> GetExperienceCertificatesById(Guid hrActionId, bool isArabic)
        {
            try
            {
                var response = await _apiManager.GetAsync<GenericResponse<ExperienceCertificateHistoryViewModel>>(_configuration["BaseUrl"] + $"ExperienceCertificate/GetExperienceCertificatesById/{hrActionId}/{isArabic}");
                return response;
            }
            catch (Exception ex)
            {
                return new GenericResponse<ExperienceCertificateHistoryViewModel> { Success = false, Error = ex.Message };
            }
        }

        public async Task<GenericResponse<List<StatusViewModal>>> GetStatusDetail(Guid id, bool isArabic)
        {
            try
            {
                var response = await _apiManager.GetAsync<GenericResponse<List<StatusViewModal>>>(_configuration["BaseUrl"] + $"ExperienceCertificate/GetStatusDetail/{id}/{isArabic}");
                return response;
            }
            catch (Exception ex)
            {
                return new GenericResponse<List<StatusViewModal>> { Success = false, Error = ex.Message };
            }
        }
    }
}
