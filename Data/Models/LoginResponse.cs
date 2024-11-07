using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class LoginResponse
    {
        public bool Successful { get; set; }
        public string Token { get; set; }
        public string Message { get; set; }
    }

}
