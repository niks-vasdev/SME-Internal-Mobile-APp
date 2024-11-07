using Data.Models;
using Data.Models.Car;
using Data.Models.Leave;
using Microsoft.Extensions.Configuration;
using SmedaInternalMobile.ApiManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmedaInternalMobile.HttpHelperService.Car
{
    public class VehicleRequest : IVehicleRequest
    {
        private readonly IConfiguration _configuration;
        private readonly IApiManager _apiManager;
        public VehicleRequest(IConfiguration configuration, IApiManager apiManager)
        {
            _configuration = configuration;
            _apiManager = apiManager;
        }
        public async Task<GenericResponse<Guid>> AddVehicleRequest(VehicleRequestViewModel vehicleRequestViewModel)
        {
            try
            {
                var result = await _apiManager.PostAsync<GenericResponse<Guid>>(_configuration["BaseUrl"] + "VehicleRequest/AddVehicleRequest", vehicleRequestViewModel);
                return result;
            }
            catch (Exception ex)
            {
                return new GenericResponse<Guid>() { Success = false, Error = ex.Message };
            }
        }

        public async Task<GenericResponse<List<VehicleRequestViewModel>>> ApproverVehicleRequest(bool isArabic)
        {
            try
            {
                var response = await _apiManager.GetAsync<GenericResponse<List<VehicleRequestViewModel>>>(_configuration["BaseUrl"] + $"VehicleRequest/ApproverVehicleRequest/{isArabic}");
                return response;
            }
            catch (Exception ex)
            {
                return new GenericResponse<List<VehicleRequestViewModel>> { Success = false, Error = ex.Message };
            }
        }

        public async Task<GenericResponse<List<VehicleRequestViewModel>>> GetAlldata(bool isArabic)
        {
            try
            {
                var response = await _apiManager.GetAsync<GenericResponse<List<VehicleRequestViewModel>>>(_configuration["BaseUrl"] + $"VehicleRequest/GetAlldata/{isArabic}");
                return response;
            }
            catch (Exception ex)
            {
                return new GenericResponse<List<VehicleRequestViewModel>> { Success = false, Error = ex.Message };
            }
        }

        public async Task<GenericResponse<List<StatusViewModal>>> GetStatusDetails(Guid id, bool isArabic)
        {
            try
            {
                var response = await _apiManager.GetAsync<GenericResponse<List<StatusViewModal>>>(_configuration["BaseUrl"] + $"VehicleRequest/GetStatusDetail/{id}/{isArabic}");
                return response;
            }
            catch (Exception ex)
            {
                return new GenericResponse<List<StatusViewModal>> { Success = false, Error = ex.Message };
            }
        }

        public async Task<GenericResponse<VehicleRequestViewModel>> GetVehicleRequestById(Guid id, bool isArabic)
        {
            try
            {
                var response = await _apiManager.GetAsync<GenericResponse<VehicleRequestViewModel>>(_configuration["BaseUrl"] + $"VehicleRequest/GetVehicleRequestById/{id}");
                return response;
            }
            catch (Exception ex)
            {
                return new GenericResponse<VehicleRequestViewModel> { Success = false, Error = ex.Message };
            }
        }

        public async Task<GenericResponse<string>> VehicleRequestAction(VehicleRequestViewModel model)
        {
            try
            {
                var response = await _apiManager.PostAsync<GenericResponse<string>>(_configuration["BaseUrl"] + "VehicleRequest/VehicleRequestAction", model);
                return response;
            }
            catch (Exception ex)
            {
                return new GenericResponse<string> { Success = false, Error = ex.Message };
            }
        }
    }
}
