using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmedaInternalMobile.Platforms.Android.AndroidServices
{
    public class AndroidBackNavigationService : IBackNavigationService
    {
        public void HandleBackNavigation()
        {
            // Implement your Android-specific back navigation logic here
            // For example, if you want to mimic the Android back button behavior
             ((MainActivity)Platform.CurrentActivity).OnBackPressed();
        }
    }
}
