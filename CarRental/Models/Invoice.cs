using System;
using System.ComponentModel.DataAnnotations;

namespace CarRental.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public Booking Booking { get; set; }
        public long InvoiceNumber { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime DueDate { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }

        [Display(Name = "Customer")]
        public int CustomerId { get; set; }
        
        [Display(Name = "Booking")]
        public int BookingId { get; set; }
    }
}