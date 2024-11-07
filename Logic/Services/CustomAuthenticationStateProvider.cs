//using Data.Models;
//using Microsoft.AspNetCore.Components.Authorization;
//using System;
//using System.Collections.Generic;
//using System.Security.Claims;
//using System.Threading.Tasks;

//namespace Logic.Services
//{
//    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
//    {
//        private readonly IPreferences _preferences;
//        private ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsIdentity());

//        public CustomAuthenticationStateProvider()
//        {
//            _preferences = Preferences.Default;
//        }

//        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
//        {
//            try
//            {
//                var username = _preferences.Get<string>("UserName", null);
//                var userRole = _preferences.Get<string>("UserRole", null);

//                var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
//                {
                   
//                }, "CustomAuth"));

//                NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
//                return await Task.FromResult(new AuthenticationState(claimsPrincipal));
//            }
//            catch
//            {
//                return await Task.FromResult(new AuthenticationState(_anonymous));
//            }
//        }

//        public async Task LoginAuthenticationStateAsync(UserModel userModel)
//        {
//            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
//            {
                
//            }, "CustomAuth"));

//            _preferences.Set("UserName", userModel.UserName);
//            _preferences.Set("UserRole", userModel.Role);

//            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
//        }

//        public async Task LogoutAuthenticationStateAsync(ClaimsIdentity claimsIdentity)
//        {
//            //var claimsPrincipal = _anonymous;
//            //NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));

//            //_preferences.Remove("UserName");
//            //_preferences.Remove("UserRole");
//            //_preferences.Remove("Token");
//            var anonymousUser = new ClaimsPrincipal(claimsIdentity);

//            // Notify that the user has logged out
//            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(anonymousUser)));

//        }
//    }
//}
