using System.ComponentModel.DataAnnotations;

namespace CarRental.Models
{
    public class BookingExtra
    {
        public int Id { get; set; }
        public Booking Booking { get; set; }
        public Extra Extra { get; set; }

        // TODO: do we need it ?
        public int? Count { get; set; }
        
        [Display(Name = "Extra")]
        public int ExtraId { get; set; }

        [Display(Name = "Booking")]
        public int BookingId { get; set; }
    }
}