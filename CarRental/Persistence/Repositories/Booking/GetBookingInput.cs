using CarRental.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Persistence.Repositories.Booking
{
    public class GetBookingInput : PagedAndSortedInputDto
    {
        public int Id { get; set; }
    }
}
