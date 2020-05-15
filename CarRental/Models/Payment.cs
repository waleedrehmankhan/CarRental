using System;
using System.ComponentModel.DataAnnotations;

namespace CarRental.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public Booking Booking { get; set; }
        public DateTime PaymentDate { get; set; }
        public double TotalAmount { get; set; }
        public double GST { get; set; }
        public double LateFee { get; set; }
        public bool isPaid { get; set; }

        [Display(Name = "Booking")]
        public int BookingId { get; set; }
    }
}