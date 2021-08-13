using System;
using System.Collections.Generic;

#nullable disable

namespace HotelNorthernBreeze.Models
{
    public partial class Room
    {
        public Room()
        {
            Bookings = new HashSet<Booking>();
        }

        public string Category { get; set; }
        public string Size { get; set; }
        public double Rate { get; set; }
        public int Count { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
