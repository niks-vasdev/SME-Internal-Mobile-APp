﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Username is Required")]        
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }

      
    }
}
