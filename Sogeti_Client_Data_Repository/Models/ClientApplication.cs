using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sogeti_Client_Data_Repository.Models
{
    public class ClientApplication
    {
        string applicationName;
        string productionURL;

        public ClientApplication() { }

        public ClientApplication(string applicationName, string productionURL)
        {
            this.applicationName = applicationName;
            this.productionURL = productionURL;
        }

        public string ApplicationName { get; set; }
        public string ProductionURL { get; set; }
    }
}
