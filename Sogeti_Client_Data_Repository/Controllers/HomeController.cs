﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Sogeti_Client_Data_Repository.Models;
using Microsoft.Extensions.Caching.Memory;

namespace Sogeti_Client_Data_Repository.Controllers
{
    public class HomeController : Controller
    {
        UserLogin userLogin = new UserLogin();
        CachedTables cachedTables;


        public HomeController()
        {
            cachedTables = CachedTables.Instance;
        }

        /// <summary>
        /// Returns the Client Info View
        /// </summary>
        /// <returns>returns ClientInfo.cshtml View</returns>
        public IActionResult ClientInfo()
        {
            return View();
        }

        /// <summary>
        /// This returns the userSearch View
        /// </summary>
        /// <returns>returns the userSearch.cshtml view</returns>
        public IActionResult userSearch()
        {
            return View();
        }

        /// <summary>
        /// Returns the Client Applications View
        /// </summary>
        /// <returns>returns ClientApplications.cshtml View</returns>
        public IActionResult ClientApplications()
        {
            return View();
        }

        /// <summary>
        /// This method allows the ClientInfo view to communicate with the ClientApplications
        /// view. This method is called when a user clicks on a client name cell in the table.
        /// It is passed a clientId variable, where it then calls the getAppClient method in the
        /// displayClients class, using the clientId variable to get the client object associated
        /// with that id. The client object is then passed to a ViewBag variable, where it is called
        /// by the displayClientApplications view.
        /// </summary>
        /// <param name="id"></param>
        /// <returns> ClientApplications view </returns>
        public IActionResult getIdForClientApp(string id)
        {
            displayClients clientInfo = new displayClients();
            ViewBag.SelectedClient = clientInfo.getAppClient(id);
            return View("ClientApplications");
        }

