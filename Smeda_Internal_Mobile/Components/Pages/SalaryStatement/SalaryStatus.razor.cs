using Data.Models.Leave;
using Microsoft.AspNetCore.Components;
using SmedaInternalMobile.HttpHelperService.SalaryStatementService;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmedaInternalMobile.Components.Pages.SalaryStatement
{
    public partial class SalaryStatus
    {

        [Parameter] public Guid Id { get; set; }
        [Inject] public ISalaryStatementService SalaryStatementService { get; set; }


        public bool isArabic;

        public List<StatusViewModal> Status { get; set; } = new List<StatusViewModal>();
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
            var response = await SalaryStatementService.GetStatusDetail(Id, isArabic);
            if (response.Success)
            {
                Status = response.Data;
            }
            else
            {

            }
            StateHasChanged();
        }

    }
}
