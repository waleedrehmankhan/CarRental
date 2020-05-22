using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Dtos
{
    public class PaymentDto
    {
        public int Id { get; set; }
        public InvoiceDto Invoice { get; set; }
        public DateTime PaymentDate { get; set; }
        public string ReceiptNumber { get; set; }
        public double TotalAmount { get; set; }
        public double GST { get; set; }
        public double LateFee { get; set; }
        public string PaymentType { get; set; }
        public string Remarks { get; set; }
         
        public int InvoiceId { get; set; }
    }
}
