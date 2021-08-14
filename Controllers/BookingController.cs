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
    public class BookingController : Controller
    {

        private readonly NBEDBContext _context;
        private readonly AuthService _authService;


        public BookingController(AuthService authService, NBEDBContext context)
        {
            _authService = authService;
            _context = context;
        }


        // GET : /booking
        public IActionResult Index(Booking booking)
        {
            // redirect to login if user is not logged in
            if (!_authService.IsLoggedIn)
                return Redirect("login");

            // get room and user details
            booking.Room = _context.Rooms.Single(r => r.Size == booking.Size && r.Category == booking.Category);
            booking.User = _authService.LoggedUser;

            // send booking details to view
            ViewBag.booking = booking;
            return View();
        }


        // POST : /booking/create
        public IActionResult Create(Booking booking)
        {
            // redirect to login if user is not logged in
            if (!_authService.IsLoggedIn)
                return Redirect("login");

            // add booking to database
            _context.Bookings.Add(booking);

            // go home
            ViewBag.booking = booking;
            return RedirectToAction("index", "home");
        }

    }
}
