//using Data.Models;
//using Microsoft.AspNetCore.Components.Authorization;
//using Microsoft.Extensions.Configuration;
//using System.Net.Http.Json;
//using System.Security.Claims;
//using System.Threading.Tasks;

//namespace Logic.Services
//{
//    public class AuthenticationService : IAuthenticationService
//    {
//        private readonly IGenericService<UserModel> userService;
//        private readonly IPreferences _preferences;
//        private readonly CustomAuthenticationStateProvider _customAuthenticationStateProvider;
//        private readonly HttpClient _httpClient;
//        private readonly string _baseUrl;

//        public AuthenticationService(IGenericService<UserModel> userService,
//                                      CustomAuthenticationStateProvider customAuthenticationStateProvider,
//                                      HttpClient httpClient,
//                                      IConfiguration configuration)
//        {
//            this.userService = userService;
//            _preferences = Preferences.Default;
//            _customAuthenticationStateProvider = customAuthenticationStateProvider;
//            _httpClient = httpClient;
//            _baseUrl = configuration["ApiBaseUrl"]; 
//        }

//        public async Task<bool> LoginAsync(LoginModel loginModel)
//        {
//            var loginResponse = await _httpClient.PostAsJsonAsync($"{_baseUrl}/Authentication/login", loginModel);

//            if (loginResponse.IsSuccessStatusCode)
//            {
//                var response = await loginResponse.Content.ReadFromJsonAsync<LoginResponse>();
//                if (response != null && response.Successful)
//                {
//                    _preferences.Set("UserId", loginModel.UserName);
//                    _preferences.Set("UserRole", "User");
//                    _preferences.Set("Token", response.Token);
//                    await _customAuthenticationStateProvider.LoginAuthenticationStateAsync(new UserModel
//                    {
//                        UserName = loginModel.UserName,
//                        Role = "User"
//                    });
//                    return true;
//                }
//            }
//            return false;
//        }

//        public void LogoutAsync()
//        {
//            Preferences.Default.Remove("UserId");
//            Preferences.Default.Remove("UserRole");
//            Preferences.Default.Remove("UserName");
//            Preferences.Default.Remove("Token");

//            var claimsIdentity = new ClaimsIdentity();
//            _customAuthenticationStateProvider.LogoutAuthenticationStateAsync(claimsIdentity);
//        }

//        public async Task<bool> IsLoggedInAsync()
//        {
//            return _preferences.ContainsKey("UserRole");
//        }

//        public string GetRoleAsync()
//        {
//            return _preferences.Get<string>("UserRole", null);
//        }

//        public string GetUserNameAsync()
//        {
//            return _preferences.Get<string>("UserName", null);
//        }
//    }
//}
