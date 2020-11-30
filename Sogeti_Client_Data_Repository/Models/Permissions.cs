using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sogeti_Client_Data_Repository.Models
{
    public class Permissions
    {
        public string userFullName;
        public string userName;
        public string userID;
        public string userEmail;

        public Permissions() { }

        public Permissions(string userFullName, string userName, string userID, string userEmail)
        {
            this.userFullName = userFullName;
            this.userName = userName;
            this.userID = userID;
            this.userEmail = userEmail;
        }

        public string UserID { get; set; }
        public string UserFullName { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
    }
}
