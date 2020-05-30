using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Dtos
{
    public class BookingExtraDto
    {
        public int Id { get; set; }
        public BookingDto Booking { get; set; }
        public ExtraDto Extra { get; set; }

        // TODO: do we need it ?
        public int Count { get; set; }
        public int ExtraId { get; set; }
        public int BookingId { get; set; }
        public float Price { get; set; }
        public string Name { get; set; }
        public int PriceType { get; set; }
    }
}
