using Data.Models;
using Data.Models.Designation;
using Data.Models.Leave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmedaInternalMobile.HttpHelperService.Designation
{
    public interface IChangeDesignations
    {
        Task<GenericResponse<Guid>> AddDesignation(ChangeDesignationViewModel model);
        Task<GenericResponse<List<ChangeDesignationViewModel>>> GetAllChangeDesignationData(bool isArabic);
        Task<GenericResponse<List<ChangeDesignationViewModel>>> ApproverChangeDesignation(bool isArabic);
        Task<GenericResponse<ChangeDesignationViewModel>> GetChangeDesignationById(Guid id, bool isArabic);
        Task<GenericResponse<string>> ChangeDesignationAction(ChangeDesignationViewModel model);
        Task<GenericResponse<List<StatusViewModal>>> GetStatusDetail(Guid id, bool isArabic);
    }
}
