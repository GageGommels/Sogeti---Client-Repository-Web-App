using System;
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

        public IActionResult ClientInfo()
        {
            return View();
        }

        public IActionResult displayClients()
        {       
            return View();
        }

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
                    return View("Settings");
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

        public IActionResult Application()
        {
            return View();
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }
        public IActionResult dataView()
        {
            return View();
        }
        public IActionResult changePass()
        {
            return View();
        }
        public IActionResult test()
        {
            return View();
        }

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
                    return View("test");
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

        public IActionResult Sorting()
        {
            return View();
        }

        public IActionResult check(int id)
        {
            getTableData getData = new getTableData();
            ViewBag.Selected = getData.testData(id);
            Debug.WriteLine(id);
            return View("Application");
        }

        [HttpPost]
        public void editCodeSource(int ID, string codeSource)
        {
            getTableData getData = new getTableData();

            Debug.WriteLine("ID: " + ID + ", Code_Source: " + codeSource);

            getData.editCodeSource(ID, codeSource);

        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
