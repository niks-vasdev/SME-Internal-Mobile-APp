using Data.Enums;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.IServices
{
    public interface INavigationTitleService
    {
        public void setTitle(string title);
        public string getTitle();

        public event EventHandler<string> TitleChanged;
    }
}
