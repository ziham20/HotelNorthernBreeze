using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelNorthernBreeze.Data;
using HotelNorthernBreeze.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace HotelNorthernBreeze.Services
{
    /// <summary>
    /// Authentication service
    /// </summary>
    public class AuthService
    {
        private const string LOGGED_USER_KEY = "__logged_user__";
        private readonly ISession _session;
        private readonly NBEDBContext _context;

        public AuthService(IHttpContextAccessor httpContextAccessor, NBEDBContext context)
        {
            _session = httpContextAccessor.HttpContext.Session;
            _context = context;
        }

        /// <summary>
        /// Returns true if a user is logged in
        /// </summary>
        public bool IsLoggedIn => _session.TryGetValue(LOGGED_USER_KEY, out _);

        /// <summary>
        /// Get logged in user
        /// </summary>
        public User LoggedUser
        {
            get
            {
                return _context.Users.Include(u => u.Bookings)
                                     .ThenInclude(b => b.Room)
                                     .SingleOrDefault(u => u.Nic == _session.GetString(LOGGED_USER_KEY));
            }
        }

        /// <summary>
        /// Login a user
        /// </summary>
        public void LoginUser(User user)
        {
            _session.SetString(LOGGED_USER_KEY, user.Nic);
        }

        /// <summary>
        /// Logout the currently logged in user
        /// </summary>
        public void LoginOut()
        {
            _session.Remove(LOGGED_USER_KEY);
        }

    }
}
