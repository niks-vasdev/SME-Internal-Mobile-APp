//using Data.Models;
//using Logic.IServices;
//using Microsoft.AspNetCore.Components;
//using Microsoft.JSInterop;
//using Radzen;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SmedaInternalMobile.Components.Pages
//{
//    public partial class MyNotification
//    {
//        [Inject]
//        IJSRuntime JSRuntime { get; set; }
//        private List<NotificationModel> notifications = new List<NotificationModel>();

//        //[Inject]
//        //IAuthenticationService authenticationService { get; set; }

//        [Inject]
//        IGenericService<NotificationModel> _notificationService { get; set; }

//        private async Task goBack()
//        {
//            await JSRuntime.InvokeVoidAsync("goBack");
//        }

//        public NotificationModel newRequest = new NotificationModel();
//        protected override async Task OnInitializedAsync()
//        {
//            await ShowNotification();
          
//        }
//        public async Task ShowNotification()
//        {
//           // var userName = authenticationService.GetUserNameAsync();
//            notifications = await _notificationService.GetAll();
//            notifications = notifications.Where(n => n.IsRead == false).ToList();
//            notifications = notifications.Where(r=>r.Receiver == userName).ToList();
//            notifications = notifications.OrderByDescending(r => r.Id).ToList();

//        }
//        private async Task MarkAsRead(NotificationModel notification)
//        {
//            notification.IsRead = true;
//            await _notificationService.Update(notification);
//            await ShowNotification();
//            StateHasChanged();
//        }
//    }
//}
