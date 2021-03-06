using System;
using System.ComponentModel.DataAnnotations;

namespace CarRental.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public Invoice Invoice { get; set; }
        public DateTime PaymentDate { get; set; }
        public string ReceiptNumber { get; set; }
        public double TotalAmount { get; set; }
        public double GST { get; set; }
        public double LateFee { get; set; }
        public bool IsReversed { get; set; }
        public string PaymentType { get; set; }
        public string Remarks { get; set; }

        [Display(Name = "Invoice")]
        public int InvoiceId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
    }
}