using Logic.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Services
{
    public class NavigationTitleService : INavigationTitleService
    {
        public event EventHandler<string> TitleChanged;

        private string _title { get; set; } 
        
        public string getTitle()
        {
            return _title;
        }

        public void setTitle(string title)
        {
           _title = title;
            TitleChanged?.Invoke(this, title);
        }
    }
}
