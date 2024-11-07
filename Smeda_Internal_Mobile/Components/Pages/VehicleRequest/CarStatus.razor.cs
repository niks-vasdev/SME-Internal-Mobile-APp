using Data.Models.Leave;
using Microsoft.AspNetCore.Components;
using SmedaInternalMobile.HttpHelperService.Car;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmedaInternalMobile.Components.Pages.VehicleRequest
{
    public partial class CarStatus
    {
        [Inject] private IVehicleRequest VehicleRequest { get; set; }
        [Parameter] public Guid Id { get; set; }

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
            var response = await VehicleRequest.GetStatusDetails(Id, isArabic);
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
