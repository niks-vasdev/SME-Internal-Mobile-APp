using Data.Models;
using Logic.IServices;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Radzen;
using SmedaInternalMobile.Authentication;
using SmedaInternalMobile.Components.Pages;
using SmedaInternalMobile.HttpHelperService.User;
using System.Globalization;
using System.Security.Claims;

namespace SmedaInternalMobile.Components.Layout
{
    public partial class MainLayout
    {
        [Inject]
        private DialogService _dialogService { get; set; }

        [Inject]
        public IAuthService AuthService { get; set; }

        private bool isArabic;

        [Inject]
        public UserService UserService { get; set; }

        [CascadingParameter]
        private Task<AuthenticationState> _authenticationState { get; set; }

        [Inject]
        private NavigationManager _navigationManager { get; set; }

        [Inject]
        private INavigationTitleService _navigationTitleService { get; set; }

        private string Role;
        public string UserName { get; set; }

        private string navHeading;
        private bool sidebarExpanded = false;

        [Inject]
        private IGenericService<NotificationModel> _notificationService { get; set; }

        [Parameter]
        public UserModel user { get; set; }
        public bool isInit = false;

        protected override async Task OnInitializedAsync()
        {
            await InitializeCulture();
            await LoadUserDetails();
            _navigationTitleService.TitleChanged += OnTitleChanged;

            isInit = true;
            StateHasChanged();
        }

        private async Task InitializeCulture()
        {
            string cultureName = Preferences.Get("Culture", "en-US");
            CultureInfo culture = new CultureInfo(cultureName);

            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            isArabic = culture.IetfLanguageTag.StartsWith("ar");
        }

        private async Task LoadUserDetails()
        {
            if (await AuthService.IsLoggedIn())
            {
                await GettingUserRole();
                user = await AuthService.GetUserDetails();
                if (user != null)
                {
                    UserService.User = user;
                }
            }
        }

        protected void OnTitleChanged(object? sender, string Title)
        {
            navHeading = _navigationTitleService.getTitle();
            StateHasChanged();
        }

        private void CloseSideBar()
        {
            sidebarExpanded = false;
        }

        private async Task GettingUserRole()
        {
            var authState = await _authenticationState;

            if (authState.User.Identity.IsAuthenticated)
            {
                var userDetails = await AuthService.GetUserDetails();
                if (userDetails != null)
                {
                    Role = userDetails.Role;
                    UserName = userDetails.EmployeeName;
                }
            }
            else
            {
                Role = null;
                UserName = null;
            }

            StateHasChanged();
        }

        private async Task LogOut()
        {
            await AuthService.Logout();
            _dialogService.Close();
            _navigationManager.NavigateTo("/login", replace: true);
            CloseSideBar();
        }

        private void goToProfile()
        {
            _navigationManager.NavigateTo("/profile");
        }
    }
}
