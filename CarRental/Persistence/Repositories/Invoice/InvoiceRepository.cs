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
            var id= this.dbSet.Select(x => x.BookingId);
            return   id.Count()==0?0:id.Max();
        }
    }
}
