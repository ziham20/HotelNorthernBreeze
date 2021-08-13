using HotelNorthernBreeze.Data;
using HotelNorthernBreeze.Models;
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
        private readonly ILogger<HomeController> _logger;
        private readonly NBEDBContext _NBEDBContext;

        public HomeController(ILogger<HomeController> logger, NBEDBContext nBEDBContext)
        {
            _logger = logger;
            _NBEDBContext = nBEDBContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BookingHistory()
        {
            return View();
        }
        public IActionResult MyBookings()
        {
            return View(_NBEDBContext.Bookings.Include(b => b.Room).ToList());
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
