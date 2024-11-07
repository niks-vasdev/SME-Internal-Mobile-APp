
using Data.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmedaInternalMobile.HttpHelperService.User
{
  public class UserService
    {
        private readonly IConfiguration _configuration;
        public UserModel User { get; set; }
        public string FileServerApiUrl
        {
            get
            {
                return _configuration[FileServerApiUrl];
            }
            set { }
        }

        public UserService(IConfiguration configuration)
        {
                _configuration = configuration; 
        }
    }
}
