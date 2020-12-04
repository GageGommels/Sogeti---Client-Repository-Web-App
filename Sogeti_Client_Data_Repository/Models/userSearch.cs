using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sogeti_Client_Data_Repository.Models
{
    public class userSearch
    {
        private  string userFirstName;
        private string userLastName;
        private string userName;
        private string userID;


        public userSearch() { }

        public userSearch(string userFirstName, string userLastName, string userName, string userID) 
        {
            this.userFirstName = userFirstName;
            this.userLastName = userLastName;
            this.userName = userName;
            this.userID = userID;
        }

        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserName { get; set; }
        public string UserID { get; set; }
    }
}
