using Data.Enums;
using Data.Models;
using Data.Models.ExperienceCertificate;
using Data.Models.Leave;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Radzen;
using SmedaInternalMobile.Authentication;
using SmedaInternalMobile.HttpHelperService.User;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SmedaInternalMobile.Components.Pages.ExperienceCertificate
{
    public partial class ExperienceCertificate
    {
        #region Private and Public Properties
        private UserModel user { get; set; }
        private ExperienceCertificateViewModel expCertificate = new ExperienceCertificateViewModel();
        private ExperienceCertificateHistoryViewModel modalDocumentname = new ExperienceCertificateHistoryViewModel();
        private ExperienceCertificateHistoryViewModel modalImage = new ExperienceCertificateHistoryViewModel();
        private List<ExperienceCertificateHistoryViewModel> history = new List<ExperienceCertificateHistoryViewModel>();
        private IEnumerable<EmployeeDesignationData> employees { get; set; }
        private bool popup;
        private bool viewOnly = false;
        private bool isArabic;

        private HashSet<string> RolesName = new HashSet<string>();

        private List<StatusViewModal> status;
        [Inject]
        public UserService UserService { get; set; }
        [Inject]
        public IAuthService AuthService { get; set; }


        #endregion Private and Public Properties

        #region Private and Protected Methods 
        protected override async Task OnInitializedAsync()
        {

            user = await AuthService.GetUserDetails();
            if (user != null)
            {
                UserService.User = user;
            }
            await method(user.EmployeeId);
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            if (cultureInfo.IetfLanguageTag == "ar-OM")
            {
                isArabic = true;
            }
            var result = await ExperienceCertificateService.GetExperienceCertificates(isArabic);
            if (result.Success)
            {
                history = result.Data;
            }
            else
            {

            }
            var response = await EmployeeService.GetAllEmployeeAndDesignation(isArabic);
            if (response.Success)
            {
                employees = response.Data;
            }
            else
            {

            }
            StateHasChanged();
        }

   

        private bool isSubmitting = false;

        private async Task Submit(ExperienceCertificateViewModel model)
        {
            if (isSubmitting)
            {
                return;
            }

            isSubmitting = true;

            model.ApproverId = user.ApproverId;
            model.EmployeeId = user.EmployeeId;
            model.HrStatus = (int)LeaveStatus.Pending;
            model.ApproverIds = user.HrId;

            var result = await ExperienceCertificateService.AddExprienceCertificate(model);
            if (result.Success)
            {
                NotificationService.Notify(new NotificationMessage
                {
                    Severity = NotificationSeverity.Success,
                    Summary = "Success",
                    Detail = "Experience Certificate Request Sent.",
                    Duration = 9000,
                    Style = "custom-toast"
                });

                var response = await ExperienceCertificateService.GetExperienceCertificates(isArabic);
                if (response.Success)
                {
                    history = response.Data;
                    StateHasChanged();
                }

                Cancel();
                isSubmitting = false;

                Navigation.NavigateTo(Navigation.Uri, forceLoad: true);
            }
            else
            {

                isSubmitting = false;
            }
        }

        private void Cancel()
        {
            modalDocumentname.FileName = "";
            expCertificate = new ExperienceCertificateViewModel();

        }

        private async Task method(object args)
        {
            if (args != null)
            {
                expCertificate.EmployeeId = (Guid)args;
                var result = await EmployeeService.GetAllEmployeeAndDesignation(isArabic);
                if (result.Success)
                {
                    expCertificate.Designation = result.Data.Where(x => x.Id == expCertificate.EmployeeId).Select(x => x.Designation).FirstOrDefault();
                    expCertificate.DesignationId = (Guid)result.Data.Where(x => x.Id == expCertificate.EmployeeId).Select(x => x.DesignationId).FirstOrDefault();
                    expCertificate.StartingDate = result.Data.Where(x => x.Id == expCertificate.EmployeeId).Select(x => x.JoiningDate).FirstOrDefault();
                    expCertificate.EmployeeName = result.Data.Where(x => x.Id == expCertificate.EmployeeId).Select(x => x.Name).FirstOrDefault();
                }
                else
                {

                }
            }
            else
            {
                expCertificate.Designation = null;
            }
            StateHasChanged();
        }

        public async Task GetActionDetail(Guid id)
        {
            var response = await ExperienceCertificateService.GetStatusDetail(id, isArabic);
            if (response.Success)
            {
                status = response.Data;
                await DialogService.OpenAsync<ExperienceDetails>("", new Dictionary<string, object>() { { "Id", id } }, new DialogOptions() { Width = "40vw", Height = "25vh" });
            }
            else
            {

            }

        }
        #endregion  Private and Protected Methods
    }
}
