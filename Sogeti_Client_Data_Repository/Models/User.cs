using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sogeti_Client_Data_Repository.Models
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Salt { get; set; }
        public string Email { get; set; }
    }
}
