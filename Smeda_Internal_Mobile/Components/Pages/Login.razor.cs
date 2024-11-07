using Data.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using SmedaInternalMobile.Authentication;
using System.Globalization;
using System.Threading.Tasks;

namespace SmedaInternalMobile.Components.Pages
{
    public partial class Login
    {

        [Inject]
        public IAuthService AuthService { get; set; }

        [Inject]
        NavigationManager NavigationManager { get; set; }

        private string ErrorMessage { get; set; }
        private bool isArabic;
        private bool IsBusy { get; set; } = false;
        private LoginModel loginModel = new LoginModel();

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

        }
        private async Task LoginBtn()
        {
            IsBusy = true;
            ErrorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(loginModel.UserName) || string.IsNullOrWhiteSpace(loginModel.Password))
            {
                ErrorMessage = "Username and password are required.";
                IsBusy = false;
                return;
            }

            try
            {
                var loginResponse = await AuthService.Login(loginModel);
                if (loginResponse.Successful)
                {
                    NavigationManager.NavigateTo("dashBoard", replace: true);

                }
                else
                {
                    ErrorMessage = "Invalid Credentials";
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Login failed: {ex.Message}";
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
