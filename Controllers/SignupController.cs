using HotelNorthernBreeze.Data;
using HotelNorthernBreeze.Models;
using HotelNorthernBreeze.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace HotelNorthernBreeze.Controllers
{
    public class SignupController : Controller
    {

        private readonly NBEDBContext _context;
        private readonly AuthService _authService;


        public SignupController(NBEDBContext context, AuthService authService)
        {
            _context = context;
            _authService = authService;
        }


        // GET : /signup
        [HttpGet]
        public IActionResult Index()
        {
            // return to home if user is already logged in
            if (_authService.IsLoggedIn)
                return Redirect("/");

            else
                return View();
        }


        // POST : /signup/create
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

                // log user
                _authService.LoginUser(user);

                return RedirectToAction("index", "home");
            }

        }

    }
}
