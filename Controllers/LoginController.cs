using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelNorthernBreeze.Data;
using HotelNorthernBreeze.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelNorthernBreeze.Controllers
{
    public class LoginController : Controller
    {

        private readonly NBEDBContext _context;


        public LoginController(NBEDBContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(string nic, string password)
        {

            // check if a user with this NIC exists
            var user = _context.Users.SingleOrDefault(u => u.Nic == nic);
            if(user is null)
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
                return RedirectToAction("index", "home");
            }

        }

    }
}
