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

        public IActionResult getIdForClientApp(string id)
        {
            displayClients clientInfo = new displayClients();
            ViewBag.SelectedClient = clientInfo.getAppClient(id);
            return View("ClientApplications");
        }

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
            List<dataTableEntry> data = new List<dataTableEntry>();
            data = getData.getDataTableEntries(1);
            var reponse = data.Find(r => r.App_ID == id);
            ViewBag.Selected = reponse;
            /*Debug.WriteLine(id);*/
            return View("Application");
        }

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