        /// <summary>
        /// This method receives an ajax call from the saveNewClient function in the ClientInfo view.
        /// It is passed a client name and description, which is then passed to the saveClient method
        /// in the displayClients class to be saved in the database.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        [HttpPost]
        public void saveClient(string name, string description)
        {
            displayClients clientInfo = new displayClients();
            clientInfo.saveClient(name, description);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult addApplication()
        {
            return View();
        }

        /// <summary>
        /// This method is called when a user attempts to login to the application.
        /// It checks to make sure that the ModelState is valid then either returns the view of the Client Info Page
        /// If it fails it returns the failed response to the loginpage letting the user know that the login was not succesful
        /// </summary>
        /// <param name="login"></param>
        /// <returns>
        /// Success -> Sends ClientInfo Page
        /// ||| Failure -> Sends Response to login page
        /// </returns>
        [HttpPost]
        public IActionResult Login([Bind] Login login)
        {
            if (ModelState.IsValid)
            {
                string response = userLogin.LoginUser(login);
                if (response == "Login successful")
                {
                    HttpContext.Session.SetString("user", login.Username);
                    TempData["msg"] = response;
                    return View("ClientInfo");
                }
                else
                {
                    //CachedTables.ContactType.TryGetValue(1, out string value);
                    TempData["msg"] = response;
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        public IActionResult Settings()
        {
            return View();
        }

        /// <summary>
        /// Returns the Application View 
        /// </summary>
        /// <returns>returns Application.cshtml</returns>
        public IActionResult Application()
        {
            return View();
        }

        /// <summary>
        /// Returns ForgotPasswordView
        /// </summary>
        /// <returns></returns>
        public IActionResult ForgotPassword()
        {
            return View();
        }

        /// <summary>
        /// Returns the DataView Table Page
        /// </summary>
        /// <returns>returns dataView.cshtml View</returns>
        public IActionResult dataView()
        {
            return View();
        }

        /// <summary>
        /// Returns the Change Password View
        /// </summary>
        /// <returns>returns changePass.cshtml View</returns>
        public IActionResult changePass()
        {
            return View();
        }



        /// <summary>
        /// This method is to check and see if the password of the user is successfully changed. If it is then it redirects the user to the index page, where they can then login.
        /// </summary>
        /// <param name="change"></param>
        /// <returns>IActionResult index.cshtml view</returns>
        [HttpPost]
        public IActionResult changePass([Bind] ChangePassword change)
        {
            if (ModelState.IsValid)
            {
                string user = HttpContext.Session.GetString("user");
                string response = userLogin.ChangePassword(change, user);
                if (response == "Password Successfully Changed")
                {
                    TempData["msg"] = response;
                    return View("Index");
                }
                else
                {
                    TempData["msg"] = response;
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        /// <summary>
        /// Returns the Sorting Page View
        /// </summary>
        /// <returns>IActionResult Sorting View</returns>
        public IActionResult Sorting()
        {
            return View();
        }

        /// <summary>
        /// Returns the application view with the application ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Returns application view and ID of selected application </returns>
        public IActionResult check(int id)
        {
            getTableData getData = new getTableData();
            List<dataTableEntry> data = new List<dataTableEntry>();
            data = getData.getDataTableEntries(1);
            var reponse = data.Find(r => r.App_ID == id);
            ViewBag.Selected = reponse;
            /*Debug.WriteLine(id);*/
            return View("Application");
        }

        ///Summary
        ///This series of functions are the connection between the application page
        ///and database procedure functions.
        ///Each of these functions names are the same as the ones in getDataTable.cs
        ///and Application.cshtml.
        ///Each method simply takes in identical variables from Application.cshtml
        ///and passses them to the functions in getDataTable.cs

        [HttpPost]
        public void editDept(int ID, string dept, string first, string last)
        {
            getTableData getData = new getTableData();

            Debug.WriteLine("ID: " + ID + ", dept: " + dept + ", first: " + first + ", last: " + last);

            getData.editDept(ID, dept, first, last);
        }

        [HttpPost]
        public void editBA(int ID, string first, string last)
        {
            getTableData getData = new getTableData();

            Debug.WriteLine("ID: " + ID + ", first: " + first + ", last: " + last);

            getData.editBA(ID, first, last);
        }

        [HttpPost]
        public void editContact(int ID, string first, string last)
        {
            getTableData getData = new getTableData();

            Debug.WriteLine("ID: " + ID + ", first: " + first + ", last: " + last);

            getData.editContact(ID, first, last);
        }

        [HttpPost]
        public void editAppType(int ID, string app)
        {
            getTableData getData = new getTableData();

            Debug.WriteLine("ID: " + ID + ", app: " + app);

            getData.editAppType(ID, app);
        }

        [HttpPost]
        public void editTech(int ID, string tech)
        {
            getTableData getData = new getTableData();

            Debug.WriteLine("ID: " + ID + ", tech: " + tech);

            getData.editTech(ID, tech);
        }

        [HttpPost]
        public void editURL(int ID, string prod, string qa, string dev)
        {
            getTableData getData = new getTableData();

            Debug.WriteLine("ID: " + ID + ", prod: " + prod + ", qa: " + qa + ", dev: " + dev);

            getData.editURL(ID, prod, qa, dev);

        }

        [HttpPost]
        public void editProdServer(int ID, string prod)
        {
            getTableData getData = new getTableData();

            Debug.WriteLine("ID: " + ID + ", prod: " + prod);

            getData.editProdServer(ID, prod);
        }

        [HttpPost]
        public void editQAServer(int ID, string qa)
        {
            getTableData getData = new getTableData();

            Debug.WriteLine("ID: " + ID + ", qa: " + qa);

            getData.editQAServer(ID, qa);
        }

        [HttpPost]
        public void editDevServer(int ID, string dev)
        {
            getTableData getData = new getTableData();

            Debug.WriteLine("ID: " + ID + ", dev: " + dev);

            getData.editDevServer(ID, dev);
        }

        [HttpPost]
        public void editSource(int ID, string source)
        {
            getTableData getData = new getTableData();

            Debug.WriteLine("ID: " + ID + ", codeSource: " + source);

            getData.editSource(ID, source);

        }

        [HttpPost]
        public void editRepo(int ID, string repo)
        {
            getTableData getData = new getTableData();

            Debug.WriteLine("ID: " + ID + ", repo: " + repo);

            getData.editRepo(ID, repo);

        }

        [HttpPost]
        public void editApplication(int ID, int crit, int future, int stable, int sensitive)
        {
            getTableData getData = new getTableData();

            Debug.WriteLine("ID: " + ID + ", crit: " + crit + ", future: " + future + ", stable: " + stable + ", sensitive: " + sensitive);

            getData.editApplication(ID, crit, future, stable, sensitive);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
