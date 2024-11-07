using Data.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Configuration;
using SmedaInternalMobile.ApiManagers;
using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Maui.Storage;
using Newtonsoft.Json;
using static SmedaInternalMobile.ApiManagers.ApiManager;

namespace SmedaInternalMobile.Authentication
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly IApiManager _apiManager;
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public AuthService(HttpClient httpClient,
            AuthenticationStateProvider authenticationStateProvider,
            IConfiguration configuration,
            IApiManager apiManager)
        {
            _httpClient = httpClient;
            _authenticationStateProvider = authenticationStateProvider;
            _configuration = configuration;
            _apiManager = apiManager;
        }

        public async Task<UserModel> GetUserDetails()
        {
            try
            {
                var token = Preferences.Get("authToken", string.Empty);
                if (!string.IsNullOrEmpty(token))
                {
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }
                var url = _configuration["ApiBaseUrl"] + "Authentication/GetMobileUserDetails";
                var response = await _apiManager.GetAsync<UserModel>(url);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching user details: " + ex.Message);
            }
        }
        public async Task<LoginResponse> Login(LoginModel loginModel)
        {
            try
            {
                var loginResult = await _apiManager.PostAsync<LoginModel, LoginResponse>(
                    _configuration["ApiBaseUrl"] + "authentication/login",
                    loginModel
                );

                if (!loginResult.Successful)
                {
                    return loginResult;
                }

                Preferences.Set("authToken", loginResult.Token);
                ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(loginModel.UserName);
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", loginResult.Token);
                return loginResult;
            }
            catch (Exception ex)
            {
                throw new Exception("Login failed: " + ex.Message);
            }
        }


        public async Task<bool> Logout()
        {
            try
            {
                Preferences.Remove("authToken");
                ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();
                _httpClient.DefaultRequestHeaders.Authorization = null;
                await _httpClient.PostAsync(_configuration["ApiBaseUrl"] + "Authentication/logout", null);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<Result> SendResetLink(ForgotPasswordViewModel ForgotPasswordModel)
        {
            var result = await _apiManager.PostAsync<Result>(_configuration["BaseUrl"] + "SMEMessaging/EmailSend", ForgotPasswordModel);
            return result;
        }
        public async Task<Result> ForgotPassword(ForgotPasswordViewModel ForgotPasswordModel)
        {
            try
            {
                var result = await _apiManager.PostAsync<Result>(_configuration["BaseUrl"] + "SMEMessaging/EmailSend", ForgotPasswordModel);
                return result;
            }
            catch (Exception ex)
            {
                return new Result { Successful = true, Error = ex.Message };
            }
        }


        public async Task<bool> IsLoggedIn()
        {
            var token = Preferences.Get("authToken", string.Empty);

            if (string.IsNullOrEmpty(token))
            {
                return false;
            }



            return true;
        }


    }
}
