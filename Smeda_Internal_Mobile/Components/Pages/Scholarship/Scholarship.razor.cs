using Data.Models;
using Data.Models.Leave;
using Data.Models.Scholarship;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Radzen;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SmedaInternalMobile.Components.Pages.Scholarship
{
    public partial class Scholarship
    {

        private ScholarshipViewModel scholarshipViewModel = new ScholarshipViewModel();
        private UserModel user;
        private bool popup;
        private bool isArabic;
        private HashSet<string> RolesName = new HashSet<string>();


        private ScholarshipViewModel modalDocumentname = new ScholarshipViewModel();
        private ScholarshipViewModel modalImage = new ScholarshipViewModel();

        private IEnumerable<DefinationViewModel> degreeOfLevel;
        private List<ScholarshipHistoryViewModel> getAllData = new List<ScholarshipHistoryViewModel>();

        public IJSObjectReference JsObjectRef { get; set; }
        private List<StatusViewModal> status;

        protected override async Task OnInitializedAsync()
        {
            user = UserService.User;
            degreeOfLevel = await DefinitionService.GetAllLevelOfDegree();
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            if (cultureInfo.IetfLanguageTag == "ar-OM")
            {
                isArabic = true;
            }
            var response = await ScholarshipService.GetAlldata(isArabic);
            if (response.Success)
            {
                getAllData = response.Data;
                scholarshipViewModel.LevelOfDegreeId = null;
            }
            else
            {
               
            }
        }


        private async Task Submit(ScholarshipViewModel model)
        {

            model.ApproveDocumentForCollage = modalDocumentname.ApproveDocumentForCollageUid;
            model.PaymentInvoiceDocument = modalDocumentname.PaymentInvoiceDocumentUid;
            model.ApproverId = user.ApproverId;
            model.EmployeeId = user.EmployeeId;
            model.ServiceApprover = user.ServiceApprover;
            var result = await ScholarshipService.AddScholarship(model);
            if (result.Success)
            {
               
                //Navigation.NavigateTo.Scholarship;
                var EmployeeName = user.EmployeeName;

                await OnInitializedAsync();
                Cancel();
                modalDocumentname = new();
                StateHasChanged();
            }
            else
            {
               
            }
        }

        private void Cancel()
        {
            modalImage.PaymentInvoiceDocument = string.Empty;
            modalImage.ApproveDocumentForCollage = string.Empty;
            scholarshipViewModel = new();
        }

        public async Task GetActionDetail(Guid id)
        {
            var response = await ScholarshipService.GetStatusDetail(id, isArabic);
            if (response.Success)
            {
                status = response.Data;
                await DialogService.OpenAsync<ScholershipDetails>("", new Dictionary<string, object>() { { "Id", id } }, new DialogOptions() { Width = "40vw", Height = "25vh" });
            }
            else
            {

            }

        }
    }
}
