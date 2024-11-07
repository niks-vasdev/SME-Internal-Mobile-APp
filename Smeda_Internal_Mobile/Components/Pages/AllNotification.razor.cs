using Data.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SmedaInternalMobile.Components.Pages
{
    public partial class AllNotification
    {
        private bool isNotificationsVisible = false;
        private List<NotificationModel> notifications = new List<NotificationModel>();

        [Inject]
        IJSRuntime JSRuntime { get; set; }




     

        protected override async Task OnInitializedAsync()
        {
           
            await IntializeList();
            base.OnInitialized();
        }

        private async Task IntializeList()
        {
            //r authState = await _authenticationState;
            var userName = "Admin";

        }
        private async Task goBack()
        {
            await JSRuntime.InvokeVoidAsync("goBack");
        }

        //private async Task ShowNotifications()
        //{

        //    notifications =  NotificationService.GetAll().Result.Where(n=>n.Receiver=="Admin").ToList();
        //    isNotificationsVisible = true;
        //}

        //private void HideNotifications()
        //{
        //    isNotificationsVisible = false;
        //}
    }
}
