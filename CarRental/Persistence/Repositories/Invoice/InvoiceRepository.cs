using CarRental.Data;
using CarRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Persistence
{
    public class InvoiceRepository : Repository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(ApplicationDbContext context):base(context)
        {
             
        }

        public long GetMaxBookingId()
        {
            return  this.dbSet.Select(x=>x.BookingId).Max();
        }
    }
}
