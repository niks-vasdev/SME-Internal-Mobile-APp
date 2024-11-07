using Data.Models;
using Data.Models.Car;
using Data.Models.Leave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmedaInternalMobile.HttpHelperService.Car
{
    public interface IVehicleRequest
    {
        Task<GenericResponse<Guid>> AddVehicleRequest(VehicleRequestViewModel vehicleRequestViewModel);
        Task<GenericResponse<List<VehicleRequestViewModel>>> GetAlldata(bool isArabic);
        Task<GenericResponse<List<VehicleRequestViewModel>>> ApproverVehicleRequest(bool isArabic);
        Task<GenericResponse<VehicleRequestViewModel>> GetVehicleRequestById(Guid Id, bool isArabic);
        Task<GenericResponse<string>> VehicleRequestAction(VehicleRequestViewModel model);
        Task<GenericResponse<List<StatusViewModal>>> GetStatusDetails(Guid id, bool isArabic);
    }
}
