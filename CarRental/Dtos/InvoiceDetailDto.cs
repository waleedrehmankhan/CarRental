using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Dtos
{
    public class InvoiceDetailDto
    {
        public int InvoiceId { get; set; }
        public InvoiceDto Invoice { get; set; }
        public CarDto Car { get; set; }
        public List<ExtraDto> BookingExtraList { get; set; }
        public PaymentDto Payment { get; set; }
        public BookingDto Booking { get; set; }
    }
}
