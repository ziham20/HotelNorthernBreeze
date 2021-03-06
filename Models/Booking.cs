using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace HotelNorthernBreeze.Models
{
    public partial class Booking
    {
        [Required]
        [DataType(DataType.Text)]
        public string Category { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Size { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [RegularExpression("^([0-9]{9}[x|X|v|V]|[0-9]{12})$", ErrorMessage = "Invalid NIC")]
        public string UserNic { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Check-in")]
        public DateTime FromDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Check-out")]
        public DateTime ToDate { get; set; }

        public virtual Room Room { get; set; }
        public virtual User User { get; set; }
    }
}
