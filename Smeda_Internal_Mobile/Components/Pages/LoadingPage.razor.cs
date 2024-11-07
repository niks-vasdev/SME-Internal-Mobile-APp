using Microsoft.AspNetCore.Components;
using SmedaInternalMobile.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmedaInternalMobile.Components.Pages
{
    public partial class LoadingPage
    {
        [Inject]
        public IAuthService AuthService { get; set; }
        [Inject]
        NavigationManager _navigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            
            

            if (!await AuthService.IsLoggedIn())
                _navigationManager.NavigateTo("/login", replace: true);
            else
                _navigationManager.NavigateTo("/dashBoard", replace: true);
        }

    }
}
