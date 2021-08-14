using HotelNorthernBreeze.Data;
using HotelNorthernBreeze.Models;
using HotelNorthernBreeze.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HotelNorthernBreeze.Controllers
{
    public class HomeController : Controller
    {
        private readonly NBEDBContext _context;
        private readonly AuthService _authService;

        public HomeController(NBEDBContext context, AuthService authService)
        {
            _context = context;
            _authService = authService;
        }


        // GET : /home
        public IActionResult Index()
        {
            // redirect to login if user is not logged in
            if (!_authService.IsLoggedIn)
                return Redirect("login");

            else
                return View();
        }


        [HttpPost]
        public IActionResult CreateBooking(Booking booking)
        {
            return null;
        }

        public IActionResult BookingHistory()
        {
            return View();
        }
        public IActionResult MyBookings()
        {
            return View(_context.Bookings.Include(b => b.Room).ToList());
        }

        public IActionResult Booking()
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
