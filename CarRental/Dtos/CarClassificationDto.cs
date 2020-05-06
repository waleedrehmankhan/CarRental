using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Dtos
{
    public class CarClassificationDto
    {
        public int Id { get; set; }
        public int PassengerCount { get; set; }
        public float CostPerHour { get; set; }
        public float CostPerDay { get; set; }
        public float LateFeePerHour { get; set; }
    }
}
