using CarRental.Data;
using CarRental.Models;
using CarRental.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Persistence
{
    public class BookingExtraRepository : Repository<BookingExtra>, IBookingExtraRepository
    {
        public BookingExtraRepository(ApplicationDbContext context) : base(context)
        {


        }
    }
}
