using Data.Models;
using Data.Models.Leave;
using Data.Models.Scholarship;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmedaInternalMobile.HttpHelperService.ScholarshipService
{
    public interface IScholarshipService
    {
        Task<GenericResponse<Guid>> AddScholarship(ScholarshipViewModel scholarshipViewModel);
        Task<GenericResponse<List<ScholarshipHistoryViewModel>>> GetAlldata(bool isArabic);
        Task<GenericResponse<List<ScholarshipHistoryViewModel>>> ApproveScholarship(bool isArabic);
        Task<GenericResponse<ScholarshipHistoryViewModel>> GetScholarshipById(Guid id, bool isArabic);
        Task<GenericResponse<string>> ScholarshipAction(ScholarshipHistoryViewModel scholarship);
        Task<GenericResponse<List<StatusViewModal>>> GetStatusDetail(Guid id, bool isArabic);
    }
}
