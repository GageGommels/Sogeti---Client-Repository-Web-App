using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sogeti_Client_Data_Repository.Models
{
    public class User
    {
        [BindProperty, Required, MinLength(6)]
        public string Username { get; set; }

        [BindProperty, Required, MinLength(6)]
        public string Password { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Salt { get; set; }
        public string Email { get; set; }
    }
}
