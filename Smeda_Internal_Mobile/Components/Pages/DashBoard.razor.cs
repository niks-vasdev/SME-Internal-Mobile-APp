using Data.Models;
using Data.Models.Leave;
using Logic.IServices;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Radzen;
using SmedaInternalMobile.HttpHelperService.Employee;
using SmedaInternalMobile.HttpHelperService.Leave;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SmedaInternalMobile.Components.Pages
{

    public partial class DashBoard
    {
		private EmployeeDesignationData? selectedEmployee;
		private int NoOfServiceRequests = 0;



		public bool isArabic;
        public bool isLeavesLoad = false;
        private string TotalLeaves { get; set; }
        private string TotalAppliedLeaves { get; set; }
        private List<LeaveDetailsViewModel> leaveDetailsViewModel = new List<LeaveDetailsViewModel>();
        private List<LeaveRuleListingViewModel> leaveRequestCount = new List<LeaveRuleListingViewModel>();

        [Inject]
        IGenericService<DesignationRequestModel> _designationService { get; set; }
        


        [Inject]
        INavigationTitleService _navigationTitleService { get; set; }

        private bool Is_busy { get; set; } = false;
		public List<EmployeeDesignationData> profile { get; private set; }

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
            await GetAllLeave();
			await GetAllEmployeeDesignations();
			Is_busy = true;
            await Intialize();
            _navigationTitleService.setTitle("Dashboard");
            StateHasChanged();
            // await GetLeaves();



        }

		private void OnEmployeeSelected(object args)
		{
			var selectedId = (Guid)args;
			selectedEmployee = profile.FirstOrDefault(emp => emp.Id == selectedId);
			StateHasChanged();
		}
		private async Task Intialize()
        {
            List<DesignationRequestModel> designationRequests = await _designationService.GetAll();
            NoOfServiceRequests = designationRequests.Where(r => r.HRStatus == Data.Enums.RequestType.Pending).ToList().Count;
            Is_busy  = false;
        }

        private async Task GetAllLeave()
        {
            var result = await Leave.GetAllLeaveRequest(isArabic);
            if (result.Success)
            {
                leaveRequestCount = result.Data;
            }
            else
            {

            }

            StateHasChanged();
        }




        private async Task GetAllEmployeeDesignations()
        {
            var result = await EmployeeService.GetAllEmployeeAndDesignation(isArabic);
            if (result.Success)
            {
                profile = result.Data;
            }
            else
            {

            }

            StateHasChanged();
        }


    }
}
