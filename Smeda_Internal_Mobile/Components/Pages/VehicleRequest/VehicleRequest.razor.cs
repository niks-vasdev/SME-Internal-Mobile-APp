
using Data.Models;
using Data.Models.Car;
using Data.Models.Leave;
using Microsoft.AspNetCore.Components;
using Radzen;
using SmedaInternalMobile.Components.Pages.LeaveActions;
using SmedaInternalMobile.HttpHelperService.DropDown;
using SmedaInternalMobile.HttpHelperService.User;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmedaInternalMobile.Components.Pages.VehicleRequest
{
    public partial class VehicleRequest
    {
        public VehicleRequestViewModel request = new VehicleRequestViewModel();
        public List<VehicleRequestViewModel> vehicleRequest = new List<VehicleRequestViewModel>();
       private List<DropDownModel> typeofrequest = new List<DropDownModel>();
      //  private List<DefinationViewModel> department;
        private UserModel user { get; set; }
        [Inject]
        private NotificationService NotificationService { get; set; }

        private bool isSubmitting = false;

        public bool isArabic;
        private List<StatusViewModal> status;

        protected override async Task OnInitializedAsync()
        {
            typeofrequest = await DropDownData.GetTypeOfRequestType();
            user = UserService.User;
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            if (cultureInfo.IetfLanguageTag == "ar-OM")
            {
                isArabic = true;
            }
            else
            {
                isArabic = false;
            }
            //  var departmentResult = await DefinationService.GetDepartmentData();
            //if (departmentResult.Success)
            //{
            //    department = departmentResult.Data;
            //}
            await GetRequestData();
        }

       

        private async Task Submit(VehicleRequestViewModel model)
        {
            if (isSubmitting)
            {
                return;
            }

            isSubmitting = true;

            model.EmployeeId = user.EmployeeId;
            model.ApproverId = user.ApproverId;

            if (typeofrequest.Any(x => x.Id == model.TypeOfRequestId && x.Name == "During Work Hours"))
            {
                model.ServiceApprover = user.CarRequestApprover.DuringHours;
            }
            else
            {
                model.ServiceApprover = user.CarRequestApprover.AfterHours;
            }

            var result = await VechicleRequests.AddVehicleRequest(model);
            if (result.Success)
            {
                NotificationService.Notify(new NotificationMessage
                {
                    Severity = NotificationSeverity.Success,
                    Summary = "Success",
                    Detail = "Vehicle request submitted successfully.",
                    Duration = 4000 
                });

                request = new VehicleRequestViewModel(); 
                await GetRequestData(); 

                StateHasChanged(); 
            }
            else
            {
                NotificationService.Notify(new NotificationMessage
                {
                    Severity = NotificationSeverity.Error,
                    Summary = "Error",
                    Detail = "Failed to submit vehicle request.",
                    Duration = 4000 
                });
            }

            isSubmitting = false; 
        }

        private void Cancel()
        {
            request = new VehicleRequestViewModel();
        }
        public async Task GetActionDetail(Guid id)
        {
            var response = await VechicleRequests.GetStatusDetails(id, isArabic);
            if (response.Success)
            {
                status = response.Data;
                await DialogService.OpenAsync<CarStatus>("", new Dictionary<string, object>() { { "Id", id } }, new DialogOptions() { Width = "40vw", Height = "25vh" });
            }
            else
            {
            }
        }

        private async Task GetRequestData()
        {
            var result = await VechicleRequests.GetAlldata(isArabic);
            if (result.Success)
            {
                vehicleRequest = result.Data;
            }
        }
        private async Task OnChangeFromDate()
        {
            if (request.From > request.To)
            {
                request.To = new DateTime();
            }
        }
    }
}
