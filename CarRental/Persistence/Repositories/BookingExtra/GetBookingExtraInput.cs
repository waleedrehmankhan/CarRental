using CarRental.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Persistence.Repositories.BookingExtra
{
    public class GetBookingExtraInput: PagedAndSortedInputDto
    {
        public int BookingId { get; set; }
    }
}
