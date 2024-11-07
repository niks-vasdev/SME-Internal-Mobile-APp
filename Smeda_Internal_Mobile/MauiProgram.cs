using CommunityToolkit.Maui;
using Data.Models;
using Logic.IServices;
using Logic.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Radzen;
using SmedaInternalMobile.Authentication;
using SmedaInternalMobile.ApiManagers;
using SmedaInternalMobile.HttpHelperService.Leave;
using SmedaInternalMobile.HttpHelperService.User;
using SmedaInternalMobile.HttpHelperService.Designation;
using SmedaInternalMobile.HttpHelperService.Employee;
using SmedaInternalMobile.HttpHelperService.DropDown;
using SmedaInternalMobile.HttpHelperService.Car;
using SmedaInternalMobile.HttpHelperService.SalaryStatementService;
using SmedaInternalMobile.HttpHelperService.Defination;
using Microsoft.AspNetCore.Builder;
using SmedaInternalMobile.HttpHelperService.ScholarshipService;
using SmedaInternalMobile.HttpHelperService.ExperienceCertificate;
using Microsoft.AspNetCore.Components.Authorization;

namespace SmedaInternalMobile
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });


            builder.Services.AddHttpClient();
            builder.Services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            var apiBaseUrl = builder.Configuration.GetValue<string>("ApiBaseUrl");


            builder.Services.AddHttpClient<IApiManager, ApiManager>(client =>
            {
                client.BaseAddress = new Uri("https://jzg077nq-7226.asse.devtunnels.ms/api/");
            });

            builder.Services.AddAuthorizationCore();
            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddRadzenComponents();
            builder.Services.AddScoped<ILeave, Leave>();
            builder.Services.AddSingleton<DesignationService>();
            builder.Services.AddSingleton<GradeService>();
            builder.Services.AddSingleton<IGenericService<DesignationRequestModel>, GenericService<DesignationRequestModel>>();
            builder.Services.AddSingleton<IGenericService<GradeRequestModel>, GenericService<GradeRequestModel>>();
            builder.Services.AddSingleton<IGenericService<UserModel>, GenericService<UserModel>>();
            builder.Services.AddSingleton<IGenericService<NotificationModel>, GenericService<NotificationModel>>();
            builder.Services.AddSingleton<INavigationTitleService, NavigationTitleService>();
            builder.Services.AddSingleton<ILeaveBalanceService, LeaveBalanceService>();
            builder.Services.AddSingleton<IChangeDesignations, ChangeDesignations>();
            builder.Services.AddSingleton<IEmployeeService, EmployeeService>();
            builder.Services.AddSingleton<IScholarshipService, ScholarshipService>();
            builder.Services.AddSingleton< UserService, UserService>();
            builder.Services.AddSingleton< DropDownData, DropDownData>();
            builder.Services.AddSingleton< IVehicleRequest, VehicleRequest>();
            builder.Services.AddSingleton<ISalaryStatementService, SalaryStatementService>();
            builder.Services.AddSingleton<IDefinationService, DefinationService>();
            builder.Services.AddSingleton<IExperienceCertificateService, ExperienceCertificateService>();
            builder.Services.AddLocalization();
            builder.Services.AddLocalization(options =>
            {
                options.ResourcesPath = "Resources";
            });



            RequestLocalizationOptions GetLocalizationOptions()
            {
                var culture = builder.Configuration.GetSection("Cultures").GetChildren().ToDictionary(x => x.Key, x => x.Value);
                var supportedCulture = culture.Keys.ToArray();
                var localizationOptions = new RequestLocalizationOptions()
                    .AddSupportedCultures(supportedCulture)
                    .AddSupportedUICultures(supportedCulture);
                return localizationOptions;
            }
            builder.Services.AddScoped<IDefinationService, DefinationService>();



#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
