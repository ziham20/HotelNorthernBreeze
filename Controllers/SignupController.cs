using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelNorthernBreeze.Data;
using HotelNorthernBreeze.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelNorthernBreeze.Controllers
{
    public class SignupController : Controller
    {

        private readonly NBEDBContext _context;


        public SignupController(NBEDBContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(User user)
        {

            // check if a user with this NIC is already there
            if (_context.Users.Any(u => u.Nic == user.Nic))
            {
                ViewBag.error = $"NIC {user.Nic} already has an account";
                return View("index");
            }

            // check if a user with this email is already there
            else if (_context.Users.Any(u => u.Email == user.Email))
            {
                ViewBag.error = $"email {user.Email} already has an account";
                return View("index");
            }


            // add user
            else
            {
                _context.Users.Add(user);
                _context.SaveChanges();

                return RedirectToAction("index", "home");
            }

        }

    }
}
