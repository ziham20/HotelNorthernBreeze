using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace HotelNorthernBreeze.Models
{
    public partial class User
    {
        public User()
        {
            Bookings = new HashSet<Booking>();
        }

        [Required]
        [DataType(DataType.Text)]
        [RegularExpression("^([0-9]{9}[x|X|v|V]|[0-9]{12})$", ErrorMessage = "Invalid NIC")]
        public string Nic { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Phone]
        public string Telephone { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
