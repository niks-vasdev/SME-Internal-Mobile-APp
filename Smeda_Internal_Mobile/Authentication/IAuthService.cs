using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmedaInternalMobile.Authentication
{
    public interface IAuthService
    {
        Task<LoginResponse> Login(LoginModel loginModel);
        Task<Result> SendResetLink(ForgotPasswordViewModel ForgotPasswordModel);
        Task<Result> ForgotPassword(ForgotPasswordViewModel ForgotPasswordModel);
        Task<bool> Logout();
        Task<bool> IsLoggedIn();
        Task<UserModel> GetUserDetails();
    }
}
