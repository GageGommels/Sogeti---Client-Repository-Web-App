using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sogeti_Client_Data_Repository.Models;

namespace Sogeti_Client_Data_Repository.Controllers
{
    public class HomeController : Controller
    {
        Database database = new Database();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult ClientInfo()
        {
            return View();
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
        [HttpPost]
        public IActionResult Login([Bind] User user)
        {
            if (ModelState.IsValid)
            {
                bool res = database.LoginUser(user);
                if (res)
                {
                    TempData["msg"] = "Login Succesful";
                    return View("Index");
                }
                else
                {
                    TempData["msg"] = "Incorrect User Name or Password";
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

        public IActionResult Sorting()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
