using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Dtos
{
    public class CarAvailbilityTimeDto
    {
        public string time { get; set; }
        public bool IsAvailable { get; set; }
        public int BookingId { get; set; }
        public int CarId { get; set; }
        public int Hour { get; set; }
        public DateTime Date { get; set; }
    }
}
