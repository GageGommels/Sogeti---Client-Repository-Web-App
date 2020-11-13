using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sogeti_Client_Data_Repository.Models
{
    public class Login
    {
        [BindProperty, Required, MinLength(6)]
        public string Username { get; set; }

        [BindProperty, Required, MinLength(6)]
        public string Password { get; set; }

    }
}
