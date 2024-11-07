using Data.Enums;
using Data.Models;
using Data.Models.Leave;
using Data.Models.SalaryStatementService;
using Microsoft.AspNetCore.Components;
using Radzen;
using SmedaInternalMobile.Components.Pages.LeaveActions;
using SmedaInternalMobile.HttpHelperService.Defination;
using SmedaInternalMobile.HttpHelperService.User;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;


namespace SmedaInternalMobile.Components.Pages.SalaryStatement
{
    public partial class SalaryStatement
    {
        #region Private and Public Properties
        [Parameter]
        public UserModel user { get; set; }
        private IEnumerable<DefinationViewModel> SalaryStatementType;
        private SalaryStatementViewModel salaryStatementViewModel = new SalaryStatementViewModel();
        private List<SalaryStatementHistoryViewModel> history = new List<SalaryStatementHistoryViewModel>();
        private bool popup;
        private bool arabic;
        public bool isArabic;
        private HashSet<string> RolesName = new HashSet<string>();
        private List<StatusViewModal> status;

        [Inject]
        public IDefinationService DefinationService { get; set; }

        #endregion Private and Public Properties

        #region Private and Protected Properties
        protected override async Task OnInitializedAsync()
        {
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
            await DataLoad();
            var result = await SalaryStatementService.GetAllSalaryStatement(isArabic);
            if (result.Success)
            {
                history = result.Data;
  
                salaryStatementViewModel.SalaryStatementTypeId = null;
            }
            else
            {
      
            }
            StateHasChanged();
        }

		private async Task Submit(SalaryStatementViewModel model)
		{
			model.ApproverId = user.ApproverId;
			model.EmployeeId = user.EmployeeId;
			model.HrStatus = (int)LeaveStatus.Pending;
			model.ApproverIds = user.HrId;

			var result = await SalaryStatementService.AddSalaryStatement(model);
			if (result.Success)
			{
				NotificationService.Notify(new NotificationMessage
				{
					Severity = NotificationSeverity.Success,
					Summary = "Success",
					Detail = "Salary statement submitted successfully.",
					Duration = 4000
				});

				var employeeName = user.EmployeeName;

				await OnInitializedAsync();
				Cancel();
				StateHasChanged();
			}
			else
			{
				NotificationService.Notify(new NotificationMessage
				{
					Severity = NotificationSeverity.Error,
					Summary = "Error",
					Detail = "Failed to submit salary statement.",
					Duration = 4000
				});
			}
		}

		private void Cancel()
        {
            salaryStatementViewModel = new SalaryStatementViewModel();
        }
        private async Task DataLoad()
        {
            SalaryStatementType = await DefinationService.GetAllSalaryStatementType();
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            if (cultureInfo.IetfLanguageTag == "ar-OM")
            {
                arabic = true;
            }
        }
        //private async Task GetApproverImages(SalaryStatementHistoryViewModel file, OrganisationApprovalViewModel approver, KeyValuePair<string, string> Reasons, string uid)
        //{
        //    AttachmentViewModel obj = new AttachmentViewModel()
        //    {
        //        Reasons = Reasons,
        //        FileData = file.FileData,
        //        FileExtension = file.FileExtension,
        //        FileName = file.FileName,
        //        UpdatedOn = approver.UpdatedOn.Value,
        //        ApproverDocuments = file.ApproverDocuments,
        //        Uid = uid
        //    };
        //    await DialogService.OpenAsync<Attachment>(Localizer[ConstantStrings.Attachment], new Dictionary<string, object>() { { "file", obj } }, new DialogOptions());
        //}

        public async Task GetActionDetail(Guid id)
        {
            var response = await SalaryStatementService.GetStatusDetail(id, isArabic);
            if (response.Success)
            {
                status = response.Data;
                await DialogService.OpenAsync<SalaryStatus>("", new Dictionary<string, object>() { { "Id", id } }, new DialogOptions() { Width = "40vw", Height = "30vh" });
            }
            else
            {
              
            }
        }
        #endregion Private and Protected Properties
    }
}
