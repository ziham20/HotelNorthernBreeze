using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace HotelNorthernBreeze.Models
{
    public partial class Room
    {
        public Room()
        {
            Bookings = new HashSet<Booking>();
        }

        [Required]
        [DataType(DataType.Text)]
        public string Category { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Size { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [DisplayName("Price")]
        public double Rate { get; set; }

        [Required]
        public int Count { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
