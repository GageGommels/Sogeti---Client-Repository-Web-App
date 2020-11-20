using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sogeti_Client_Data_Repository.Models
{
    public class dataTableEntry
    {
        String app_ID;
        String app_name;
        String department;
        String departmentManager;
        String client;
        String primaryBA;
        String techContact;
        String applicationType;
        String tech;
        String productionServer;
        String productionURL;
        String qaServer;
        String qaURL;
        String devlopmentServer;
        String devlopmentURL;
        String codeSource;
        String repository;
        String stability;
        String futureDevlopment;
        String sensitivity;
        String criticality;

        public dataTableEntry() { } //Blank Contructor

        public dataTableEntry(string app_name, string department, string departmentManager, string client, string primaryBA, string techContact, string applicationType, string tech, string productionServer, string productionURL, string qaServer, string qaURL, string devlopmentServer, string devlopmentURL, string codeSource, string repository, string stability, string futureDevlopment, string sensitivity, string criticality, string app_ID)
        {
            this.App_ID = app_ID;
            this.app_name = app_name;
            this.department = department;
            this.departmentManager = departmentManager;
            this.client = client;
            this.primaryBA = primaryBA;
            this.techContact = techContact;
            this.applicationType = applicationType;
            this.tech = tech;
            this.productionServer = productionServer;
            this.productionURL = productionURL;
            this.qaServer = qaServer;
            this.qaURL = qaURL;
            this.devlopmentServer = devlopmentServer;
            this.devlopmentURL = devlopmentURL;
            this.codeSource = codeSource;
            this.repository = repository;
            this.stability = stability;
            this.futureDevlopment = futureDevlopment;
            this.sensitivity = sensitivity;
            this.criticality = criticality;
        }

        public string App_name { get => app_name; set => app_name = value; }
        public string Department { get => department; set => department = value; }
        public string DepartmentManager { get => departmentManager; set => departmentManager = value; }
        public string Client { get => client; set => client = value; }
        public string PrimaryBA { get => primaryBA; set => primaryBA = value; }
        public string TechContact { get => techContact; set => techContact = value; }
        public string ApplicationType { get => applicationType; set => applicationType = value; }
        public string Tech { get => tech; set => tech = value; }
        public string ProductionServer { get => productionServer; set => productionServer = value; }
        public string ProductionURL { get => productionURL; set => productionURL = value; }
        public string QaServer { get => qaServer; set => qaServer = value; }
        public string QaURL { get => qaURL; set => qaURL = value; }
        public string DevlopmentServer { get => devlopmentServer; set => devlopmentServer = value; }
        public string DevlopmentURL { get => devlopmentURL; set => devlopmentURL = value; }
        public string CodeSource { get => codeSource; set => codeSource = value; }
        public string Repository { get => repository; set => repository = value; }
        public string Stability { get => stability; set => stability = value; }
        public string FutureDevlopment { get => futureDevlopment; set => futureDevlopment = value; }
        public string Sensitivity { get => sensitivity; set => sensitivity = value; }
        public string Criticality { get => criticality; set => criticality = value; }
        public string App_ID { get => app_ID; set => app_ID = value; }
    }
}
