using Data.Models;
using Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Radzen;
using System.ComponentModel;
using Logic.IServices;
using Microsoft.JSInterop;
using System.Globalization;
using System.Net.Mail;
using Data.Models.Designation;
using Data.Models.Leave;
namespace SmedaInternalMobile.Components.Pages.DesignationPages
{
    public partial class DesignationRequest
    {
        #region Private and Public Properties
        [Parameter]
        public UserModel user { get; set; }
        private ChangeDesignationViewModel changeDesignations = new ChangeDesignationViewModel();
        private bool popup;
        private bool isArabic;
        private string documentName = "";
        private List<ChangeDesignationViewModel> history = new List<ChangeDesignationViewModel>();
        private bool isSubmitting = false;
        private List<StatusViewModal> status;
        #endregion Private and Public Properties

        #region Private and Protected Methods
        protected override async Task OnInitializedAsync()
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            if (cultureInfo.IetfLanguageTag == "ar-OM")
            {
                isArabic = true;
            }
            else
            {
                isArabic = false;
            }
            user = UserServices.User;
            var response = await ChangeDesignations.GetAllChangeDesignationData(isArabic);
            if (response != null)
            {
                if (response.Success)

                {
                    history = response.Data;
                    StateHasChanged();
                }
                else
                {
                  
                }
            }

            var getEmployeeList = await EmployeeService.GetAllEmployeeDesignationData(isArabic);

            if (getEmployeeList != null)
            {
                if (getEmployeeList.Success)
                {
                    var result = getEmployeeList.Data;
                    changeDesignations.CurrentDesignationId = result.DesignationId;
                    changeDesignations.CurrentDesignation = result.Designation;
                }
                else
                {
                  
                }
            }

        }


        private async Task Submit(ChangeDesignationViewModel model)
        {
            if (isSubmitting)
            {
                return;
            }

            isSubmitting = true; 
            model.EmployeeId = user.EmployeeId;
            model.ApproverId = user.ApproverId;
            model.ServiceApprover = user.ServiceApprover;

            var result = await ChangeDesignations.AddDesignation(model);
            if (result != null)
            {
                if (result.Success)
                {
                    NotificationService.Notify(new NotificationMessage
                    {
                        Severity = NotificationSeverity.Success,
                        Summary = "Success",
                        Detail = "Change designation request submitted successfully.",
                        Duration = 4000
                    });

                    documentName = string.Empty;
                    await OnInitializedAsync(); 
                    Cancel();
                    await EmployeeService.GetAllEmployeeDesignationData(isArabic);
                }
                else
                {
                    NotificationService.Notify(new NotificationMessage
                    {
                        Severity = NotificationSeverity.Error,
                        Summary = "Error",
                        Detail = "Failed to submit the change designation request.",
                        Duration = 4000
                    });
                }
            }
            else
            {
                NotificationService.Notify(new NotificationMessage
                {
                    Severity = NotificationSeverity.Error,
                    Summary = "Error",
                    Detail = "An unexpected error occurred. Please try again.",
                    Duration = 4000
                });
            }

            isSubmitting = false; 
        }


        private void Cancel()
        {
            changeDesignations = new ChangeDesignationViewModel();
            documentName = string.Empty;
            isSubmitting = false;
            StateHasChanged();
        }


        public async Task GetActionDetail(Guid id)
        {
            var response = await ChangeDesignations.GetStatusDetail(id, isArabic);
            if (response.Success)
            {
                status = response.Data;
                await DialogService.OpenAsync<DesignationDetails>("Status Detail", new Dictionary<string, object>() { { "Status", status } }, new DialogOptions() { Width = "40vw", Height = "35vh" });
            }
            else
            {

            }

        }
        #endregion Private and Protected Methods
    }
}
