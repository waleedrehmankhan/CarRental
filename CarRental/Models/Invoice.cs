using System;
using System.ComponentModel.DataAnnotations;

namespace CarRental.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public Payment Payment { get; set; }
        public long InvoiceNumber { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime DueDate { get; set; }
        public string Description { get; set; }

        [Display(Name = "Customer")]
        public int CustomerId { get; set; }

        [Display(Name = "Payment")]
        public int PaymentId { get; set; }
    }
}