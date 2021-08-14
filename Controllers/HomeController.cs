using HotelNorthernBreeze.Data;
using HotelNorthernBreeze.Models;
using HotelNorthernBreeze.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;

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


        // GET : /home
        public IActionResult BookingCreated()
        {
            // redirect to login if user is not logged in
            if (!_authService.IsLoggedIn)
                return Redirect("login");

            else
            {
                ViewBag.message = "Booking was created";
                return View("index");
            }
        }


        // POST : /home/createbooking
        [HttpPost]
        public IActionResult CreateBooking(Booking booking)
        {

            // get bookings of the given room type and size
            // start date should be greater than ending dates and less than ending dates of other bookings
            // or end date should be less than starting dates and greater than starting dates of other bookings

            // get the number of rooms booked in the given period
            var bookedRoomsCount = _context.Bookings.Count(
                b => b.Size == booking.Size && b.Category == booking.Category
                && ((b.FromDate >= booking.FromDate && b.FromDate <= booking.ToDate)
                || (b.ToDate <= booking.ToDate && b.ToDate >= booking.FromDate)));

            // get total rooms of this type
            int totalRooms = _context.Rooms.Single(b => b.Category == booking.Category && b.Size == booking.Size).Count;

            // check if more rooms are available of this type
            var roomsAvailable = bookedRoomsCount < totalRooms;

            if (roomsAvailable)
            {
                // send current booking
                return RedirectToAction("index", "booking", booking);
            }
            else
            {
                ViewBag.error = "No rooms are available";
                return View("index");
            }
        }
        

        // GET : /home/mybookings
        public IActionResult MyBookings()
        {
            return View(_context.Bookings.Include(b => b.Room)
                                         .Where(u => u.UserNic == _authService.LoggedUser.Nic)
                                         .ToList());
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
