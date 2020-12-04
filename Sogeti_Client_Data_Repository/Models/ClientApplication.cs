using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sogeti_Client_Data_Repository.Models
{
    /// <summary>
    /// This class creates a ClientApplication object, which contains an
    /// applicationName and productionURL variables. The contents of this object
    /// are what is displayed in the table on the ClientApplications view.
    /// </summary>
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
