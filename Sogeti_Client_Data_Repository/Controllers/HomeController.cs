﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Sogeti_Client_Data_Repository.Models;

namespace Sogeti_Client_Data_Repository.Controllers
{
    public class HomeController : Controller
    {
        UserLogin userLogin = new UserLogin();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult ClientInfo()
        {
            return View();
        }

        public IActionResult ClientApplications()
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
