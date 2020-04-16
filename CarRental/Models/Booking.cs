using System;
using System.ComponentModel.DataAnnotations;

namespace CarRental.Models
{
    public class Booking
    {
        public int Id { get; set; }
        
        public Customer Customer { get; set; }

        public Car Car { get; set; }

        public DateTime FromDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime ActualReturnDate { get; set; }
        public bool isActive { get; set; }

        [Display(Name = "Customer")]
        public int CustomerId { get; set; }

        [Display(Name = "Car")]
        public int CarId { get; set; }

    }
}