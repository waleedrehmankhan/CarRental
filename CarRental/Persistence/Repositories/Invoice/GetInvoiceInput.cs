using CarRental.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Persistence.Repositories.Invoice
{
    public class GetInvoiceInput : PagedAndSortedInputDto
    {
        public string invoice_number { get; set; }
        public int Id { get; set; }
    }
}
