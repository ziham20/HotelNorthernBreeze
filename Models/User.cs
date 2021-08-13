using System;
using System.Collections.Generic;

#nullable disable

namespace HotelNorthernBreeze.Models
{
    public partial class User
    {
        public User()
        {
            Bookings = new HashSet<Booking>();
        }

        public string Nic { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Telephone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
