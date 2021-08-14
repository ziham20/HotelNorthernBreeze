using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelNorthernBreeze.Data;
using HotelNorthernBreeze.Models;
using HotelNorthernBreeze.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelNorthernBreeze.Controllers
{
    public class LoginController : Controller
    {

        private readonly NBEDBContext _context;
        private readonly AuthService _authService;


        public LoginController(NBEDBContext context, AuthService authService)
        {
            _context = context;
            _authService = authService;
        }


        // GET : /login
        public IActionResult Index()
        {
            // return to home if user is already logged in
            if (_authService.IsLoggedIn)
                return Redirect("/");

            else
                return View();
        }


        [HttpPost]
        // POST : /login/create
        public IActionResult Create(string nic, string password)
        {

            // check if a user with this NIC exists
            var user = _context.Users.SingleOrDefault(u => u.Nic == nic);
            if (user is null)
            {
                ViewBag.error = $"NIC {nic} does not has an account";
                return View("index");
            }

            // check password
            else if (user.Password != password)
            {
                ViewBag.error = "incorrect password";
                return View("index");
            }

            // login user
            else
            {
                _authService.LoginUser(user);
                Console.WriteLine(_authService.LoggedUser.FirstName);
                return RedirectToAction("index", "home");
            }

        }


        // GET : /login/logout
        public IActionResult LogOut()
        {
            // if logged in, log out
            if (_authService.IsLoggedIn)
                _authService.LoginOut();

            // got to login
            return RedirectToAction("index", "login");

        }

    }
}
