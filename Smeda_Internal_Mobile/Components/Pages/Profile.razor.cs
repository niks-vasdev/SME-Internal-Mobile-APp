using Data.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using SmedaInternalMobile.Authentication;
using SmedaInternalMobile.HttpHelperService.User;
using System;
using System.Threading.Tasks;

namespace SmedaInternalMobile.Components.Pages
{
    public partial class Profile
    {
        public UserModel user { get; set; }
        [Inject]
        IJSRuntime JSRuntime { get; set; }
        [Inject]
        NavigationManager _navigationManager { get; set; }
        [Inject]
        IAuthService AuthService { get; set; }  

        public UserModel userProfile = new UserModel();
        private bool isEditable { get; set; }

        protected override async Task OnInitializedAsync()
        {
            user = UserService.User;
           
           var userDetailsResponse = await AuthService.GetUserDetails();
            if (userDetailsResponse != null)
            {
                userProfile.EmployeeName = userDetailsResponse.EmployeeName;
                userProfile.CivilCode = userDetailsResponse.CivilCode;
                userProfile.Role = userDetailsResponse.Role;
                userProfile.Grade = userDetailsResponse.Grade;
                userProfile.Contact = userDetailsResponse.Contact;
                userProfile.CivilCode = userDetailsResponse.CivilCode;


                //userProfile.Department = userDetailsResponse.Department.ToList();
            }

            
        }


        private async Task goBack()
        {
            await JSRuntime.InvokeVoidAsync("goBack");
        }

        private void EditProfile()
        {
            isEditable = true;
        }

        private async Task SaveProfile()
        {
            isEditable = false;
        }

        private void CancelEditing()
        {
            OnInitializedAsync(); 
            isEditable = false;
        }
    }
}
