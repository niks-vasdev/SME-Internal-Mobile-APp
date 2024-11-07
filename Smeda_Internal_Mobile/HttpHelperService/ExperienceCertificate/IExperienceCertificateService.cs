using Data.Models;
using Data.Models.ExperienceCertificate;
using Data.Models.Leave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmedaInternalMobile.HttpHelperService.ExperienceCertificate
{
    public interface IExperienceCertificateService
    {
        Task<GenericResponse<Guid>> AddExprienceCertificate(ExperienceCertificateViewModel experienceCertificateViewModel);
        Task<GenericResponse<List<ExperienceCertificateHistoryViewModel>>> ApproveExperienceCertificate(bool isArabic);
        Task<GenericResponse<string>> ExperienceCertificateAction(ExperienceCertificateHistoryViewModel experienceCertificateViewModel);
        Task<GenericResponse<List<ExperienceCertificateHistoryViewModel>>> GetExperienceCertificates(bool isArabic);
        Task<GenericResponse<ExperienceCertificateHistoryViewModel>> GetExperienceCertificatesById(Guid hrActionId, bool isArabic);
        Task<GenericResponse<List<StatusViewModal>>> GetStatusDetail(Guid id, bool isArabic);

    }
}
